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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("127.0.0.1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("23234234234");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("4234234234");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("345345345");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("345345345");
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
            this.status = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbSpC
            // 
            this.tbSpC.Location = new System.Drawing.Point(170, 367);
            this.tbSpC.Name = "tbSpC";
            this.tbSpC.Size = new System.Drawing.Size(224, 26);
            this.tbSpC.TabIndex = 106;
            // 
            // tbBpS
            // 
            this.tbBpS.Location = new System.Drawing.Point(170, 312);
            this.tbBpS.Name = "tbBpS";
            this.tbBpS.Size = new System.Drawing.Size(224, 26);
            this.tbBpS.TabIndex = 105;
            // 
            // tbDiskFree
            // 
            this.tbDiskFree.Location = new System.Drawing.Point(170, 253);
            this.tbDiskFree.Name = "tbDiskFree";
            this.tbDiskFree.Size = new System.Drawing.Size(224, 26);
            this.tbDiskFree.TabIndex = 104;
            // 
            // tbDiskSpace
            // 
            this.tbDiskSpace.Location = new System.Drawing.Point(170, 203);
            this.tbDiskSpace.Name = "tbDiskSpace";
            this.tbDiskSpace.Size = new System.Drawing.Size(224, 26);
            this.tbDiskSpace.TabIndex = 103;
            // 
            // tbDiskType
            // 
            this.tbDiskType.Location = new System.Drawing.Point(170, 145);
            this.tbDiskType.Name = "tbDiskType";
            this.tbDiskType.Size = new System.Drawing.Size(224, 26);
            this.tbDiskType.TabIndex = 102;
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Location = new System.Drawing.Point(170, 94);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(224, 26);
            this.tbSerialNumber.TabIndex = 101;
            // 
            // tbVolumeName
            // 
            this.tbVolumeName.Location = new System.Drawing.Point(170, 39);
            this.tbVolumeName.Name = "tbVolumeName";
            this.tbVolumeName.Size = new System.Drawing.Size(224, 26);
            this.tbVolumeName.TabIndex = 100;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 20);
            this.label7.TabIndex = 99;
            this.label7.Text = "Số Secter/Cluster :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 20);
            this.label6.TabIndex = 98;
            this.label6.Text = "Số Byte/Secter :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 97;
            this.label5.Text = "Còn trống : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 96;
            this.label4.Text = "Dung lượng :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 95;
            this.label3.Text = "Định dạng :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 94;
            this.label2.Text = "Số Serial :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 46);
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
            this.lvClient.Location = new System.Drawing.Point(419, 39);
            this.lvClient.Name = "lvClient";
            this.lvClient.Size = new System.Drawing.Size(254, 317);
            this.lvClient.TabIndex = 107;
            this.lvClient.UseCompatibleStateImageBehavior = false;
            this.lvClient.View = System.Windows.Forms.View.Details;
            this.lvClient.SelectedIndexChanged += new System.EventHandler(this.lvClient_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP Computer";
            this.columnHeader1.Width = 249;
            // 
            // btnScanIP
            // 
            this.btnScanIP.Location = new System.Drawing.Point(459, 433);
            this.btnScanIP.Name = "btnScanIP";
            this.btnScanIP.Size = new System.Drawing.Size(151, 58);
            this.btnScanIP.TabIndex = 108;
            this.btnScanIP.Text = "Scan IP";
            this.btnScanIP.UseVisualStyleBackColor = true;
            this.btnScanIP.Click += new System.EventHandler(this.btnScanIP_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(705, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 20);
            this.label9.TabIndex = 110;
            this.label9.Text = "Disk Volume";
            // 
            // cbbVolume
            // 
            this.cbbVolume.FormattingEnabled = true;
            this.cbbVolume.Location = new System.Drawing.Point(712, 62);
            this.cbbVolume.Name = "cbbVolume";
            this.cbbVolume.Size = new System.Drawing.Size(80, 28);
            this.cbbVolume.TabIndex = 111;
            this.cbbVolume.SelectionChangeCommitted += new System.EventHandler(this.cbbVolume_SelectionChangeCommitted);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(181, 433);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(151, 58);
            this.btnRead.TabIndex = 112;
            this.btnRead.Text = "Read Infor";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(419, 367);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(254, 23);
            this.progressBar.TabIndex = 113;
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(687, 370);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 20);
            this.status.TabIndex = 115;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(415, 9);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 20);
            this.lbStatus.TabIndex = 116;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 521);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.status);
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
            this.Text = "Form1";
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
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label lbStatus;
    }
}

