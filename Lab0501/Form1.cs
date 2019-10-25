using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0501
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
            orderBindingSource.DataSource = context.Orders.ToList();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var orders = context.Orders;
            CrystalReport11.Database.Tables["Lab0501_Order"].SetDataSource(orders);
            crystalReportViewer1.ReportSource = CrystalReport11;
            crystalReportViewer1.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var orders = context.Orders;
            CrystalReport2.Database.Tables["Lab0501_Order"].SetDataSource(orders);
            crystalReportViewer1.ReportSource = CrystalReport2;
            crystalReportViewer1.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var orders = context.Orders;
            CrystalReport31.Database.Tables["Lab0501_Order"].SetDataSource(orders);
            CrystalReport31.SetParameterValue("Start_Date", dateTimePicker1.Value);
            CrystalReport31.SetParameterValue("end_date", dateTimePicker2.Value);
            crystalReportViewer1.ReportSource = CrystalReport31;
            crystalReportViewer1.Show();
        }
    }
}
