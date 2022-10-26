using ReadDiskInfor.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
        //cong hoa xa hoi chu nghia viet nam
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            SConnect();
        }

        //server
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


        byte[] SSerialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }

        //Gom mảnh 
        object SDeSerialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
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


                byte[] data = new byte[1024 * 10000];
                stream.Read(data, 0, data.Length);
                GetAllDiskVolume(data);

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

        void GetAllDiskVolume(byte[] data)
        {
            Volume = (DriveInfo[])SDeSerialize(data);
            for (int i = 0; i < Volume.Length; i++)
            {
                cbbVolume.Items.Add(Volume[i] );
            }
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
            lvClient.Items.Clear();
            lvClient.Items.Add(new ListViewItem() { Text = "127.0.0.1" });
            string sHostName = Dns.GetHostName();
            Console.WriteLine("Host name: {0}", sHostName);
            IPHostEntry ipE = Dns.GetHostByName(sHostName);
            IPAddress[] IpA = ipE.AddressList;
            for (int i = 0; i < IpA.Length; i++)
            {
                lvClient.Items.Add(new ListViewItem() { Text = IpA[i].ToString() });
            }
        }
    }
}
