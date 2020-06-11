namespace TestHelper4Hardness
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.averageTextBox = new System.Windows.Forms.TextBox();
            this.countTextBox = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.richTxtControl1 = new CCWin.SkinControl.RichTxtControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开样本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发送样本数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyAllDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.temperatrueTextbox = new System.Windows.Forms.TextBox();
            this.deviceCombox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sampleNo = new System.Windows.Forms.TextBox();
            this.sampleNameTextbox = new System.Windows.Forms.TextBox();
            this.sampleTypeTextbox = new System.Windows.Forms.TextBox();
            this.productNameTextbox = new System.Windows.Forms.TextBox();
            this.methodNameTextbox = new System.Windows.Forms.TextBox();
            this.sampleHardnessCombox = new System.Windows.Forms.ComboBox();
            this.samplePointNum = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.averageTextBox);
            this.groupBox1.Controls.Add(this.countTextBox);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.richTxtControl1);
            this.groupBox1.Location = new System.Drawing.Point(246, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(917, 610);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据窗口";
            // 
            // averageTextBox
            // 
            this.averageTextBox.Location = new System.Drawing.Point(690, 179);
            this.averageTextBox.Multiline = true;
            this.averageTextBox.Name = "averageTextBox";
            this.averageTextBox.Size = new System.Drawing.Size(221, 423);
            this.averageTextBox.TabIndex = 18;
            // 
            // countTextBox
            // 
            this.countTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.countTextBox.AutoSize = true;
            this.countTextBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.countTextBox.Font = new System.Drawing.Font("微软雅黑", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.countTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.countTextBox.Location = new System.Drawing.Point(693, 44);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(94, 106);
            this.countTextBox.TabIndex = 16;
            this.countTextBox.Text = "0";
            this.countTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(7, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(676, 582);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
            // 
            // richTxtControl1
            // 
            this.richTxtControl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.richTxtControl1.Location = new System.Drawing.Point(690, 22);
            this.richTxtControl1.Name = "richTxtControl1";
            this.richTxtControl1.Size = new System.Drawing.Size(221, 150);
            this.richTxtControl1.TabIndex = 17;
            this.richTxtControl1.Load += new System.EventHandler(this.richTxtControl1_Load);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.关于ToolStripMenuItem,
            this.modifyAllDataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1163, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建记录ToolStripMenuItem,
            this.打开样本ToolStripMenuItem,
            this.发送样本数据ToolStripMenuItem,
            this.导出记录ToolStripMenuItem,
            this.recentToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建记录ToolStripMenuItem
            // 
            this.新建记录ToolStripMenuItem.Name = "新建记录ToolStripMenuItem";
            this.新建记录ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.新建记录ToolStripMenuItem.Text = "新建记录";
            this.新建记录ToolStripMenuItem.Click += new System.EventHandler(this.新建记录ToolStripMenuItem_Click);
            // 
            // 打开样本ToolStripMenuItem
            // 
            this.打开样本ToolStripMenuItem.Name = "打开样本ToolStripMenuItem";
            this.打开样本ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打开样本ToolStripMenuItem.Text = "打开记录";
            this.打开样本ToolStripMenuItem.Click += new System.EventHandler(this.打开样本ToolStripMenuItem_Click);
            // 
            // 发送样本数据ToolStripMenuItem
            // 
            this.发送样本数据ToolStripMenuItem.Name = "发送样本数据ToolStripMenuItem";
            this.发送样本数据ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.发送样本数据ToolStripMenuItem.Text = "发送记录";
            // 
            // 导出记录ToolStripMenuItem
            // 
            this.导出记录ToolStripMenuItem.Name = "导出记录ToolStripMenuItem";
            this.导出记录ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.导出记录ToolStripMenuItem.Text = "导出记录";
            this.导出记录ToolStripMenuItem.Click += new System.EventHandler(this.导出记录ToolStripMenuItem_Click);
            // 
            // recentToolStripMenuItem
            // 
            this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            this.recentToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.recentToolStripMenuItem.Text = "最近的记录";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // modifyAllDataToolStripMenuItem
            // 
            this.modifyAllDataToolStripMenuItem.Name = "modifyAllDataToolStripMenuItem";
            this.modifyAllDataToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.modifyAllDataToolStripMenuItem.Text = "一键调整数据";
            this.modifyAllDataToolStripMenuItem.Click += new System.EventHandler(this.一键调整数据ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 437);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 40);
            this.button1.TabIndex = 12;
            this.button1.Text = "新建记录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.temperatrueTextbox);
            this.groupBox2.Controls.Add(this.deviceCombox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.sampleNo);
            this.groupBox2.Controls.Add(this.sampleNameTextbox);
            this.groupBox2.Controls.Add(this.sampleTypeTextbox);
            this.groupBox2.Controls.Add(this.productNameTextbox);
            this.groupBox2.Controls.Add(this.methodNameTextbox);
            this.groupBox2.Controls.Add(this.sampleHardnessCombox);
            this.groupBox2.Controls.Add(this.samplePointNum);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(12, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 610);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作窗口";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 315);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 22;
            this.label11.Text = "项目：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(41, 562);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 40);
            this.button3.TabIndex = 14;
            this.button3.Text = "导出记录";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(41, 499);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 40);
            this.button2.TabIndex = 13;
            this.button2.Text = "打开记录";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 357);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "样本点数：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "产品标准：";
            this.label7.DoubleClick += new System.EventHandler(this.label7_DoubleClickClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "方法标准：";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "规格型号：";
            this.label5.DoubleClick += new System.EventHandler(this.label5_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "样品名称：";
            this.label4.DoubleClick += new System.EventHandler(this.label4_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "室温：";
            // 
            // temperatrueTextbox
            // 
            this.temperatrueTextbox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.temperatrueTextbox.Location = new System.Drawing.Point(72, 105);
            this.temperatrueTextbox.Name = "temperatrueTextbox";
            this.temperatrueTextbox.Size = new System.Drawing.Size(144, 23);
            this.temperatrueTextbox.TabIndex = 5;
            this.temperatrueTextbox.TextChanged += new System.EventHandler(this.temperatrueTextbox_TextChanged);
            // 
            // deviceCombox
            // 
            this.deviceCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deviceCombox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deviceCombox.FormattingEnabled = true;
            this.deviceCombox.Items.AddRange(new object[] {
            "TH300"});
            this.deviceCombox.Location = new System.Drawing.Point(72, 63);
            this.deviceCombox.Name = "deviceCombox";
            this.deviceCombox.Size = new System.Drawing.Size(144, 22);
            this.deviceCombox.TabIndex = 4;
            this.deviceCombox.SelectedIndexChanged += new System.EventHandler(this.deviceCombox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "试验机号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "样品编号：";
            // 
            // sampleNo
            // 
            this.sampleNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sampleNo.Location = new System.Drawing.Point(72, 20);
            this.sampleNo.Name = "sampleNo";
            this.sampleNo.Size = new System.Drawing.Size(144, 23);
            this.sampleNo.TabIndex = 3;
            this.sampleNo.TextChanged += new System.EventHandler(this.sampleNo_TextChanged);
            // 
            // sampleNameTextbox
            // 
            this.sampleNameTextbox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sampleNameTextbox.Location = new System.Drawing.Point(72, 148);
            this.sampleNameTextbox.Name = "sampleNameTextbox";
            this.sampleNameTextbox.Size = new System.Drawing.Size(144, 23);
            this.sampleNameTextbox.TabIndex = 6;
            this.sampleNameTextbox.TextChanged += new System.EventHandler(this.sampleNameTextbox_TextChanged);
            // 
            // sampleTypeTextbox
            // 
            this.sampleTypeTextbox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sampleTypeTextbox.Location = new System.Drawing.Point(72, 191);
            this.sampleTypeTextbox.Name = "sampleTypeTextbox";
            this.sampleTypeTextbox.Size = new System.Drawing.Size(144, 23);
            this.sampleTypeTextbox.TabIndex = 7;
            this.sampleTypeTextbox.TextChanged += new System.EventHandler(this.sampleTypeTextbox_TextChanged);
            // 
            // productNameTextbox
            // 
            this.productNameTextbox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.productNameTextbox.Location = new System.Drawing.Point(72, 228);
            this.productNameTextbox.Name = "productNameTextbox";
            this.productNameTextbox.Size = new System.Drawing.Size(144, 23);
            this.productNameTextbox.TabIndex = 9;
            this.productNameTextbox.TextChanged += new System.EventHandler(this.productNameTextbox_TextChanged);
            // 
            // methodNameTextbox
            // 
            this.methodNameTextbox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.methodNameTextbox.Location = new System.Drawing.Point(72, 271);
            this.methodNameTextbox.Name = "methodNameTextbox";
            this.methodNameTextbox.Size = new System.Drawing.Size(144, 23);
            this.methodNameTextbox.TabIndex = 10;
            this.methodNameTextbox.TextChanged += new System.EventHandler(this.methodNameTextbox_TextChanged);
            // 
            // sampleHardnessCombox
            // 
            this.sampleHardnessCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sampleHardnessCombox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sampleHardnessCombox.FormattingEnabled = true;
            this.sampleHardnessCombox.Items.AddRange(new object[] {
            "HRA",
            "HRB",
            "HRC",
            "HRW"});
            this.sampleHardnessCombox.Location = new System.Drawing.Point(72, 310);
            this.sampleHardnessCombox.Name = "sampleHardnessCombox";
            this.sampleHardnessCombox.Size = new System.Drawing.Size(144, 22);
            this.sampleHardnessCombox.TabIndex = 21;
            this.sampleHardnessCombox.SelectedIndexChanged += new System.EventHandler(this.sampleHardnessCombox_SelectedIndexChanged);
            // 
            // samplePointNum
            // 
            this.samplePointNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.samplePointNum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.samplePointNum.FormattingEnabled = true;
            this.samplePointNum.Items.AddRange(new object[] {
            "3",
            "4",
            "5"});
            this.samplePointNum.Location = new System.Drawing.Point(72, 352);
            this.samplePointNum.Name = "samplePointNum";
            this.samplePointNum.Size = new System.Drawing.Size(144, 22);
            this.samplePointNum.TabIndex = 11;
            this.samplePointNum.SelectedIndexChanged += new System.EventHandler(this.samplePointNum_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 651);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "实验助手-硬度采集";
            this.MaximumSizeChanged += new System.EventHandler(this.MainForm_MaximumSizeChanged);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开样本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发送样本数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sampleNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox productNameTextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox methodNameTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox sampleTypeTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sampleNameTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox temperatrueTextbox;
        private System.Windows.Forms.ComboBox deviceCombox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox samplePointNum;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label countTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox sampleHardnessCombox;
        private System.Windows.Forms.ToolStripMenuItem 新建记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
        private CCWin.SkinControl.RichTxtControl richTxtControl1;
        private System.Windows.Forms.TextBox averageTextBox;
        private System.Windows.Forms.ToolStripMenuItem modifyAllDataToolStripMenuItem;
    }
}

