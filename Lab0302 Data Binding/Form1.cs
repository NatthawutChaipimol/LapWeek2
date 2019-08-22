using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0302_Data_Binding
{
    public partial class Form1 : Form
    {
        apd621_60011212153Entities context = new apd621_60011212153Entities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           studentBindingSource.DataSource = context.Student.ToList();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            studentBindingSource.EndEdit();// To update local binding source
            int records = context.SaveChanges();
            MessageBox.Show("Change: "+records+" records");
        }
    }
}
