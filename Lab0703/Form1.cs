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

namespace Lab0703
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string jasonResult = client
                .DownloadString("https://jsonplaceholder.typicode.com/posts/"
                +textBox1.Text);
            // Json => C# = Deserialization
            var serializer = new JavaScriptSerializer();
            Post post = (Post)serializer.Deserialize(jasonResult,typeof(Post));

            textBox2.Text = post.userId.ToString();
            textBox3.Text = post.title;
            textBox4.Text = post.body;
            

        }
    }
}
