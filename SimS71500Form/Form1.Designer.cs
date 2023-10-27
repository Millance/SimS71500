namespace SimS71500Form
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnConnPlc = new Button();
            txtConnLog = new RichTextBox();
            txtPlcIp = new TextBox();
            label1 = new Label();
            cmbPlcRack = new ComboBox();
            cmbPlcSlot = new ComboBox();
            groupBox1 = new GroupBox();
            label4 = new Label();
            btnDisConnPlc = new Button();
            label3 = new Label();
            label2 = new Label();
            cmbPLcType = new ComboBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            txtInputData = new TextBox();
            txtReadWriteLog = new RichTextBox();
            numBitAdr = new NumericUpDown();
            label10 = new Label();
            numVarCount = new NumericUpDown();
            btnWritePlc = new Button();
            btnReadPlc = new Button();
            label11 = new Label();
            label9 = new Label();
            numStartByteAdr = new NumericUpDown();
            label7 = new Label();
            numDbArea = new NumericUpDown();
            label6 = new Label();
            label8 = new Label();
            label5 = new Label();
            cmbVarType = new ComboBox();
            cmbDataType = new ComboBox();
            ledMotorState = new CustomCircleControl();
            ledMobileDeviceState = new CustomCircleControl();
            label12 = new Label();
            label13 = new Label();
            groupBox4 = new GroupBox();
            txtDeviceLog = new RichTextBox();
            btnCreateMobile = new Button();
            btnCreateMotor = new Button();
            btnAutoReadMobile = new Button();
            btnAutoReadMotor = new Button();
            btnReadMobile = new Button();
            btnReadMotor = new Button();
            timerReadWrite = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBitAdr).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numVarCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStartByteAdr).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDbArea).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // btnConnPlc
            // 
            btnConnPlc.Location = new Point(21, 109);
            btnConnPlc.Name = "btnConnPlc";
            btnConnPlc.Size = new Size(112, 34);
            btnConnPlc.TabIndex = 0;
            btnConnPlc.Text = "连接PLC";
            btnConnPlc.UseVisualStyleBackColor = true;
            btnConnPlc.Click += btnConnPlc_Click;
            // 
            // txtConnLog
            // 
            txtConnLog.Dock = DockStyle.Fill;
            txtConnLog.Location = new Point(3, 26);
            txtConnLog.Name = "txtConnLog";
            txtConnLog.Size = new Size(471, 132);
            txtConnLog.TabIndex = 1;
            txtConnLog.Text = "";
            txtConnLog.WordWrap = false;
            // 
            // txtPlcIp
            // 
            txtPlcIp.Location = new Point(21, 57);
            txtPlcIp.Name = "txtPlcIp";
            txtPlcIp.Size = new Size(150, 30);
            txtPlcIp.TabIndex = 2;
            txtPlcIp.Text = "192.168.0.100";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 26);
            label1.Name = "label1";
            label1.Size = new Size(62, 24);
            label1.TabIndex = 3;
            label1.Text = "IP地址";
            // 
            // cmbPlcRack
            // 
            cmbPlcRack.FormattingEnabled = true;
            cmbPlcRack.Items.AddRange(new object[] { "0", "1" });
            cmbPlcRack.Location = new Point(320, 56);
            cmbPlcRack.Name = "cmbPlcRack";
            cmbPlcRack.Size = new Size(64, 32);
            cmbPlcRack.TabIndex = 4;
            cmbPlcRack.Text = "0";
            // 
            // cmbPlcSlot
            // 
            cmbPlcSlot.FormattingEnabled = true;
            cmbPlcSlot.Items.AddRange(new object[] { "0", "1" });
            cmbPlcSlot.Location = new Point(387, 56);
            cmbPlcSlot.Name = "cmbPlcSlot";
            cmbPlcSlot.Size = new Size(46, 32);
            cmbPlcSlot.TabIndex = 4;
            cmbPlcSlot.Text = "1";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPlcIp);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnDisConnPlc);
            groupBox1.Controls.Add(btnConnPlc);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbPlcSlot);
            groupBox1.Controls.Add(cmbPLcType);
            groupBox1.Controls.Add(cmbPlcRack);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(450, 161);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "PLC";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(387, 26);
            label4.Name = "label4";
            label4.Size = new Size(46, 24);
            label4.TabIndex = 3;
            label4.Text = "槽号";
            // 
            // btnDisConnPlc
            // 
            btnDisConnPlc.Location = new Point(320, 109);
            btnDisConnPlc.Name = "btnDisConnPlc";
            btnDisConnPlc.Size = new Size(112, 34);
            btnDisConnPlc.TabIndex = 0;
            btnDisConnPlc.Text = "断开PLC";
            btnDisConnPlc.UseVisualStyleBackColor = true;
            btnDisConnPlc.Click += btnDisConnPlc_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(320, 26);
            label3.Name = "label3";
            label3.Size = new Size(64, 24);
            label3.TabIndex = 3;
            label3.Text = "机架号";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(177, 26);
            label2.Name = "label2";
            label2.Size = new Size(78, 24);
            label2.TabIndex = 3;
            label2.Text = "PLC类型";
            // 
            // cmbPLcType
            // 
            cmbPLcType.FormattingEnabled = true;
            cmbPLcType.Location = new Point(177, 56);
            cmbPLcType.Name = "cmbPLcType";
            cmbPLcType.Size = new Size(117, 32);
            cmbPLcType.TabIndex = 4;
            cmbPLcType.Text = "S71500";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtConnLog);
            groupBox2.Location = new Point(468, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(477, 161);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "PLC连接日志";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtInputData);
            groupBox3.Controls.Add(txtReadWriteLog);
            groupBox3.Controls.Add(numBitAdr);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(numVarCount);
            groupBox3.Controls.Add(btnWritePlc);
            groupBox3.Controls.Add(btnReadPlc);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(numStartByteAdr);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(numDbArea);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(cmbVarType);
            groupBox3.Controls.Add(cmbDataType);
            groupBox3.Location = new Point(12, 191);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(460, 420);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "读写指定地址数据";
            // 
            // txtInputData
            // 
            txtInputData.Location = new Point(94, 340);
            txtInputData.Name = "txtInputData";
            txtInputData.Size = new Size(128, 30);
            txtInputData.TabIndex = 2;
            txtInputData.Text = "1";
            // 
            // txtReadWriteLog
            // 
            txtReadWriteLog.Dock = DockStyle.Right;
            txtReadWriteLog.Location = new Point(228, 26);
            txtReadWriteLog.Name = "txtReadWriteLog";
            txtReadWriteLog.Size = new Size(229, 391);
            txtReadWriteLog.TabIndex = 10;
            txtReadWriteLog.Text = "";
            txtReadWriteLog.WordWrap = false;
            // 
            // numBitAdr
            // 
            numBitAdr.Location = new Point(94, 224);
            numBitAdr.Name = "numBitAdr";
            numBitAdr.Size = new Size(128, 30);
            numBitAdr.TabIndex = 9;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 226);
            label10.Name = "label10";
            label10.Size = new Size(72, 24);
            label10.TabIndex = 8;
            label10.Text = "*位偏移";
            // 
            // numVarCount
            // 
            numVarCount.Location = new Point(94, 188);
            numVarCount.Name = "numVarCount";
            numVarCount.Size = new Size(128, 30);
            numVarCount.TabIndex = 7;
            numVarCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnWritePlc
            // 
            btnWritePlc.Location = new Point(6, 376);
            btnWritePlc.Name = "btnWritePlc";
            btnWritePlc.Size = new Size(216, 34);
            btnWritePlc.TabIndex = 0;
            btnWritePlc.Text = "写入PLC";
            btnWritePlc.UseVisualStyleBackColor = true;
            btnWritePlc.Click += btnWritePlc_Click;
            // 
            // btnReadPlc
            // 
            btnReadPlc.Location = new Point(6, 273);
            btnReadPlc.Name = "btnReadPlc";
            btnReadPlc.Size = new Size(216, 34);
            btnReadPlc.TabIndex = 0;
            btnReadPlc.Text = "读取PLC";
            btnReadPlc.UseVisualStyleBackColor = true;
            btnReadPlc.Click += btnReadPlc_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 343);
            label11.Name = "label11";
            label11.Size = new Size(64, 24);
            label11.TabIndex = 6;
            label11.Text = "写入值";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 190);
            label9.Name = "label9";
            label9.Size = new Size(82, 24);
            label9.TabIndex = 6;
            label9.Text = "读取长度";
            // 
            // numStartByteAdr
            // 
            numStartByteAdr.Location = new Point(94, 114);
            numStartByteAdr.Name = "numStartByteAdr";
            numStartByteAdr.Size = new Size(128, 30);
            numStartByteAdr.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 116);
            label7.Name = "label7";
            label7.Size = new Size(64, 24);
            label7.TabIndex = 6;
            label7.Text = "偏移量";
            // 
            // numDbArea
            // 
            numDbArea.Location = new Point(94, 78);
            numDbArea.Name = "numDbArea";
            numDbArea.Size = new Size(128, 30);
            numDbArea.TabIndex = 7;
            numDbArea.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 80);
            label6.Name = "label6";
            label6.Size = new Size(64, 24);
            label6.TabIndex = 6;
            label6.Text = "程序块";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 153);
            label8.Name = "label8";
            label8.Size = new Size(82, 24);
            label8.TabIndex = 5;
            label8.Text = "读取类型";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 42);
            label5.Name = "label5";
            label5.Size = new Size(82, 24);
            label5.TabIndex = 5;
            label5.Text = "数据类型";
            // 
            // cmbVarType
            // 
            cmbVarType.FormattingEnabled = true;
            cmbVarType.Location = new Point(94, 150);
            cmbVarType.Name = "cmbVarType";
            cmbVarType.Size = new Size(128, 32);
            cmbVarType.TabIndex = 5;
            cmbVarType.Text = "Bit";
            // 
            // cmbDataType
            // 
            cmbDataType.FormattingEnabled = true;
            cmbDataType.Location = new Point(94, 39);
            cmbDataType.Name = "cmbDataType";
            cmbDataType.Size = new Size(128, 32);
            cmbDataType.TabIndex = 5;
            cmbDataType.Text = "DataBlock";
            // 
            // ledMotorState
            // 
            ledMotorState.Location = new Point(102, 124);
            ledMotorState.Name = "ledMotorState";
            ledMotorState.Size = new Size(50, 50);
            ledMotorState.StatusColor = Color.Gray;
            ledMotorState.TabIndex = 8;
            // 
            // ledMobileDeviceState
            // 
            ledMobileDeviceState.Location = new Point(312, 124);
            ledMobileDeviceState.Name = "ledMobileDeviceState";
            ledMobileDeviceState.Size = new Size(50, 50);
            ledMobileDeviceState.StatusColor = Color.Gray;
            ledMobileDeviceState.TabIndex = 8;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(86, 95);
            label12.Name = "label12";
            label12.Size = new Size(82, 24);
            label12.TabIndex = 3;
            label12.Text = "电机状态";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(260, 95);
            label13.Name = "label13";
            label13.Size = new Size(154, 24);
            label13.TabIndex = 3;
            label13.Text = "一维移动设备状态";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtDeviceLog);
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(ledMobileDeviceState);
            groupBox4.Controls.Add(label13);
            groupBox4.Controls.Add(btnCreateMobile);
            groupBox4.Controls.Add(btnCreateMotor);
            groupBox4.Controls.Add(btnAutoReadMobile);
            groupBox4.Controls.Add(btnAutoReadMotor);
            groupBox4.Controls.Add(btnReadMobile);
            groupBox4.Controls.Add(btnReadMotor);
            groupBox4.Controls.Add(ledMotorState);
            groupBox4.Location = new Point(483, 191);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(462, 420);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "设备监控";
            // 
            // txtDeviceLog
            // 
            txtDeviceLog.Dock = DockStyle.Bottom;
            txtDeviceLog.Location = new Point(3, 304);
            txtDeviceLog.Name = "txtDeviceLog";
            txtDeviceLog.Size = new Size(456, 113);
            txtDeviceLog.TabIndex = 9;
            txtDeviceLog.Text = "";
            // 
            // btnCreateMobile
            // 
            btnCreateMobile.Location = new Point(254, 42);
            btnCreateMobile.Name = "btnCreateMobile";
            btnCreateMobile.Size = new Size(166, 34);
            btnCreateMobile.TabIndex = 0;
            btnCreateMobile.Text = "创建移动设备";
            btnCreateMobile.UseVisualStyleBackColor = true;
            btnCreateMobile.Click += btnCreateMobile_Click;
            // 
            // btnCreateMotor
            // 
            btnCreateMotor.Location = new Point(53, 42);
            btnCreateMotor.Name = "btnCreateMotor";
            btnCreateMotor.Size = new Size(148, 34);
            btnCreateMotor.TabIndex = 0;
            btnCreateMotor.Text = "创建电机对象";
            btnCreateMotor.UseVisualStyleBackColor = true;
            btnCreateMotor.Click += btnCreateMotor_Click;
            // 
            // btnAutoReadMobile
            // 
            btnAutoReadMobile.Location = new Point(254, 237);
            btnAutoReadMobile.Name = "btnAutoReadMobile";
            btnAutoReadMobile.Size = new Size(166, 34);
            btnAutoReadMobile.TabIndex = 0;
            btnAutoReadMobile.Text = "自动读写移动设备";
            btnAutoReadMobile.UseVisualStyleBackColor = true;
            btnAutoReadMobile.Click += btnAutoReadMobile_Click;
            // 
            // btnAutoReadMotor
            // 
            btnAutoReadMotor.Location = new Point(53, 237);
            btnAutoReadMotor.Name = "btnAutoReadMotor";
            btnAutoReadMotor.Size = new Size(148, 34);
            btnAutoReadMotor.TabIndex = 0;
            btnAutoReadMotor.Text = "自动读写电机";
            btnAutoReadMotor.UseVisualStyleBackColor = true;
            btnAutoReadMotor.Click += btnAutoReadMotor_Click;
            // 
            // btnReadMobile
            // 
            btnReadMobile.Location = new Point(254, 180);
            btnReadMobile.Name = "btnReadMobile";
            btnReadMobile.Size = new Size(166, 34);
            btnReadMobile.TabIndex = 0;
            btnReadMobile.Text = "读取移动设备";
            btnReadMobile.UseVisualStyleBackColor = true;
            btnReadMobile.Click += btnReadMobile_Click;
            // 
            // btnReadMotor
            // 
            btnReadMotor.Location = new Point(53, 180);
            btnReadMotor.Name = "btnReadMotor";
            btnReadMotor.Size = new Size(148, 34);
            btnReadMotor.TabIndex = 0;
            btnReadMotor.Text = "读取电机";
            btnReadMotor.UseVisualStyleBackColor = true;
            btnReadMotor.Click += btnReadMotor_Click;
            // 
            // timerReadWrite
            // 
            timerReadWrite.Enabled = true;
            timerReadWrite.Interval = 1000;
            timerReadWrite.Tick += timerReadWrite_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(952, 622);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "MainForm";
            Text = "S71500测试程序";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBitAdr).EndInit();
            ((System.ComponentModel.ISupportInitialize)numVarCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStartByteAdr).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDbArea).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnConnPlc;
        private RichTextBox txtConnLog;
        private TextBox txtPlcIp;
        private Label label1;
        private ComboBox cmbPlcRack;
        private ComboBox cmbPlcSlot;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox cmbPLcType;
        private Button btnDisConnPlc;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label6;
        private Label label5;
        private ComboBox cmbDataType;
        private RichTextBox txtReadWriteLog;
        private NumericUpDown numBitAdr;
        private Label label10;
        private NumericUpDown numVarCount;
        private Button btnReadPlc;
        private Label label9;
        private NumericUpDown numStartByteAdr;
        private Label label7;
        private NumericUpDown numDbArea;
        private Label label8;
        private ComboBox cmbVarType;
        private TextBox txtInputData;
        private Button btnWritePlc;
        private Label label11;
        private CustomCircleControl customCircleControl1;
        private CustomCircleControl ledMotorState;
        private CustomCircleControl ledMobileDeviceState;
        private Label label12;
        private Label label13;
        private GroupBox groupBox4;
        private Button btnReadMotor;
        private Button btnCreateMotor;
        private RichTextBox txtDeviceLog;
        private Button btnCreateMobile;
        private Button btnReadMobile;
        private Button btnAutoReadMobile;
        private Button btnAutoReadMotor;
        private System.Windows.Forms.Timer timerReadWrite;
    }
}