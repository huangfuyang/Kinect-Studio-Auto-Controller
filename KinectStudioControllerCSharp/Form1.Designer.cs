namespace KinectStudioControllerCSharp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_OpenXEDFile = new System.Windows.Forms.Button();
            this.btn_Run = new System.Windows.Forms.Button();
            this.lbl_connect = new System.Windows.Forms.Label();
            this.lbl_XedFile = new System.Windows.Forms.Label();
            this.btn_LoadTimestamp = new System.Windows.Forms.Button();
            this.lbl_Timestamp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_name = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Test = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_ReadFrame = new System.Windows.Forms.Button();
            this.lbl_FirstFrame = new System.Windows.Forms.Label();
            this.rdb_frame = new System.Windows.Forms.RadioButton();
            this.rdb_timestamp = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(77, 27);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(104, 23);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Start Kinect";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(206, 27);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(87, 23);
            this.btn_Connect.TabIndex = 1;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_OpenXEDFile
            // 
            this.btn_OpenXEDFile.Location = new System.Drawing.Point(77, 73);
            this.btn_OpenXEDFile.Name = "btn_OpenXEDFile";
            this.btn_OpenXEDFile.Size = new System.Drawing.Size(104, 23);
            this.btn_OpenXEDFile.TabIndex = 2;
            this.btn_OpenXEDFile.Text = "Open XED File";
            this.btn_OpenXEDFile.UseVisualStyleBackColor = true;
            this.btn_OpenXEDFile.Click += new System.EventHandler(this.btn_OpenXedFile_Click);
            // 
            // btn_Run
            // 
            this.btn_Run.Location = new System.Drawing.Point(116, 266);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(75, 23);
            this.btn_Run.TabIndex = 3;
            this.btn_Run.Text = "Run";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // lbl_connect
            // 
            this.lbl_connect.AutoSize = true;
            this.lbl_connect.Location = new System.Drawing.Point(314, 32);
            this.lbl_connect.Name = "lbl_connect";
            this.lbl_connect.Size = new System.Drawing.Size(83, 12);
            this.lbl_connect.TabIndex = 4;
            this.lbl_connect.Text = "Not connected";
            // 
            // lbl_XedFile
            // 
            this.lbl_XedFile.AutoSize = true;
            this.lbl_XedFile.Location = new System.Drawing.Point(204, 78);
            this.lbl_XedFile.Name = "lbl_XedFile";
            this.lbl_XedFile.Size = new System.Drawing.Size(89, 12);
            this.lbl_XedFile.TabIndex = 5;
            this.lbl_XedFile.Text = "TODO: Xed File";
            // 
            // btn_LoadTimestamp
            // 
            this.btn_LoadTimestamp.Location = new System.Drawing.Point(74, 207);
            this.btn_LoadTimestamp.Name = "btn_LoadTimestamp";
            this.btn_LoadTimestamp.Size = new System.Drawing.Size(107, 23);
            this.btn_LoadTimestamp.TabIndex = 6;
            this.btn_LoadTimestamp.Text = "Load Timestamp";
            this.btn_LoadTimestamp.UseVisualStyleBackColor = true;
            this.btn_LoadTimestamp.Click += new System.EventHandler(this.btn_LoadTimestamp_Click);
            // 
            // lbl_Timestamp
            // 
            this.lbl_Timestamp.AutoSize = true;
            this.lbl_Timestamp.Location = new System.Drawing.Point(204, 212);
            this.lbl_Timestamp.Name = "lbl_Timestamp";
            this.lbl_Timestamp.Size = new System.Drawing.Size(107, 12);
            this.lbl_Timestamp.TabIndex = 7;
            this.lbl_Timestamp.Text = "No Timestamp File";
            this.lbl_Timestamp.Click += new System.EventHandler(this.lbl_Timestamp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "select signer";
            // 
            // cbb_name
            // 
            this.cbb_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_name.FormattingEnabled = true;
            this.cbb_name.Items.AddRange(new object[] {
            "Micheal",
            "Aaron",
            "Anita"});
            this.cbb_name.Location = new System.Drawing.Point(77, 165);
            this.cbb_name.Name = "cbb_name";
            this.cbb_name.Size = new System.Drawing.Size(87, 20);
            this.cbb_name.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "step1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "step2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "step3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "step4";
            // 
            // btn_Test
            // 
            this.btn_Test.Location = new System.Drawing.Point(272, 266);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(75, 23);
            this.btn_Test.TabIndex = 14;
            this.btn_Test.Text = "test";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "step5";
            // 
            // btn_ReadFrame
            // 
            this.btn_ReadFrame.Location = new System.Drawing.Point(77, 121);
            this.btn_ReadFrame.Name = "btn_ReadFrame";
            this.btn_ReadFrame.Size = new System.Drawing.Size(104, 23);
            this.btn_ReadFrame.TabIndex = 16;
            this.btn_ReadFrame.Text = "Load Frame Data";
            this.btn_ReadFrame.UseVisualStyleBackColor = true;
            this.btn_ReadFrame.Click += new System.EventHandler(this.btn_ReadFrame_Click);
            // 
            // lbl_FirstFrame
            // 
            this.lbl_FirstFrame.AutoSize = true;
            this.lbl_FirstFrame.Location = new System.Drawing.Point(206, 126);
            this.lbl_FirstFrame.Name = "lbl_FirstFrame";
            this.lbl_FirstFrame.Size = new System.Drawing.Size(11, 12);
            this.lbl_FirstFrame.TabIndex = 17;
            this.lbl_FirstFrame.Text = "0";
            // 
            // rdb_frame
            // 
            this.rdb_frame.AutoSize = true;
            this.rdb_frame.Checked = true;
            this.rdb_frame.Location = new System.Drawing.Point(74, 237);
            this.rdb_frame.Name = "rdb_frame";
            this.rdb_frame.Size = new System.Drawing.Size(53, 16);
            this.rdb_frame.TabIndex = 18;
            this.rdb_frame.TabStop = true;
            this.rdb_frame.Text = "frame";
            this.rdb_frame.UseVisualStyleBackColor = true;
            // 
            // rdb_timestamp
            // 
            this.rdb_timestamp.AutoSize = true;
            this.rdb_timestamp.Location = new System.Drawing.Point(133, 237);
            this.rdb_timestamp.Name = "rdb_timestamp";
            this.rdb_timestamp.Size = new System.Drawing.Size(77, 16);
            this.rdb_timestamp.TabIndex = 19;
            this.rdb_timestamp.TabStop = true;
            this.rdb_timestamp.Text = "timestamp";
            this.rdb_timestamp.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 301);
            this.Controls.Add(this.rdb_timestamp);
            this.Controls.Add(this.rdb_frame);
            this.Controls.Add(this.lbl_FirstFrame);
            this.Controls.Add(this.btn_ReadFrame);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Test);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbb_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Timestamp);
            this.Controls.Add(this.btn_LoadTimestamp);
            this.Controls.Add(this.lbl_XedFile);
            this.Controls.Add(this.lbl_connect);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.btn_OpenXEDFile);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.btn_Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_OpenXEDFile;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.Label lbl_connect;
        private System.Windows.Forms.Label lbl_XedFile;
        private System.Windows.Forms.Button btn_LoadTimestamp;
        private System.Windows.Forms.Label lbl_Timestamp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbb_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_ReadFrame;
        private System.Windows.Forms.Label lbl_FirstFrame;
        private System.Windows.Forms.RadioButton rdb_frame;
        private System.Windows.Forms.RadioButton rdb_timestamp;
    }
}

