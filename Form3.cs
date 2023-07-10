using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_compiler
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(toolStripButton1.SelectedIndex == 0)     //新建
            {
                textBox_file.ReadOnly = false;
            }
            else
            {
                textBox_file.ReadOnly = true;
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = true;
                fileDialog.Title = "请选择文件";
                fileDialog.Filter = "所有文件(*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = fileDialog.FileName;
                    textBox_file.Clear();
                    textBox_file.Text = show_1(filename);
                }
            }
        }
        public string show_1(string filename)       //将文件所有的内容显示出来
        {
            string text = "";
            try
            {
                text = System.IO.File.ReadAllText(filename, System.Text.Encoding.Default);
            }
            catch (System.ArgumentException)
            {
                System.Windows.Forms.MessageBox.Show("文件名不能为空！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            catch (System.IO.FileNotFoundException)
            {
                System.Windows.Forms.MessageBox.Show("找不到文件，请重新输入路径！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            return text;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
