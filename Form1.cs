using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace c_compiler
{
    public partial class Form1 : Form
    {
        public bool Lexical = false;
        public bool Grammar = false;
        public bool Optimal = false;
        public bool ASM = false;
        public bool Test = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void button_file_Click(object sender, EventArgs e)
        {
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
        public void show_2(string filename)       //将文件所有的内容显示出来
        {
            //string text = "";
            string []tmp = { };
            try
            {
                tmp = System.IO.File.ReadAllLines(filename, System.Text.Encoding.Default);
            }
            catch (System.ArgumentException)
            {
                System.Windows.Forms.MessageBox.Show("文件名不能为空！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            catch (System.IO.FileNotFoundException)
            {
                System.Windows.Forms.MessageBox.Show("找不到文件，请重新输入路径！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            for (int i = 0; i < tmp.Length; i++)
            {
                textBox_AnalyseGrammar.Text += tmp[i];
            }
            //return text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox_WordResult.Clear();
            textBox_LexicalError.Clear();
            textBox_BinaryResult.Clear();
            textBox_LexicalResult.Clear();
            Process p = Process.Start("LexicalAnalyse.exe");
            p.WaitForExit();    //关键，等待外部程序退出后才能往下执行
            textBox_WordResult.Text = show_1("WordResult.txt");
            textBox_LexicalError.Text = show_1("LexicalError.txt");
            textBox_BinaryResult.Text = show_1("BinaryResult.txt");
            textBox_LexicalResult.Text = show_1("LexicalResult.txt");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_FIRSTSET.Clear();
            textBox_FOLLOWSET.Clear();
            textBox_SELECTSET.Clear();
            textBox_AnalyseTable.Clear();
            Process p = Process.Start("GrammarAnalyse.exe");
            p.WaitForExit();    //关键，等待外部程序退出后才能往下执行
            textBox_FIRSTSET.Text = show_1("FIRSTSET.txt");
            textBox_FOLLOWSET.Text = show_1("FOLLOWSET.txt");
            textBox_SELECTSET.Text = show_1("SELECTSET.txt");
            textBox_AnalyseTable.Text = show_1("AnalyseTable.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox_AnalyseGrammar.Clear();
            textBox_QuotaMary.Clear();
            textBox_VarTable.Clear();
            Process p = Process.Start("SemanticAnalyse.exe");
            p.WaitForExit();    //关键，等待外部程序退出后才能往下执行
            show_2("AnalyseGrammar.txt");
            textBox_QuotaMary.Text = show_1("QuotaMary.txt");
            textBox_VarTable.Text = show_1("VarTable.txt");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textbox_QuotaMary_.Clear();
            textBox_OptimalQuate.Clear();
            Process p = Process.Start("OptimalQuate.exe");
            p.WaitForExit();    //关键，等待外部程序退出后才能往下执行
            textbox_QuotaMary_.Text = show_1("QuotaMary.txt");
            textBox_OptimalQuate.Text = show_1("OptimalQuate.txt");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox_OptimalQuate_.Clear();
            textBox_ASMCode.Clear();
            textBox_VarTable_.Clear();
            Process p = Process.Start("ASMCodeMaker.exe");
            p.WaitForExit();    //关键，等待外部程序退出后才能往下执行
            textBox_VarTable_.Text = show_1("VarTable.txt");
            textBox_OptimalQuate_.Text = show_1("OptimalQuate.txt");
            textBox_ASMCode.Text = show_1("ASMCode.txt");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox_ASMCode_.Clear();
            textBox_ASMCode_.Text = show_1("ASMCode.txt");
            Process p = Process.Start("DOSBox.exe");
            p.WaitForExit();    //关键，等待外部程序退出后才能往下执行
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBoxResult key = System.Windows.MessageBox.Show("确定退出？", "温馨提示", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (key == MessageBoxResult.Yes)
            {
                System.Environment.Exit(0);
            }
            else if (key == MessageBoxResult.No)
            {
                System.Windows.MessageBox.Show("返回");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
