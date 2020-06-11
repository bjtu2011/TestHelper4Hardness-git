namespace TestHelper4Hardness
{
    partial class Settings
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.parityCombox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataBitCombox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stopBitsCombox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.baudRateCombox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.portsCombox = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.exportTypeCombox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.DataFolder = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.sampleHardnessTextbox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.stdMax = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.stdMin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.settingMachines = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.recordCodeTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.separator3TextBox = new System.Windows.Forms.TextBox();
            this.separator4TextBox = new System.Windows.Forms.TextBox();
            this.separator5TextBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(500, 307);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.parityCombox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dataBitCombox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.stopBitsCombox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.baudRateCombox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.portsCombox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(492, 281);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "串口设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "校验位：";
            // 
            // parityCombox
            // 
            this.parityCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parityCombox.FormattingEnabled = true;
            this.parityCombox.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this.parityCombox.Location = new System.Drawing.Point(104, 160);
            this.parityCombox.Name = "parityCombox";
            this.parityCombox.Size = new System.Drawing.Size(121, 20);
            this.parityCombox.TabIndex = 8;
            this.parityCombox.SelectedIndexChanged += new System.EventHandler(this.parityCombox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "数据位：";
            // 
            // dataBitCombox
            // 
            this.dataBitCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataBitCombox.FormattingEnabled = true;
            this.dataBitCombox.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.dataBitCombox.Location = new System.Drawing.Point(104, 124);
            this.dataBitCombox.Name = "dataBitCombox";
            this.dataBitCombox.Size = new System.Drawing.Size(121, 20);
            this.dataBitCombox.TabIndex = 6;
            this.dataBitCombox.SelectedIndexChanged += new System.EventHandler(this.dataBitCombox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "停止位：";
            // 
            // stopBitsCombox
            // 
            this.stopBitsCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stopBitsCombox.FormattingEnabled = true;
            this.stopBitsCombox.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.stopBitsCombox.Location = new System.Drawing.Point(104, 88);
            this.stopBitsCombox.Name = "stopBitsCombox";
            this.stopBitsCombox.Size = new System.Drawing.Size(121, 20);
            this.stopBitsCombox.TabIndex = 4;
            this.stopBitsCombox.SelectedIndexChanged += new System.EventHandler(this.stopBitsCombox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "波特率：";
            // 
            // baudRateCombox
            // 
            this.baudRateCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudRateCombox.FormattingEnabled = true;
            this.baudRateCombox.Items.AddRange(new object[] {
            "1200",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "43000",
            "57600",
            "76800",
            "115200",
            "128000",
            "230400",
            "256000",
            "460800",
            "921600",
            "1382400"});
            this.baudRateCombox.Location = new System.Drawing.Point(104, 52);
            this.baudRateCombox.Name = "baudRateCombox";
            this.baudRateCombox.Size = new System.Drawing.Size(121, 20);
            this.baudRateCombox.TabIndex = 2;
            this.baudRateCombox.SelectedIndexChanged += new System.EventHandler(this.baudRateCombox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口号：";
            // 
            // portsCombox
            // 
            this.portsCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portsCombox.FormattingEnabled = true;
            this.portsCombox.Location = new System.Drawing.Point(104, 16);
            this.portsCombox.Name = "portsCombox";
            this.portsCombox.Size = new System.Drawing.Size(121, 20);
            this.portsCombox.TabIndex = 0;
            this.portsCombox.SelectedIndexChanged += new System.EventHandler(this.portsCombox_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.exportTypeCombox);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.DataFolder);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(492, 281);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "输出设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // exportTypeCombox
            // 
            this.exportTypeCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exportTypeCombox.FormattingEnabled = true;
            this.exportTypeCombox.Items.AddRange(new object[] {
            "pdf",
            "xlsx",
            "csv",
            "html"});
            this.exportTypeCombox.Location = new System.Drawing.Point(101, 47);
            this.exportTypeCombox.Name = "exportTypeCombox";
            this.exportTypeCombox.Size = new System.Drawing.Size(121, 20);
            this.exportTypeCombox.TabIndex = 4;
            this.exportTypeCombox.SelectedIndexChanged += new System.EventHandler(this.exportTypeCombox_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "导出格式：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "记录保存路径：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DataFolder
            // 
            this.DataFolder.Enabled = false;
            this.DataFolder.Location = new System.Drawing.Point(101, 11);
            this.DataFolder.Name = "DataFolder";
            this.DataFolder.Size = new System.Drawing.Size(283, 21);
            this.DataFolder.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.separator5TextBox);
            this.tabPage3.Controls.Add(this.separator4TextBox);
            this.tabPage3.Controls.Add(this.separator3TextBox);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.sampleHardnessTextbox);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.stdMax);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.stdMin);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.settingMachines);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.recordCodeTextBox);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(492, 281);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "记录设置";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // sampleHardnessTextbox
            // 
            this.sampleHardnessTextbox.Location = new System.Drawing.Point(81, 92);
            this.sampleHardnessTextbox.Name = "sampleHardnessTextbox";
            this.sampleHardnessTextbox.Size = new System.Drawing.Size(311, 21);
            this.sampleHardnessTextbox.TabIndex = 9;
            this.sampleHardnessTextbox.TextChanged += new System.EventHandler(this.sampleHardnessTextbox_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "硬度参数：";
            // 
            // stdMax
            // 
            this.stdMax.Location = new System.Drawing.Point(264, 134);
            this.stdMax.Name = "stdMax";
            this.stdMax.Size = new System.Drawing.Size(130, 21);
            this.stdMax.TabIndex = 7;
            this.stdMax.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(229, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "到";
            // 
            // stdMin
            // 
            this.stdMin.Location = new System.Drawing.Point(81, 134);
            this.stdMin.Name = "stdMin";
            this.stdMin.Size = new System.Drawing.Size(130, 21);
            this.stdMin.TabIndex = 5;
            this.stdMin.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "正常值范围：";
            // 
            // settingMachines
            // 
            this.settingMachines.Location = new System.Drawing.Point(81, 50);
            this.settingMachines.Name = "settingMachines";
            this.settingMachines.Size = new System.Drawing.Size(311, 21);
            this.settingMachines.TabIndex = 3;
            this.settingMachines.TextChanged += new System.EventHandler(this.settingMachines_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "试验机号：";
            // 
            // recordCodeTextBox
            // 
            this.recordCodeTextBox.Location = new System.Drawing.Point(81, 8);
            this.recordCodeTextBox.Name = "recordCodeTextBox";
            this.recordCodeTextBox.Size = new System.Drawing.Size(311, 21);
            this.recordCodeTextBox.TabIndex = 1;
            this.recordCodeTextBox.TextChanged += new System.EventHandler(this.recordCodeTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "记录编号：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 178);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "间隔符（3个采样点）：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 212);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(131, 12);
            this.label14.TabIndex = 11;
            this.label14.Text = "间隔符（4个采样点）：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 243);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(131, 12);
            this.label15.TabIndex = 12;
            this.label15.Text = "间隔符（5个采样点）：";
            // 
            // separator3TextBox
            // 
            this.separator3TextBox.Location = new System.Drawing.Point(145, 174);
            this.separator3TextBox.Name = "separator3TextBox";
            this.separator3TextBox.Size = new System.Drawing.Size(130, 21);
            this.separator3TextBox.TabIndex = 13;
            this.separator3TextBox.TextChanged += new System.EventHandler(this.separator3TextBox_TextChanged);
            // 
            // separator4TextBox
            // 
            this.separator4TextBox.Location = new System.Drawing.Point(145, 208);
            this.separator4TextBox.Name = "separator4TextBox";
            this.separator4TextBox.Size = new System.Drawing.Size(130, 21);
            this.separator4TextBox.TabIndex = 14;
            this.separator4TextBox.TextChanged += new System.EventHandler(this.separator4TextBox_TextChanged);
            // 
            // separator5TextBox
            // 
            this.separator5TextBox.Location = new System.Drawing.Point(145, 241);
            this.separator5TextBox.Name = "separator5TextBox";
            this.separator5TextBox.Size = new System.Drawing.Size(130, 21);
            this.separator5TextBox.TabIndex = 15;
            this.separator5TextBox.TextChanged += new System.EventHandler(this.separator5TextBox_TextChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 330);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox portsCombox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox parityCombox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dataBitCombox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox stopBitsCombox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox baudRateCombox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox DataFolder;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox recordCodeTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox settingMachines;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox stdMax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox stdMin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox sampleHardnessTextbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox exportTypeCombox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox separator5TextBox;
        private System.Windows.Forms.TextBox separator4TextBox;
        private System.Windows.Forms.TextBox separator3TextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}