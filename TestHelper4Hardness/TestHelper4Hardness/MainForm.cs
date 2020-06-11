using Aspose.Cells;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TestHelper4Hardness.Kernel;
using TestHelper4Hardness.Utils;

namespace TestHelper4Hardness
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int SetCursorPos(int x, int y);
        private ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IniFiles ini = new IniFiles(Application.StartupPath + @"\settings.ini");
        private StringBuilder receiveText = new StringBuilder();
        private ComDataManager comDataManager;
        public  SampleModel sampleModel = new SampleModel();

        public MainForm()
        {
            //设置窗体的双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            InitializeComponent();
            Type type = dataGridView1.GetType();
            PropertyInfo pi = type.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi.SetValue(dataGridView1, true, null);
        }
        private void SortAsFileName(ref FileInfo[] arrFi)
        {
            Array.Sort(arrFi, delegate (FileInfo x, FileInfo y) { return y.LastWriteTime.CompareTo(x.LastWriteTime); });
        }
        private Size _beforeDialogSize = new Size();
        private void MainForm_Load(object sender, EventArgs e)
        {
            
            _beforeDialogSize = this.Size;

            //获取最近的项目
            string path = Application.StartupPath+@"\data\";
             DirectoryInfo root = new DirectoryInfo(path);
            FileInfo[] arrFi = root.GetFiles("*.json");
            SortAsFileName(ref arrFi);
            int count = arrFi.Length > 5 ? 5 : arrFi.Length;
            for(int i=0;i< count; i++)
            { 
            ToolStripMenuItem tsmi = new ToolStripMenuItem(arrFi[i].FullName);
                tsmi.Click += loadJson;
                recentToolStripMenuItem.DropDownItems.Add(tsmi);
            }
            //特殊功能开启关闭
            openSpecialFunction();
            unEnabledInput();
            //初始化样本数据
            deviceCombox.DataSource= ini.IniReadValue("记录设置", "settingMachines").Split(',');
            sampleHardnessCombox.DataSource = ini.IniReadValue("记录设置", "sampleHardness").Split(',');
            sampleNo.Text = ini.IniReadValue("样本数据", "sampleNo");
            if (ini.IniReadValue("样本数据", "device") != "")
                deviceCombox.SelectedItem = ini.IniReadValue("样本数据", "device");
            temperatrueTextbox.Text = ini.IniReadValue("样本数据", "temperature");
            sampleNameTextbox.Text = ini.IniReadValue("样本数据", "sampleName");
            sampleTypeTextbox.Text = ini.IniReadValue("样本数据", "sampleType");
            
            productNameTextbox.Text = ini.IniReadValue("样本数据", "productName");
            methodNameTextbox.Text = ini.IniReadValue("样本数据", "methodName");
            if (ini.IniReadValue("样本数据", "sampleHardness") != "")
                sampleHardnessCombox.SelectedItem = ini.IniReadValue("样本数据", "sampleHardness");
            String samplePointNumFromIni = ini.IniReadValue("样本数据", "samplePointNum");
            if (!samplePointNumFromIni.Equals(""))
                samplePointNum.SelectedIndex = Int32.Parse(ini.IniReadValue("样本数据", "samplePointNum"));

            //初始化datagridview
            comDataManager = new ComDataManager(dataGridView1,this);
            setStdValue();
            //初始化端口\
            String portName = "COM1";
            if (ini.IniReadValue("设置", "portSelected") != "")
            {
                portName = ini.IniReadValue("设置", "portSelected");
            }
            if (initCOM())
            {
                this.Text = this.Text + "-" + portName + "打开成功";
            }
            else
            {
                this.Text = this.Text + "-" + portName + "打开失败";
            }
        }
        public void openSpecialFunction()
        {
            //特殊功能是否开启
            if (ini.IniReadValue("特殊设置", "isRandomModify") == "1")
            {
                modifyAllDataToolStripMenuItem.Visible = true;
            }
            else
            {
                modifyAllDataToolStripMenuItem.Visible = false;
            }
        }
        private void loadJson(object sender, EventArgs e)
        {
            loadFromJson(((ToolStripMenuItem)sender).Text);
        }

        //初始化端口函数
        public Boolean initCOM()
        {
            String portName = "COM1";
            if (ini.IniReadValue("设置", "portSelected") != "")
            {
                portName = ini.IniReadValue("设置", "portSelected");
            }
            int baudRate = 9600;
            if (ini.IniReadValue("设置", "baudRate") != "")
            {
                baudRate = Int32.Parse(ini.IniReadValue("设置", "baudRate"));
            }

            int dataBits = 8;
            if (ini.IniReadValue("设置", "dataBits") != "")
            {
                dataBits = Int32.Parse(ini.IniReadValue("设置", "dataBits"));
            }

            StopBits oStopBits = StopBits.One;
            switch (ini.IniReadValue("设置", "stopBits"))
            {
                case "1":
                    oStopBits = StopBits.One;
                    break;

                case "1.5":
                    oStopBits = StopBits.OnePointFive;
                    break;

                case "2":
                    oStopBits = StopBits.Two;
                    break;

                default:
                    oStopBits = StopBits.One;
                    break;
            }

            //无奇偶校验位
            Parity oParity = Parity.None;
            switch (ini.IniReadValue("设置", "parity"))
            {
                case "无":
                    oParity = Parity.None;
                    break;

                case "奇校验":
                    oParity = Parity.Odd;
                    break;

                case "偶校验":
                    oParity = Parity.Even;
                    break;

                default:
                    oParity = Parity.None;
                    break;
            }

            int ReadTimeout = 100;
            int WriteTimeout = -1;
            comHelp = new COMHelper(portName, baudRate, oParity, dataBits, oStopBits, ReadTimeout, WriteTimeout);
            if (!comHelp.IsOpen())
            {
                if (!comHelp.Open())
                {
                    MessageBox.Show("端口打开失败", "提示");
                    //退出
                    return false;
                }
            }
            else
            {
                MessageBox.Show("端口被占用", "提示");
                //退出
                return false;
            }

            comHelp.AddReceiveEventHanlder(comHelp.serialPort_DataReceived);//将接收到数据，处理数据的方法注册进去
            comHelp.ReceiveDataHandler += rds_ReceiveDataHandler;
            return true;
        }

        //重启端口
        public Boolean restartCom()
        {
            try
            {
                if (comHelp.Close() && initCOM())

                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                log.Error(e.ToString());
            }
            return false;
        }

        private COMHelper comHelp;

        //默认
        public decimal stdMinValue = 0;
        public decimal stdMaxValue = 0;
        public void setStdValue()
        {
            String stdMinValueString = ini.IniReadValue("记录设置", "stdMin");
            String stdMaxValueString = ini.IniReadValue("记录设置", "stdMax");
            if ((stdMinValueString != "" && stdMinValue != Decimal.Parse(stdMinValueString)) || (stdMaxValueString != "" && stdMaxValue != Decimal.Parse(stdMaxValueString)))
            {
                stdMinValue = Decimal.Parse(stdMinValueString);
                stdMaxValue = Decimal.Parse(stdMaxValueString);
                //按照新的值进行刷新
                comDataManager.CellValueChanged(dataGridView1, new DataGridViewCellEventArgs(-1, -1));
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            //判断必填信息是否为空
            if (sampleNo.Text.Trim().Equals(""))
            {
                MessageBox.Show(@"样品编号不能为空", "提示");
                return;
            }

            //判断必填信息是否为空
            if (File.Exists("data/" + sampleNo.Text + ".json"))
            {
                if(MessageBox.Show(@"该样品编号已存在记录，是否覆盖？", "提示",MessageBoxButtons.OKCancel)!=DialogResult.OK)
                return;
            }



            //sampleModel信息
            sampleModel.device = deviceCombox.SelectedItem.ToString();
            sampleModel.temperature = temperatrueTextbox.Text;
            sampleModel.sampleType = sampleTypeTextbox.Text;
            sampleModel.sampleProject = sampleHardnessCombox.SelectedItem.ToString();
            sampleModel.sampleNo = sampleNo.Text;
            sampleModel.sampleName = sampleNameTextbox.Text;
            sampleModel.productName = productNameTextbox.Text;
            sampleModel.samplePointNum = samplePointNum.Text;
            sampleModel.methodName = methodNameTextbox.Text;
            sampleModel.sampleHardness = sampleHardnessCombox.SelectedItem.ToString();
            sampleModel.data.Clear();   

            //清空datagridview
        
            if(sampleModel.samplePointNum != "")
            {
                comDataManager.clear();
                comDataManager.initDataGridView(Int32.Parse(sampleModel.samplePointNum));
                
                ////mouse_event(0x0001,this.Left, this.Top, -20, 0);
                ////SetCursorPos(dataGridView1.PointToScreen(dataGridView1.Location).X, dataGridView1.PointToScreen(dataGridView1.Location).Y);
                //MessageBox.Show("新建成功");
                //mouse_event(0x0002,this.Left + groupBox1.Left + dataGridView1.Left, PointToScreen(dataGridView1.Location).Y, - 20, 0);



            }
            //新建txt文件保存原始数据
            Util.write2File("data/" + sampleNo.Text + ".txt", "", System.IO.FileMode.Create, System.IO.FileAccess.Write);
            setCountText(sampleModel.data.Count.ToString());
            Util.write2File("data/" + sampleNo.Text + ".json", Util.ObjToJson<SampleModel>(sampleModel), System.IO.FileMode.Create, System.IO.FileAccess.Write);
            //清空状态变量
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            enabledInput();
        }

        internal void jsonDataDelete(List<Dictionary<string, int>> deletes)
        {
            //存入json
            String dataJson = Util.read2File("data/" + sampleModel.sampleNo + ".json", FileMode.Open, FileAccess.Read);
            if (JsonSplit.IsJson(dataJson))
            {
                sampleModel = Util.JsonToObj<SampleModel>(dataJson);
                List<String> dataTemp = new List<string>();
                for (int i=0;i<sampleModel.data.Count;i++)
                {
                    var Query = from delete in deletes
                                where delete["OrderNum"] == i
                                select delete;
                   
                    if(Query.Count<Dictionary<String,int>>() <=0)
                    {
                        dataTemp.Add(sampleModel.data[i]);
                    }

                }
                sampleModel.data.Clear();
                sampleModel.data.AddRange(dataTemp);
               
                Util.write2File("data/" + sampleModel.sampleNo + ".json", Util.ObjToJson<SampleModel>(sampleModel), System.IO.FileMode.Create, System.IO.FileAccess.Write);
            }
        }

        private delegate void SetDataDelegate(String strComReciveData);

        private void SetData(String strComReciveData)
        {
            if (dataGridView1.InvokeRequired)
            {
                this.BeginInvoke(new SetDataDelegate(SetData), new object[] { strComReciveData });
            }
            else
            {
                //将数据保存到文本中

                //获取数据
                List<String> matchData = Util.getMatchData(strComReciveData, sampleModel.sampleHardness + @":\s+(\d+\.\d)");
                String sampleModelJson = Util.read2File("data/" + sampleModel.sampleNo + ".json", System.IO.FileMode.Open, System.IO.FileAccess.Read);
                sampleModel = Util.JsonToObj<SampleModel>(sampleModelJson);
                sampleModel.data.AddRange(matchData);
                setCountText(sampleModel.data.Count.ToString());
               Util.write2File("data/" + sampleModel.sampleNo + ".json", Util.ObjToJson<SampleModel>(sampleModel), System.IO.FileMode.Create, System.IO.FileAccess.Write);
                sampleModel.data.Clear();
                //将数据按照样本点数划分
                //String[,] data = Util.dataFormat(matchData, 3 + Int32.Parse(ini.IniReadValue("样本数据", "samplePointNum")));
                comDataManager.addData(matchData);
                
               
                receiveText.Length = 0;
            }
        }

        private void rds_ReceiveDataHandler(String strComReciveData)
        {
            try
            {
                Thread.Sleep(200);
                receiveText.Append(strComReciveData);
                //判断是否结束
                if (comHelp.isComplete())
                {
                    if(!button1.Enabled)
                    { 
                    Util.write2File("data/" + sampleModel.sampleNo + ".txt", receiveText.ToString(), System.IO.FileMode.Append, System.IO.FileAccess.Write);
                    SetData(receiveText.ToString());
                    }
                    else
                    {
                        receiveText.Length = 0;
                        comHelp.ClearDataInBuffer();
                    }
                }

                //清空缓存
                // comHelp.ClearDataInBuffer();
            }
            catch (Exception ex)
            {
                log.Debug(ex.ToString());
                Thread.Sleep(200);
            }
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings setting = new Settings(this);
            setting.ShowDialog();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About(this);
            about.ShowDialog();
        }

        private void samplePointNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            //存入ini
            ini.IniWriteValue("样本数据", "samplePointNum", ((ComboBox)sender).SelectedIndex.ToString());
            
            //存入json
            if (sampleModel.sampleNo != "")
            {
                String dataJson = Util.read2File("data/" + sampleModel.sampleNo + ".json", FileMode.Open, FileAccess.Read);
                if (JsonSplit.IsJson(dataJson))
                {
                    sampleModel = Util.JsonToObj<SampleModel>(dataJson);
                    sampleModel.samplePointNum = ((ComboBox)sender).SelectedItem.ToString();
                    //如果当前datagridview中有数据，则重新排列gridview
                    if (comDataManager != null)
                        comDataManager.resetData(Int32.Parse(sampleModel.samplePointNum), sampleModel.data);
                    Util.write2File("data/" + sampleModel.sampleNo + ".json", Util.ObjToJson<SampleModel>(sampleModel), System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    sampleModel.data.Clear();
                    System.GC.Collect();
                }

              
            }
        }

        private void sampleNo_TextChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("样本数据", "sampleNo", ((TextBox)sender).Text);
        }

        private void temperatrueTextbox_TextChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("样本数据", "temperature", ((TextBox)sender).Text);
            updateDataJsonFile(sampleModel.sampleType, "temperature", ((TextBox)sender).Text);
        }

        private void methodNameTextbox_TextChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("样本数据", "methodName", ((TextBox)sender).Text);
            updateDataJsonFile(sampleModel.sampleType, "methodName", ((TextBox)sender).Text);
        }

        private void productNameTextbox_TextChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("样本数据", "productName", ((TextBox)sender).Text);
            updateDataJsonFile(sampleModel.sampleType, "productName", ((TextBox)sender).Text);
        }

        private void sampleTypeTextbox_TextChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("样本数据", "sampleType", ((TextBox)sender).Text);
            updateDataJsonFile(sampleModel.sampleType, "sampleType", ((TextBox)sender).Text);
        }
        //硬度参数变化时
        private void sampleHardnessCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //存入ini
                ini.IniWriteValue("样本数据", "sampleHardness", ((ComboBox)sender).SelectedItem.ToString());
                if (sampleModel.sampleNo != "")
                {
                    //存入json
                    String dataJson = Util.read2File("data/" + sampleModel.sampleNo + ".json", FileMode.Open, FileAccess.Read);
                    if (JsonSplit.IsJson(dataJson))
                    {
                        sampleModel = Util.JsonToObj<SampleModel>(dataJson);
                        sampleModel.sampleHardness = ((ComboBox)sender).SelectedItem.ToString();
                        sampleModel.sampleProject= ((ComboBox)sender).SelectedItem.ToString();
                        //获取数据
                        List<String> matchData = Util.getMatchData(Util.read2File("data/" + sampleModel.sampleNo + ".txt", FileMode.Open, FileAccess.Read), sampleModel.sampleHardness + @":\s+(\d+\.\d)");
                        sampleModel.data = matchData;
                        setCountText( sampleModel.data.Count.ToString());
                        //如果当前datagridview中有数据，则重新排列gridview
                        if (comDataManager != null)
                            comDataManager.resetData(Int32.Parse(sampleModel.samplePointNum), sampleModel.data);
                        Util.write2File("data/" + sampleModel.sampleNo + ".json", Util.ObjToJson<SampleModel>(sampleModel), System.IO.FileMode.Create, System.IO.FileAccess.Write);
                        sampleModel.data.Clear();
                        System.GC.Collect();
                    }
              
                }
            }
            catch (Exception err)
            {
                log.Error(err.ToString());
                MessageBox.Show("项目切换失败", "提示");
            }
        }

        //设备变化时
        private void deviceCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("样本数据", "device", ((ComboBox)sender).SelectedItem.ToString());
            updateDataJsonFile(sampleModel.sampleType, "device", ((ComboBox)sender).SelectedItem.ToString());
        }
        //项目变化时
        private void sampleProject_TextChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("样本数据", "sampleProject", ((TextBox)sender).Text);
            updateDataJsonFile(sampleModel.sampleType, "sampleProject", ((TextBox)sender).Text);
        }

        private void sampleNameTextbox_TextChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("样本数据", "sampleName", ((TextBox)sender).Text);
            updateDataJsonFile(sampleModel.sampleType, "sampleName", ((TextBox)sender).Text);
        }

        /**
         * 更新json数据文件
         * */
        private void updateDataJsonFile(String sampleNo, String key, String value)
        {
            if (sampleModel.sampleNo != "")
            {
                String dataJson = Util.read2File("data/" + sampleModel.sampleNo + ".json", FileMode.Open, FileAccess.Read);
                if (JsonSplit.IsJson(dataJson))
                {
                    sampleModel = Util.JsonToObj<SampleModel>(dataJson);
                    switch (key)
                    {
                        case "sampleType":
                            sampleModel.sampleType = value;
                            break;
                        case "device":
                            sampleModel.device = value;
                            break;
                        case "sampleProject":
                            sampleModel.sampleProject = value;
                            break;
                        case "sampleName":
                            sampleModel.sampleName = value;
                            break;
                        case "productName":
                            sampleModel.productName = value;
                            break;
                        case "methodName":
                            sampleModel.methodName = value;
                            break;
                        case "temperature":
                            sampleModel.temperature = value;
                            break;
                    }

                    Util.write2File("data/" + sampleModel.sampleNo + ".json", Util.ObjToJson<SampleModel>(sampleModel), System.IO.FileMode.Create, System.IO.FileAccess.Write);
                }
            }
        }

        //导出按钮点击

        private void button3_Click(object sender, EventArgs e)
        {

            //生成报告
            String separator = " ";
            switch (sampleModel.samplePointNum)
            {
                case "3":
                    separator = ini.IniReadValue("记录设置", "separator3").Replace("&nbsp;", " ");
                    break;
                case "4":
                    separator = ini.IniReadValue("记录设置", "separator4").Replace("&nbsp;", " ");;
                    break;
                case "5":
                    separator= ini.IniReadValue("记录设置", "separator5").Replace("&nbsp;", " ");
                    break;
                default:

                    break; 

            }

            //根据数据数量确定excel 文件数
            String dataJson = Util.read2File("data/" + sampleModel.sampleNo + ".json", FileMode.Open, FileAccess.Read);
            if (!JsonSplit.IsJson(dataJson)) { MessageBox.Show("请新建记录！", "提示"); return; }
            sampleModel = Util.JsonToObj<SampleModel>(dataJson);
            int excelNum = (int)Math.Ceiling((decimal)sampleModel.data.Count / (decimal)(40 * Int32.Parse(sampleModel.samplePointNum)));
            //循环excel 填入数据
            String[][] insertData = Util.dataFormat(sampleModel.data, Int32.Parse(sampleModel.samplePointNum));

            List<String> averages = new List<string>();
            if (insertData == null) { MessageBox.Show("无数据！", "提示"); return; }
            Workbook combineWorkbook = new Workbook();
            Worksheet sheet;
            int mark = 0;
            for (int i = 0; i < excelNum; i++)
            {
                try
                {
                    //打开excel文件
                    using (FileStream fs = File.OpenRead("model/template.xls"))
                    {
                        Workbook workbook = new Workbook(fs);
                        if (workbook == null) { return; }
                        sheet = workbook.Worksheets[0];
                        //填入表头数据
                       
                        sheet.Cells.Rows[1][0].Value = ini.IniReadValue("记录设置", "recordCode");
                        sheet.Cells.Rows[1][9].Value = @"       " + (i + 1);//编号
                        sheet.Cells.Rows[2][2].Value = sampleModel.sampleNo;//委托编号
                         autoFontSize(sampleModel.sampleNo, sheet.Cells.Rows[2][2],46,1000);
                        sheet.Cells.Rows[2][5].Value = sampleModel.device;//试验机号
                        autoFontSize(sampleModel.device, sheet.Cells.Rows[2][5], 46,153);
                        sheet.Cells.Rows[2][9].Value = sampleModel.temperature;//温度
                        sheet.Cells.Rows[3][2].Value = sampleModel.sampleName;//样品名称
                        autoFontSize(sampleModel.sampleName, sheet.Cells.Rows[3][2], 46,1000);
                        sheet.Cells.Rows[3][7].Value = sampleModel.sampleType;//规格型号
                        autoFontSize(sampleModel.sampleType, sheet.Cells.Rows[3][7], 46,1000);
                        sheet.Cells.Rows[4][2].Value = sampleModel.sampleProject;//检验项目
                        autoFontSize(sampleModel.sampleProject, sheet.Cells.Rows[4][2], 46,1000);
                        sheet.Cells.Rows[4][5].Value = sampleModel.productName;//产品标准
                        autoFontSize(sampleModel.productName, sheet.Cells.Rows[4][5], 46,96);
                        sheet.Cells.Rows[4][8].Value = sampleModel.methodName;//方法标准
                        autoFontSize(sampleModel.methodName, sheet.Cells.Rows[4][8], 46,1000);
                        sheet.Cells.Rows[5][1].Value = "读数("+sampleModel.sampleHardness+")";
                        sheet.Cells.Rows[5][6].Value = "读数(" + sampleModel.sampleHardness + ")";
                        //填入试验数据
                        int row = 6;
                        int col = 1;
                        int max = insertData.Length > (i + 1) * 40 ? (i + 1) * 40 : insertData.Length;
                        for (int cur = mark; cur < max; cur++)
                        {
                            sheet.Cells.Rows[row][col].Value = String.Join(separator, insertData[cur]);
                            sheet.Cells.Rows[row][col + 3].Value = (Util.sum(insertData[cur],3) / 3).ToString("0.0");
                            averages.Add((Util.sum(insertData[cur], 3) / 3).ToString("0.0"));
                            if (row == 25)
                            {
                                row = 6;
                                col = 6;
                            }
                            else
                            {
                                row++;
                            }
                            mark++;
                        }
                        combineWorkbook.Combine(workbook);
                    }
                }
                catch (Exception err)
                {
                    log.Error(err.ToString());
                    MessageBox.Show("导出失败,详情请查看日志", "提示");
                    return;
                }
            }
            sampleModel.data.Clear();
            insertData = null;
            //pdf合并excel文件，删除excel文件

            //保存目标PDF文件

            if (combineWorkbook != null)
            {
                try
                {
                    String folderPath = ini.IniReadValue("输出设置", "folderPath") + @"\";
                    if (!Directory.Exists(folderPath))
                        folderPath = Application.StartupPath + @"\output\";
                    String exportType = ini.IniReadValue("输出设置", "exportType");
                    switch(exportType)
                    {
                        case "pdf":
                            combineWorkbook.Save(folderPath + sampleModel.sampleNo + ".pdf", Aspose.Cells.SaveFormat.Pdf);
                            break;
                        case "xlsx":
                            combineWorkbook.Save(folderPath + sampleModel.sampleNo + ".xlsx", Aspose.Cells.SaveFormat.Xlsx);
                            break;
                        case "csv":
                            combineWorkbook.Save(folderPath + sampleModel.sampleNo + ".csv", Aspose.Cells.SaveFormat.CSV);
                            break;
                        case "html":
                            combineWorkbook.Save(folderPath + sampleModel.sampleNo + ".html", Aspose.Cells.SaveFormat.Html);
                            break;
                        default:
                            combineWorkbook.Save(folderPath + sampleModel.sampleNo + ".pdf", Aspose.Cells.SaveFormat.Pdf);
                            break;
                    }
                    String averageText = String.Join(";", averages.ToArray());
                    averageTextBox.Text = averageText;
                    Util.write2File(folderPath + sampleModel.sampleNo + "-平均值.txt", averageText, FileMode.Create, FileAccess.Write);
                    MessageBox.Show("导出记录成功", "提示");
                    sampleModel = new SampleModel();
                    if(comDataManager!=null)
                    {
                        comDataManager.clear();
                    }
                    countTextBox.Text = "0";
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = false;
                    unEnabledInput();
                }
                catch (Exception err)
                {
                    log.Error(err.ToString());
                    MessageBox.Show("导出记录失败，详情请查看日志", "提示");
                }
            }
        }
        private int autoFontSize(String text,Cell c,int cellHeight,int cellWidth)//自适应改变单元格字体大小
        {
            //单字单号高度 1.6363636364   宽度：0.6507178    单元格：高度42，宽度136
            int fontSize = c.GetStyle().Font.Size;
            int length = Encoding.UTF8.GetBytes(text).Length;
            Style style = c.GetStyle();
            for (int f=fontSize;f>0;f--)
            {
                style.Font.Size = f;
                c.SetStyle(style);
               int height = c.GetHeightOfValue();
                int width = c.GetWidthOfValue();
                if (height< cellHeight && width<cellWidth)
                {
                    return f;
                }
            }
            return 1;

        }
        //打开按钮点击
        private void button2_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();//打开文件对话框
            if (InitialDialog(openFileDialog, "Open"))
            {

                loadFromJson(openFileDialog.FileName);
            }

            
        }
        //加载工程文件
        private void loadFromJson(String path)
        {
            String dataJson = Util.read2File(path, FileMode.Open, FileAccess.Read);
            if (JsonSplit.IsJson(dataJson))
            {
                sampleModel = Util.JsonToObj<SampleModel>(dataJson);
                setInputValue(sampleModel);
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = true;
                enabledInput();
                countTextBox.Text = sampleModel.data.Count.ToString();
                if (comDataManager != null)
                    comDataManager.resetData(Int32.Parse(sampleModel.samplePointNum), sampleModel.data);
                sampleModel.data.Clear();
                System.GC.Collect();
            }
        }
        private void unEnabledInput()
        {
            sampleNo.Enabled = true;
            deviceCombox.Enabled = false;
           temperatrueTextbox.Enabled = false;
            sampleNameTextbox.Enabled = false;
           
            samplePointNum.Enabled = false;
            sampleHardnessCombox.Enabled = false;
            sampleTypeTextbox.Enabled = false;
            productNameTextbox.Enabled = false;
            methodNameTextbox.Enabled = false;
        }
        private void enabledInput()
        {
            sampleNo.Enabled = false;
            deviceCombox.Enabled = true;
            temperatrueTextbox.Enabled = true;
            sampleNameTextbox.Enabled = true;
          
            samplePointNum.Enabled = true;
            sampleHardnessCombox.Enabled = true;
            sampleTypeTextbox.Enabled = true;
            productNameTextbox.Enabled = true;
            methodNameTextbox.Enabled = true;
        }
        
        private void setInputValue(SampleModel sampleModel)
        {
            sampleNo.Text = sampleModel.sampleNo;
            deviceCombox.SelectedItem = sampleModel.device;
            temperatrueTextbox.Text = sampleModel.temperature;
            sampleNameTextbox.Text = sampleModel.sampleName;
           
            samplePointNum.SelectedItem = sampleModel.samplePointNum;
            sampleHardnessCombox.SelectedItem = sampleModel.sampleHardness;
            sampleTypeTextbox.Text = sampleModel.sampleType;
            productNameTextbox.Text = sampleModel.productName;
            methodNameTextbox.Text = sampleModel.methodName;
        }
        //打开选择文件对话框
        private bool InitialDialog(FileDialog fileDialog, string title)
        {
                //默认打开路径
        fileDialog.InitialDirectory = Application.StartupPath+@"\data\";//初始化路径
            fileDialog.Filter = "json files (*.json|*.json";//过滤选项设置，文本文件，所有文件。
            fileDialog.FilterIndex = 1;//当前使用第二个过滤字符串
            fileDialog.RestoreDirectory = true;//对话框关闭时恢复原目录
            fileDialog.Title = title;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 1; i <= fileDialog.FileName.Length; i++)
                {
                    if (fileDialog.FileName.Substring(fileDialog.FileName.Length - i, 1).Equals(@"\"))
                    {
                      
                        return true;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private void 新建记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void 导出记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void 打开样本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void richTxtControl1_Load(object sender, EventArgs e)
        {
         }
        private void resize(Control.ControlCollection controls, float percentWidth, float percentHeight)
        {
            foreach (Control control in controls)
            {
                if (control.HasChildren)
                {
                    resize(control.Controls, percentWidth, percentHeight);
                }
                //按比例改变控件大小
                control.Width = (int)(control.Width * percentWidth);
                control.Height = (int)(control.Height * percentHeight);

                //为了不使控件之间覆盖 位置也要按比例变化
                control.Left = (int)(control.Left * percentWidth);
                control.Top = (int)(control.Top * percentHeight);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
           
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            //控件随窗口大小改变
            Size endSize = this.Size;
            float percentWidth = (float)endSize.Width / _beforeDialogSize.Width;
            float percentHeight = (float)endSize.Height / _beforeDialogSize.Height;
            resize(this.Controls, percentWidth, percentHeight);
            System.Drawing.Font font = new System.Drawing.Font(new FontFamily("微软雅黑"), countTextBox.Font.Size * percentHeight, FontStyle.Bold);
            countTextBox.Font = font;
            _beforeDialogSize = endSize;
        }

   
        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
           
           
        }

        private void MainForm_MaximumSizeChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {

                //控件随窗口大小改变
                Size endSize = this.Size;
                float percentWidth = (float)endSize.Width / _beforeDialogSize.Width;
                float percentHeight = (float)endSize.Height / _beforeDialogSize.Height;
                resize(this.Controls, percentWidth, percentHeight);
                System.Drawing.Font font = new System.Drawing.Font(new FontFamily("微软雅黑"), countTextBox.Font.Size * percentHeight, FontStyle.Bold);
                countTextBox.Font = font;
                _beforeDialogSize = endSize;


            }
        }
        public void setCountText(String text)
        {
            this.countTextBox.Text = text;
        }
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dataGridView1.CancelEdit();
        }
        //产品标准
        private void label7_DoubleClickClick(object sender, EventArgs e)
        {
            
            if (!productNameTextbox.Multiline)
            {
                Size size = productNameTextbox.Size;
                size.Height = size.Height * 5;
                productNameTextbox.Size = size;
               
            }
               
            else
            {
                Size size = productNameTextbox.Size;
                size.Height = size.Height / 5;
                productNameTextbox.Size = size;

            }
            productNameTextbox.Multiline = !productNameTextbox.Multiline;

        }
  
        //规格型号
        private void label5_DoubleClick(object sender, EventArgs e)
        {
            if (!sampleTypeTextbox.Multiline)
            {
                Size size = sampleTypeTextbox.Size;
                size.Height = size.Height * 5;
                sampleTypeTextbox.Size = size;

            }

            else
            {
                Size size = sampleTypeTextbox.Size;
                size.Height = size.Height / 5;
                sampleTypeTextbox.Size = size;

            }
            sampleTypeTextbox.Multiline = !sampleTypeTextbox.Multiline;
        }

        private void label4_DoubleClick(object sender, EventArgs e)
        {
            if (!sampleNameTextbox.Multiline)
            {
                Size size = sampleNameTextbox.Size;
                size.Height = size.Height * 5;
                sampleNameTextbox.Size = size;

            }

            else
            {
                Size size = sampleNameTextbox.Size;
                size.Height = size.Height / 5;
                sampleNameTextbox.Size = size;

            }
            sampleNameTextbox.Multiline = !sampleNameTextbox.Multiline;
        }
        //方法标准
        private void label6_Click(object sender, EventArgs e)
        {
            if (!methodNameTextbox.Multiline)
            {
                Size size = methodNameTextbox.Size;
                size.Height = size.Height * 5;
                methodNameTextbox.Size = size;

            }

            else
            {
                Size size = methodNameTextbox.Size;
                size.Height = size.Height / 5;
                methodNameTextbox.Size = size;

            }
            methodNameTextbox.Multiline = !methodNameTextbox.Multiline;
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }

        private void 一键调整数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(comDataManager!=null)
            {
                comDataManager.modifyAllData();
            }
        }
    }
}