using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0401
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

        private void Button7_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.OrderDate = DateTime.Now;
            order.OrderNumber = "123456";
            order.CustomerId = 2;
            order.TotalAmount = decimal.Parse(label15.Text);

            context.Orders.Add(order);
            int change = context.SaveChanges();
            MessageBox.Show("Change :"+change+" records");

            if (change == 1) {
                foreach (ListViewItem item in listView1.Items) {
                    OrderItem orderItem = new OrderItem();
                    orderItem.OrderId = order.Id;
                    orderItem.ProductId = int.Parse(item.SubItems[0].Text);
                    orderItem.UnitPrice = decimal.Parse(item.SubItems[3].Text);
                    orderItem.Quantity = int.Parse(item.SubItems[2].Text);

                    context.OrderItems.Add(orderItem);
                    context.SaveChanges();
                }
                MessageBox.Show("Save completed");
            }
        }

        private void TabPage3_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            customerBindingSource.DataSource = context.Customers.ToList();
            productBindingSource.DataSource = context.Products.ToList();

            var results = context.Suppliers.OrderBy(s => s.CompanyName)
                .Select(s => new { s.Id, s.CompanyName });

            foreach (var result in results) {
                comboBox2.Items.Add(new ComboBoxItem(result.Id.ToString(), result.CompanyName));
            } 
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.FirstName = textBox2.Text;
            customer.LastName = textBox3.Text;
            customer.City = textBox4.Text;
            customer.Country = textBox5.Text;
            customer.Phone = textBox6.Text;

            context.Customers.Add(customer);
            int change = context.SaveChanges();
            MessageBox.Show("Changr "+change+" records");
            customerBindingSource.DataSource = context.Customers.ToList();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            customerBindingSource.AddNew();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            customerBindingSource.EndEdit();
            int change = context.SaveChanges();
            MessageBox.Show("Change "+change+" records");
            customerBindingSource.DataSource = context.Customers.ToList();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            
            var todel = context.Customers
                .Where(c => c.Id == id).First();

            context.Customers.Remove(todel);
            int change = context.SaveChanges();
            MessageBox.Show("Change "+change+" records");

            customerBindingSource.DataSource = context.Customers.ToList();
        }

        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
            var result = context.Products
                .Where(p => p.Id == id)
                .First();
            textBox12.Text = result.Id.ToString();
            textBox11.Text = result.ProductName;
            textBox10.Text = result.UnitPrice.ToString();
            textBox9.Text = result.Package;
            textBox8.Text = result.IsDiscontinued.ToString();
            comboBox2.Text = result.Supplier.CompanyName;
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(((ComboBoxItem)(comboBox2.SelectedItem)).Value);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ProductName = textBox11.Text;
            product.UnitPrice = decimal.Parse(textBox10.Text);
            product.Package = textBox9.Text;
            product.IsDiscontinued = bool.Parse(textBox8.Text);
            product.SupplierId = int.Parse(((ComboBoxItem)(comboBox2.SelectedItem)).Value);

            context.Products.Add(product);
            int change = context.SaveChanges();
            MessageBox.Show("Change "+change+" records");
            productBindingSource.DataSource = context.Products.ToList();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox12.Text);
            var result = context.Products
                .Where(p => p.Id == id)
                .First();

            result.ProductName = textBox11.Text;
            result.UnitPrice = decimal.Parse(textBox10.Text);
            result.Package = textBox9.Text;
            result.IsDiscontinued = bool.Parse( textBox8.Text);
            result.SupplierId = int.Parse(((ComboBoxItem)(comboBox2.SelectedItem)).Value);

            int change = context.SaveChanges();
            MessageBox.Show("Change "+change+" recoeds");
            productBindingSource.DataSource = context.Products.ToList();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox12.Text);

            var result = context.Products
                .Where(p => p.Id == id)
                .First();

            context.Products.Remove(result);
            int change = context.SaveChanges();
            MessageBox.Show("Change "+change+" records");
            productBindingSource.DataSource = context.Products.ToList();
        }

        private void TextBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) {
                numericUpDown1.Focus();
            }
        }

        private void NumericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) {
                int id = int.Parse(textBox13.Text);
                var result = context.Products.Where(p => p.Id == id).First();
                string[] item = new string[] {
                    result.Id.ToString(),
                    result.ProductName,
                    numericUpDown1.Value.ToString(),
                    result.UnitPrice.ToString(),
                    (result.UnitPrice * numericUpDown1.Value).ToString()
                };
                listView1.Items.Add(new ListViewItem(item));
                double sum = calculateTotal(listView1.Items);
                label15.Text = sum.ToString();
            }
        }

        private double calculateTotal(ListView.ListViewItemCollection items)
        {
            double sum = 0;
            foreach (ListViewItem item in items) {
                sum += double.Parse(item.SubItems[4].Text);
            }
            return sum;
        }
    }

    internal class ComboBoxItem
    {
        public String Value { get; set; } // Supplier ID
        public String Text { get; set; } // Supplier compd name
        public ComboBoxItem(String val, String text)
        {
            Value = val;
            Text = text;
        }
        public override String ToString() {
            return Text;
        }
    }
}
