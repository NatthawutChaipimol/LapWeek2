using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0203_SDI_From
{
    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(this);
            form1.Visible = true;
            this.Visible = false;
        }
    }
}
