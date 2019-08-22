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

namespace Lab0301_Linq
{
    public partial class Form1 : Form
    {
        StudentProjectEntities context = new StudentProjectEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Lin Query
            var result = from s in context.Students
                         select s;
            dataGridView1.DataSource = result.ToList();
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var result = from s in context.Students
                         where s.student_id == textBox1.Text
                         select s;
            dataGridView1.DataSource = result.ToList();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var result = from s in context.Students
                         select new { ID = s.student_id, Name = s.student_fulname };
            dataGridView1.DataSource = result.ToList();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var result = from s in context.Students
                         orderby s.student_birthday
                         select s;
            dataGridView1.DataSource = result.ToList();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var result = from s in context.Students
                         select s;
            MessageBox.Show("Number of record : "+result.Count());
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button10_Click(object sender, EventArgs e)
        {
            var result = from s in context.Students
                         where s.student_id == textBox3.Text
                         select s;
            result.ToList().ForEach(s => s.student_fulname = textBox7.Text);
            int record = context.SaveChanges();
            MessageBox.Show("Change : "+record+" records");
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var result = from s in context.Students
                         where s.student_id == textBox1.Text
                         && s.student_pssword == textBox2.Text
                         select s;
            dataGridView1.DataSource = result.ToList();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.student_id = textBox4.Text;
            student.student_fulname = textBox8.Text;
            context.Students.Add(student);
            int number = context.SaveChanges();
            MessageBox.Show(number.ToString());
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            var result = from s in context.Students
                         where s.student_id == textBox5.Text
                         select s;
            context.Students.Remove(result.First());
            int records = context.SaveChanges();
            MessageBox.Show(records.ToString());
        }

        private void PictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            var result = from s in context.Students
                         where s.student_id == textBox6.Text
                         select s ;
            result.First().student_image = ImageToByteArray(pictureBox1.Image);
        }
        public byte[] ImageToByteArray(Image image){
            var ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }
    }
}
