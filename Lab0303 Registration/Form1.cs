using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0303_Registration
{
    public partial class Form1 : Form
    {
        apd621_60011212153Entities context = new apd621_60011212153Entities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StudentBindingSource.DataSource = context.Student.ToList();
            subjectBindingSource.DataSource = context.Subject.ToList();
            registerBindingSource.DataSource = context.Subject.ToList();
        }
    }
}
