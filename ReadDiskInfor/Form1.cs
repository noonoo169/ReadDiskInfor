using ReadDiskInfor.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadDiskInfor   
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            SConnect();
        }

        // Server
        IPEndPoint IP;
        Socket socClient;
        TcpListener tcpListener;
        List<Socket> clientList;
        
        void SConnect()
        {
            clientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 9999);
            tcpListener = new TcpListener(IP);

            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        tcpListener.Start();
                        socClient = tcpListener.AcceptSocket();
                        clientList.Add(socClient);

                        


                        Thread receive = new Thread(SReceive);
                        receive.IsBackground = true;
                        receive.Start(socClient);

                        // Gửi danh sách các phân vùng 
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    tcpListener = new TcpListener(IP);
                }
            });
            Listen.IsBackground = true;
            Listen.Start();

        }
        void SSend(DiskInfor disk)
        {
            foreach (Socket client in clientList)
            {
                if (socClient == client)
                    client.Send(SSerialize(disk));
            }
        }
        void SReceive(Object obj)
        {
            Socket client = obj as Socket;
            try
            {
                byte[] data1 = new byte[1024 * 10000];
                DriveInfo[] list = DriveInfo.GetDrives();
                socClient.Send(SSerialize(list));
                while (true)
                {
                    byte[] data = new byte[1024 * 10000];
                    client.Receive(data);
                    string message = (string)SDeSerialize(data);

                    if (!message.Equals(""))
                    {
                        DiskInfor disk = new DiskInfor();
                        disk.GetDiskSpace(message, out disk.TotalDiskSpace, out disk.FreeDiskSpace);
                        disk.DiskType = disk.GetDiskType(message, disk.VolumeName, out disk.SectoPerClusterNumber, out disk.BytePerSectorNumber, out disk.SerialNumber);
                        
                        byte[] data2 = SSerialize(disk);
                        socClient.Send(data2);
                    }

                }

            }
            catch
            {
               // CClose();
            }
        }
 
        
        // Gom mảnh phân mảnh
        byte[] SSerialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }
        object SDeSerialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }


        // Client 
        IPEndPoint IPc;
        TcpClient client;
        Stream stream;
        DiskInfor diskClient = new DiskInfor();
        DriveInfo[] Volume;
        string ipHost;
        string volumeName = "";

        void CConnect()
        {
            try
            {
                IPc = new IPEndPoint(IPAddress.Parse(ipHost), 9999);
                client = new TcpClient();
                client.Connect(IPc);
                stream = client.GetStream();
                lbStatus.Text = "Connected !!";

                byte[] data = new byte[1024 * 10000];
                stream.Read(data, 0, data.Length);
                GetAllDiskVolume(data);

            }
            catch
            {
                MessageBox.Show("Không thể kết nối", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //lbStatus.Text = "Cannot connect";
                return;
            }
            Thread listen = new Thread(CReceive);
            listen.IsBackground = true;
            listen.Start();
        }
        void CClose()
        {
            if(client != null)
            client.Close();

        }
        void CReceive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 10000];
                    stream.Read(data, 0, data.Length);
                    diskClient = (DiskInfor)SDeSerialize(data);
                    AddDiskInfor(diskClient);
                }

            }
            catch
            {
                CClose();
            }
        }

        void GetAllDiskVolume(byte[] data)
        {
            Volume = (DriveInfo[])SDeSerialize(data);
            for (int i = 0; i < Volume.Length; i++)
            {
                cbbVolume.Items.Add(Volume[i] );
            }
        }
        void AddDiskInfor(DiskInfor disk)
        {
            tbVolumeName.Text = disk.VolumeName.ToString();
            tbSerialNumber.Text = disk.SerialNumber.ToString();
            tbDiskType.Text = disk.DiskType.ToString();
            tbDiskSpace.Text = disk.ConvertBytesToGigabytes(disk.TotalDiskSpace).ToString() + " GB" ;
            tbDiskFree.Text = disk.ConvertBytesToGigabytes(disk.FreeDiskSpace).ToString() + " GB";
            tbBpS.Text = disk.BytePerSectorNumber.ToString();
            tbSpC.Text = disk.SectoPerClusterNumber.ToString();
        }
         
        private void btnRead_Click(object sender, EventArgs e)
        {
            if(volumeName != "")
            {
                byte[] data = new byte[1024 * 10000];
                data = SSerialize(volumeName);
                stream.Write(data, 0, data.Length);
            }
        }

        private void lvClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbVolume.Items.Clear();
            if (lvClient.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = lvClient.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                if (ipHost != lvClient.Items[intselectedindex].Text)
                {
                    CClose();
                    ipHost = lvClient.Items[intselectedindex].Text;
                    //ipHost = "192.168.0.100";
                    Console.WriteLine(ipHost);
                    //tbSpC.Text = lvClient.Items[intselectedindex].Text;
                    CConnect();
                }
            }
            
        }

        private void cbbVolume_SelectionChangeCommitted(object sender, EventArgs e)
        {
            volumeName = cbbVolume.GetItemText(cbbVolume.SelectedItem).ToString(); 
        }

        private void btnScanIP_Click(object sender, EventArgs e)
        {
            Thread myThread = new Thread(() => scan2());
            myThread.Start();
        }

        public string GetIPAddress()
        {
            string IPAddress = string.Empty;
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;
        }

        public void scan2()
        {
            //lvClient.Items.Clear();
            //lvClient.Items.Add(new ListViewItem() { Text = "127.0.0.1" });
            //string sHostName = Dns.GetHostName();
            //Console.WriteLine("Host name: {0}", sHostName);
            //IPHostEntry ipE = Dns.GetHostByName(sHostName);
            //IPAddress[] IpA = ipE.AddressList;
            //for (int i = 0; i < IpA.Length; i++)
            //{
            //    lvClient.Items.Add(new ListViewItem() { Text = IpA[i].ToString() });
            //}

            try
            {

                //Split IP string into a 4 part array
                string[] startIPString = GetIPAddress().Split('.');
                int[] startIP = Array.ConvertAll<string, int>(startIPString, int.Parse); //Change string array to int array
                string[] endIPString = GetIPAddress().Split('.');
                int[] endIP = Array.ConvertAll<string, int>(endIPString, int.Parse);
                endIP[3] = 255;
                int count = 0; //Count the number of successful pings
                Ping myPing;
                PingReply reply;
                IPAddress addr;
                IPHostEntry host;

                //Progress bar
                progressBar.Maximum = 255;
                progressBar.Value = 0;
                lvClient.Items.Clear();
                status.Text = "Scanning...";
                //Loops through the IP range, maxing out at 255
                    for (int y = 0; y <= 255; y++)
                    { //4th octet loop
                        string ipAddress = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + y; //Convert IP array back into a string
                        string endIPAddress = endIP[0] + "." + endIP[1] + "." + endIP[2] + "." + (endIP[3] + 1); // +1 is so that the scanning stops at the correct range

                        //If current IP matches final IP in range, break
                        if (ipAddress == endIPAddress)
                        {
                            break;
                        }

                        myPing = new Ping();
                        try
                        {
                            reply = myPing.Send(ipAddress, 500); //Ping IP address with 500ms timeout
                        }
                        catch (Exception ex)
                        {
                            break;
                        }

                        ///lblStatus.ForeColor = System.Drawing.Color.Green; //Set status label for current IP address
                        //lblStatus.Text = "Scanning: " + ipAddress;

                        //Log pinged IP address in listview
                        //Grabs DNS information to obtain system info
                        if (reply.Status == IPStatus.Success)
                        {
                            try
                            {
                                addr = IPAddress.Parse(ipAddress);
                                host = Dns.GetHostEntry(addr);
                                lvClient.Items.Add(new ListViewItem(new String[] { ipAddress })); //Log successful pings
                                count++;
                            }
                            catch
                            {

                                lvClient.Items.Add(new ListViewItem(new String[] { ipAddress})); //Logs pings that are successful, but are most likely not windows machines
                                count++;
                            }
                        }
                        else
                        {
                            //lvResult.Items.Add(new ListViewItem(new String[] { ipAddress, "n/a", "Down" })); //Log unsuccessful pings
                        }
                        progressBar.Value += 1; //Increase progress bar
                    }

                    startIP[3] = 1; //If 4th octet reaches 255, reset back to 1
                

                //Re-enable buttons
                //button1.Enabled = true;
                // cmdStop.Enabled = false;
                // txtIP.Enabled = true;
                //lblStatus.ForeColor = System.Drawing.Color.Green;
                //lblStatus.Text = "Done!";
                status.Text = "Done";
                MessageBox.Show("Scanning done!\nFound " + count + " hosts.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Catch exception that throws when stopping thread, caused by ping waiting to be acknowledged
            }
            catch (ThreadAbortException tex)
            {
                Console.WriteLine(tex.StackTrace);
                //cmdScan.Enabled = true;
                //cmdStop.Enabled = false;
                //txtIP.Enabled = true;
                //txtIP2.Enabled = true;
                //lblStatus.ForeColor = System.Drawing.Color.Red;
                //lblStatus.Text = "Scanning stopped";
            }
            //Catch invalid IP types
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                //cmdScan.Enabled = true;
                //cmdStop.Enabled = false;
                // txtIP.Enabled = true;
                //txtIP2.Enabled = true;
                //lblStatus.ForeColor = System.Drawing.Color.Red;
                //lblStatus.Text = "Invalid IP range";
            }
        }
    }
}
