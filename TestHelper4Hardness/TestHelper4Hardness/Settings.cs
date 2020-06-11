using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using TestHelper4Hardness.Utils;

namespace TestHelper4Hardness
{
    public partial class Settings : Form
    {
        private IniFiles ini = new IniFiles(Application.StartupPath + @"\settings.ini");
        private MainForm mainForm;
        private String command;
        public Settings(MainForm mainForm,String command="")
        {
            this.command = command;
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (command == "record")
            {
                tabControl1.SelectedTab = tabPage3;
            }
            string[] ArryPort = SerialPort.GetPortNames();
            portsCombox.Items.Clear();
            for (int i = 0; i < ArryPort.Length; i++)
            {
                portsCombox.Items.Add(ArryPort[i]);

            }
            String portComboxSelected = ini.IniReadValue("设置", "portSelected");
            if(!portComboxSelected.Equals(""))
               portsCombox.SelectedItem =portComboxSelected;

            String parityComboxSelected = ini.IniReadValue("设置", "parity");
            if (!parityComboxSelected.Equals(""))
                parityCombox.SelectedItem = parityComboxSelected;
            String stopBitsComboxSelected = ini.IniReadValue("设置", "stopBits");
            if (!stopBitsComboxSelected.Equals(""))
                stopBitsCombox.SelectedItem = stopBitsComboxSelected;

            String dataBitComboxSelected = ini.IniReadValue("设置", "dataBits");
            if (!dataBitComboxSelected.Equals(""))
                dataBitCombox.SelectedItem = dataBitComboxSelected;

            String baudRateComboxSelected = ini.IniReadValue("设置", "baudRate");
            if (!baudRateComboxSelected.Equals(""))
                baudRateCombox.SelectedItem = baudRateComboxSelected;


            String folderPath = ini.IniReadValue("输出设置", "folderPath");
            if (!folderPath.Equals(""))
                DataFolder.Text = folderPath;

            String exportType = ini.IniReadValue("输出设置", "exportType");
            if (!exportType.Equals(""))
                exportTypeCombox.SelectedItem = exportType;

            String recordCode = ini.IniReadValue("记录设置", "recordCode");
            if (!recordCode.Equals(""))
                recordCodeTextBox.Text = recordCode;

            String settingMachineText = ini.IniReadValue("记录设置", "settingMachines");
            if (!settingMachineText.Equals(""))
                settingMachines.Text = settingMachineText;

            String sampleHardnessText = ini.IniReadValue("记录设置", "sampleHardness");
            if (!sampleHardnessText.Equals(""))
                sampleHardnessTextbox.Text = sampleHardnessText;

            String stdMinValue = ini.IniReadValue("记录设置", "stdMin");
            if (!stdMinValue.Equals(""))
                stdMin.Text = stdMinValue;

            String stdMaxValue = ini.IniReadValue("记录设置", "stdMax");
            if (!stdMaxValue.Equals(""))
                stdMax.Text = stdMaxValue;
            String separator3 = ini.IniReadValue("记录设置", "separator3");
            if (!separator3.Equals(""))
                separator3TextBox.Text = separator3;
            String separator4 = ini.IniReadValue("记录设置", "separator4");
            if (!separator4.Equals(""))
                separator4TextBox.Text = separator4;
            String separator5 = ini.IniReadValue("记录设置", "separator5");
            if (!separator5.Equals(""))
                separator5TextBox.Text = separator5;
        }

        private void portsCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("设置", "portSelected", ((ComboBox)sender).SelectedItem.ToString());
        }

        private void parityCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("设置", "parity", ((ComboBox)sender).SelectedItem.ToString());
        }

        private void stopBitsCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("设置", "stopBits", ((ComboBox)sender).SelectedItem.ToString());
        }

        private void dataBitCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("设置", "dataBits", ((ComboBox)sender).SelectedItem.ToString());
        }

        private void baudRateCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("设置", "baudRate", ((ComboBox)sender).SelectedItem.ToString());
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.restartCom();
            mainForm.setStdValue();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String folderPath = Util.OpenSelectFolderDialog(this);
            if (folderPath.Equals("0"))
            {
                MessageBox.Show("请选择数据存储文件夹");
            }
            else if (folderPath.Equals("-1"))
            {
                DataFolder.Text = "";
            }
            else
            {
                DataFolder.Text = folderPath;
                ini.IniWriteValue("输出设置", "folderPath", folderPath);
            }
        }

        private void recordCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("记录设置", "recordCode", ((TextBox)sender).Text);
        }

        private void settingMachines_TextChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("记录设置", "settingMachines", ((TextBox)sender).Text);//设置试验机列表
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(Util.IsNumeric(((TextBox)sender).Text))
            {
                ini.IniWriteValue("记录设置", "stdMin", ((TextBox)sender).Text);//设置试验机列表
            }
            else
            {
                ((TextBox)sender).Text = "";
                MessageBox.Show("必须输入数字", "警告");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Util.IsNumeric(((TextBox)sender).Text))
            {
                    ini.IniWriteValue("记录设置", "stdMax", ((TextBox)sender).Text);//设置试验机列表
            }
            else
            {
                ((TextBox)sender).Text = "";
                MessageBox.Show("必须输入数字", "警告");
            }
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Double.Parse(stdMax.Text) - Double.Parse(stdMin.Text) <= 0)
            {
                MessageBox.Show("最大值必须大于最小值", "提示");
                e.Cancel = true;
            }
        }

        private void sampleHardnessTextbox_TextChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("记录设置", "sampleHardness", ((TextBox)sender).Text);//设置硬度参数列表
        }

        private void exportTypeCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("输出设置", "exportType", exportTypeCombox.SelectedItem.ToString());
        }

        private void separator3TextBox_TextChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("记录设置", "separator3", separator3TextBox.Text.ToString());
        }

        private void separator4TextBox_TextChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("记录设置", "separator4", separator4TextBox.Text.ToString());
        }

        private void separator5TextBox_TextChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("记录设置", "separator5", separator5TextBox.Text.ToString());
        }
    }
}
