namespace ReadDiskInfor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("192.168.0.102");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("10.234.210.195");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("123..162.179.255");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("123.234.231");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("127.0.0.1");
            this.tbSpC = new System.Windows.Forms.TextBox();
            this.tbBpS = new System.Windows.Forms.TextBox();
            this.tbDiskFree = new System.Windows.Forms.TextBox();
            this.tbDiskSpace = new System.Windows.Forms.TextBox();
            this.tbDiskType = new System.Windows.Forms.TextBox();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.tbVolumeName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvClient = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnScanIP = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbbVolume = new System.Windows.Forms.ComboBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbSpC
            // 
            this.tbSpC.Location = new System.Drawing.Point(262, 602);
            this.tbSpC.Name = "tbSpC";
            this.tbSpC.Size = new System.Drawing.Size(224, 26);
            this.tbSpC.TabIndex = 106;
            // 
            // tbBpS
            // 
            this.tbBpS.Location = new System.Drawing.Point(262, 546);
            this.tbBpS.Name = "tbBpS";
            this.tbBpS.Size = new System.Drawing.Size(224, 26);
            this.tbBpS.TabIndex = 105;
            // 
            // tbDiskFree
            // 
            this.tbDiskFree.Location = new System.Drawing.Point(262, 488);
            this.tbDiskFree.Name = "tbDiskFree";
            this.tbDiskFree.Size = new System.Drawing.Size(224, 26);
            this.tbDiskFree.TabIndex = 104;
            // 
            // tbDiskSpace
            // 
            this.tbDiskSpace.Location = new System.Drawing.Point(262, 438);
            this.tbDiskSpace.Name = "tbDiskSpace";
            this.tbDiskSpace.Size = new System.Drawing.Size(224, 26);
            this.tbDiskSpace.TabIndex = 103;
            // 
            // tbDiskType
            // 
            this.tbDiskType.Location = new System.Drawing.Point(262, 380);
            this.tbDiskType.Name = "tbDiskType";
            this.tbDiskType.Size = new System.Drawing.Size(224, 26);
            this.tbDiskType.TabIndex = 102;
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Location = new System.Drawing.Point(262, 329);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(224, 26);
            this.tbSerialNumber.TabIndex = 101;
            // 
            // tbVolumeName
            // 
            this.tbVolumeName.Location = new System.Drawing.Point(262, 274);
            this.tbVolumeName.Name = "tbVolumeName";
            this.tbVolumeName.Size = new System.Drawing.Size(224, 26);
            this.tbVolumeName.TabIndex = 100;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(104, 608);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 20);
            this.label7.TabIndex = 99;
            this.label7.Text = "Số Secter/Cluster :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(122, 552);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 20);
            this.label6.TabIndex = 98;
            this.label6.Text = "Số Byte/Secter :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 491);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 97;
            this.label5.Text = "Còn trống : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 440);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 96;
            this.label4.Text = "Dung lượng :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 95;
            this.label3.Text = "Định dạng :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 94;
            this.label2.Text = "Số Serial :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 93;
            this.label1.Text = "Tên ổ đĩa : ";
            // 
            // lvClient
            // 
            this.lvClient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvClient.HideSelection = false;
            this.lvClient.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lvClient.Location = new System.Drawing.Point(826, 312);
            this.lvClient.Name = "lvClient";
            this.lvClient.Size = new System.Drawing.Size(254, 267);
            this.lvClient.TabIndex = 107;
            this.lvClient.UseCompatibleStateImageBehavior = false;
            this.lvClient.View = System.Windows.Forms.View.Details;
            this.lvClient.SelectedIndexChanged += new System.EventHandler(this.lvClient_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP Computer";
            this.columnHeader1.Width = 150;
            // 
            // btnScanIP
            // 
            this.btnScanIP.Location = new System.Drawing.Point(644, 380);
            this.btnScanIP.Name = "btnScanIP";
            this.btnScanIP.Size = new System.Drawing.Size(152, 58);
            this.btnScanIP.TabIndex = 108;
            this.btnScanIP.Text = "Scan IP";
            this.btnScanIP.UseVisualStyleBackColor = true;
            this.btnScanIP.Click += new System.EventHandler(this.btnScanIP_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(519, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 20);
            this.label9.TabIndex = 110;
            this.label9.Text = "Disk Volume";
            // 
            // cbbVolume
            // 
            this.cbbVolume.FormattingEnabled = true;
            this.cbbVolume.Location = new System.Drawing.Point(524, 312);
            this.cbbVolume.Name = "cbbVolume";
            this.cbbVolume.Size = new System.Drawing.Size(80, 28);
            this.cbbVolume.TabIndex = 111;
            this.cbbVolume.SelectionChangeCommitted += new System.EventHandler(this.cbbVolume_SelectionChangeCommitted);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(644, 282);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(152, 58);
            this.btnRead.TabIndex = 112;
            this.btnRead.Text = "Read Infor";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(826, 588);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(256, 40);
            this.progressBar.TabIndex = 113;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(616, 215);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 20);
            this.lbStatus.TabIndex = 116;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(644, 478);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(152, 58);
            this.btnConnect.TabIndex = 120;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(644, 574);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(152, 58);
            this.btnDisconnect.TabIndex = 121;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.BackColor = System.Drawing.SystemColors.Control;
            this.header.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.Location = new System.Drawing.Point(52, 35);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1073, 163);
            this.header.TabIndex = 122;
            this.header.Text = "Read DiskInfor ";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(903, 274);
            this.tbIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(178, 26);
            this.tbIP.TabIndex = 123;
            this.tbIP.TextChanged += new System.EventHandler(this.tbIP_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(828, 278);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 20);
            this.label8.TabIndex = 124;
            this.label8.Text = "Type IP";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(554, 215);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 20);
            this.label10.TabIndex = 125;
            this.label10.Text = "Status: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 698);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.header);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.cbbVolume);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnScanIP);
            this.Controls.Add(this.lvClient);
            this.Controls.Add(this.tbSpC);
            this.Controls.Add(this.tbBpS);
            this.Controls.Add(this.tbDiskFree);
            this.Controls.Add(this.tbDiskSpace);
            this.Controls.Add(this.tbDiskType);
            this.Controls.Add(this.tbSerialNumber);
            this.Controls.Add(this.tbVolumeName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Đồ án mạng máy tính và nguyên lý hệ điều hành";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSpC;
        private System.Windows.Forms.TextBox tbBpS;
        private System.Windows.Forms.TextBox tbDiskFree;
        private System.Windows.Forms.TextBox tbDiskSpace;
        private System.Windows.Forms.TextBox tbDiskType;
        private System.Windows.Forms.TextBox tbSerialNumber;
        private System.Windows.Forms.TextBox tbVolumeName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvClient;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnScanIP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbbVolume;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
    }
}

