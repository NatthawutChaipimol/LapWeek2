using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Lab0704
{
    public partial class Form1 : Form
    {
        Post[] posts;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string jsonResult = client
                .DownloadString("https://jsonplaceholder.typicode.com/posts");
            var serializer = new JavaScriptSerializer();
            posts = (Post[])serializer.Deserialize(jsonResult,typeof(Post[]));
            foreach (Post post in posts) {
                comboBox1.Items.Add(post.id);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox1.Text;
            foreach (Post post in posts) {
                if (post.id == int.Parse(id))
                {
                    textBox1.Text = post.userId.ToString();
                    textBox2.Text = post.title;
                    textBox3.Text = post.body;
                }
            }
        }
    }
}
