using System;
using System.Windows.Forms;
using TestHelper4Hardness.Utils;

namespace TestHelper4Hardness
{
    public partial class About : Form
    {
        private IniFiles ini = new IniFiles(Application.StartupPath + @"\settings.ini");
        private MainForm mainForm;

        public About(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            String temp = ini.IniReadValue("特殊设置", "isRandomModify");
            if (temp == "" || temp == "0")
            {
                ini.IniWriteValue("特殊设置", "isRandomModify", "1");
                MessageBox.Show("调整模式开启成功");
            }
            else
            {
                ini.IniWriteValue("特殊设置", "isRandomModify", "0");
                MessageBox.Show("调整模式关闭");
            }
        }

        private void About_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.openSpecialFunction();
        }
    }
}