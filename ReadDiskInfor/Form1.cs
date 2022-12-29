using ReadDiskInfor.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
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

        /// <Server>
        IPEndPoint IP;
        Socket socClient;
        TcpListener tcpListener; // lắng nghe kết nối từ client
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
                        
                            socClient = tcpListener.AcceptSocket(); // trả về 1 đối tượng Socket dùng để gửi nhận dữ liệu
                            clientList.Add(socClient);

                            Console.WriteLine(clientList.Count());
                            Thread receive = new Thread(SReceive);
                            receive.IsBackground = true;
                            receive.Start(socClient);
                        
                       
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
        void SSend(DiskInfor disk, Socket socClient)
        {
            foreach (Socket c in clientList)
            {
                if (socClient == c)
                    c.Send(SSerialize(disk)); // chỉ gửi dữ liệu về cho client đã yêu cầu
            }
        }
        void SReceive(Object obj)
        {
            Socket client = obj as Socket;
            try
            {
                byte[] data1 = new byte[1024 * 10000];
                DriveInfo[] list = DriveInfo.GetDrives();
                socClient.Send(SSerialize(list)); // Gửi danh sách các phân vùng 
                while (true)
                {
                    byte[] data = new byte[1024 * 10000];
                    client.Receive(data);
                    string message = (string)SDeSerialize(data);

                    if (!message.Equals(""))
                    {
                        DiskInfor disk = new DiskInfor();
                        disk.GetDiskSpace(message, out disk.TotalDiskSpace, out disk.FreeDiskSpace);
                        disk.GetDiskType(message, disk.VolumeName, out disk.SectoPerClusterNumber, out disk.BytePerSectorNumber, out disk.SerialNumber, disk.DiskType);
                        SSend(disk, client);
                    }

                }

            }
            catch
            {
               // CClose();
            }
        }

        bool CheckClient(Socket check)
        {
            foreach (Socket c in clientList)
            {
                if (check == c)
                    return false;
            }
            return true;
        }
        /// </Server>


        /// <Client>
        IPEndPoint IPc;
        TcpClient client; // tạo một client 
        Stream stream;
        DiskInfor diskClient = new DiskInfor();
        DriveInfo[] Volume;
        string ipHost = "";
        string volumeName = "";
        void CConnect()
        {
            try
            {
                IPc = new IPEndPoint(IPAddress.Parse(ipHost), 9999);
                client = new TcpClient();
                client.Connect(IPc);
                stream = client.GetStream();
                lbStatus.Text = "Connected to " + ipHost;
                byte[] data = new byte[1024 * 10000];
                stream.Read(data, 0, data.Length);

                GetAllDiskVolume(data); // Nhận danh sách ổ đĩa từ Server
                    
            }
            catch
            {
                MessageBox.Show("Không thể kết nối", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Thread listen = new Thread(CReceive);
            listen.IsBackground = true;
            listen.Start();
        }
        void CClose()
        {
            if (client != null)
            {
                client.Close();
                lbStatus.Text = "";
                ipHost = "";
                volumeName = "";
            }
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
        /// </Client>
       

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

        public void GetAllDiskVolume(byte[] data)
        {
            Volume = (DriveInfo[])SDeSerialize(data);
            for (int i = 0; i < Volume.Length; i++)
            {
                cbbVolume.Items.Add(Volume[i] );
            }
        }
        public void AddDiskInfor(DiskInfor disk)
        {
            tbVolumeName.Text   = disk.VolumeName.ToString();
            tbSerialNumber.Text = disk.SerialNumber.ToString();
            tbDiskType.Text     = disk.DiskType.ToString();
            tbDiskSpace.Text    = disk.ConvertBytesToGigabytes(disk.TotalDiskSpace).ToString() + " GB" ;
            tbDiskFree.Text     = disk.ConvertBytesToGigabytes(disk.FreeDiskSpace).ToString() + " GB";
            tbBpS.Text          = disk.BytePerSectorNumber.ToString();
            tbSpC.Text          = disk.SectoPerClusterNumber.ToString();
        }
        public void Resetlabel()
        {
            tbVolumeName.Text   = "";
            tbSerialNumber.Text = "";
            tbDiskType.Text     = "";
            tbDiskSpace.Text    = "";
            tbDiskFree.Text     = "";
            tbBpS.Text          = "";
            tbSpC.Text          = "";
        }
        public void ResetcbbVolume()
        {
            cbbVolume.Text = "";
            //for (int i = 0; i < cbbVolume.Items.Count; i++)
            //    cbbVolume.Items.RemoveAt(i);
            cbbVolume.Items.Clear();
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
        public void ScanIP()
        {
            string[] startIPString = GetIPAddress().Split('.');
            int[] startIP = Array.ConvertAll<string, int>(startIPString, int.Parse); //Change string array to int array
            int count = 0; //Count the number of successful pings
            Ping myPing;
            PingReply reply;

            //Progress bar
            progressBar.Maximum = 254;
            progressBar.Value = 0;
            lvClient.Items.Clear();
            //Loops through the IP range, maxing out at 255
            for (int y = 1; y < 255; y++)
            {
                string ipAddress = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + y; //Convert IP array back into a string

                myPing = new Ping();
                try
                {
                    reply = myPing.Send(ipAddress,500); //Ping IP address with 500ms timeout
                    if (reply.Status == IPStatus.Success)
                    {
                        lvClient.Items.Add(new ListViewItem(ipAddress)); //Log successful pings
                        count++;
                    }
                }
                catch
                {
                    break;
                }
                progressBar.Value += 1; //Increase progress bar
            }
            MessageBox.Show("Scanning done!\nFound " + count + " hosts.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
         
        private void btnRead_Click(object sender, EventArgs e)
        {
            if(volumeName != "" && client != null)
            {
                byte[] data = new byte[1024 * 10000];
                data = SSerialize(volumeName);
                stream.Write(data, 0, data.Length);
            }
        }

        Thread myThread  ;
        private void btnScanIP_Click(object sender, EventArgs e)
        {
            myThread = new Thread(() => ScanIP());
            myThread.IsBackground = true;
            myThread.Start();
           
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            volumeName = "";
            ResetcbbVolume();
            Resetlabel();
            if ( ipHost != "")
                CConnect();
            //Console.WriteLine(cbbVolume.Items.Count);
            ipHost = "";
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            CClose();
            ResetcbbVolume();
            Resetlabel();
        }

        private void lvClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvClient.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = lvClient.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                
                string temp  = lvClient.Items[intselectedindex].Text;
                lbStatus.Text = "You choose IP: " + temp;
                //Nhập ip tay.
                //ipHost = "192.168.0.104"; 
                ipHost = temp;
                Console.WriteLine(temp);
                    
            }
            
        }

        private void cbbVolume_SelectionChangeCommitted(object sender, EventArgs e)
        {
            volumeName = cbbVolume.GetItemText(cbbVolume.SelectedItem).ToString(); 
        }

        private void tbIP_TextChanged(object sender, EventArgs e)
        {
            ipHost = tbIP.Text;
        }
    }
}
