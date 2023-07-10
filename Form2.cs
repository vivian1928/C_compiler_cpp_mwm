using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c_compiler
{
    public partial class Form2 : Form
    {
        String file_path = Application.StartupPath;
        List<string> file_list;
        List<Button> file_button;
        String file_check = "";
        public Form2()
        {
            InitializeComponent();
            //listBoxMsg.DrawMode = DrawMode.OwnerDrawFixed;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            String path = Application.StartupPath;
            var files = Directory.GetFiles(path, "*.txt");
            foreach (var file in files)
            {
                if (comboBox1.Text.Contains(file))
                {
                    comboBox1.Items.Add(file);

                }
                Console.WriteLine(file);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
