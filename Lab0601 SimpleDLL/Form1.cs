using SimpleDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0601_SimpleDLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Simple simple = new Simple();
            MessageBox.Show(simple.SayHello(textBox1.Text));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Simple simple = new Simple();
            Student student = simple.GetStudent();
            MessageBox.Show(student+"");
        }
    }
}
