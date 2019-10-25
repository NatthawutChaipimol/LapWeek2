using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab0702_Linq_Finding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string url = "https://www.jib.co.th/web/product/readProduct/" + textBox1.Text;
            //XElement cannot used
            //XElement xElement = XElement.Load(url);
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            var html = doc.DocumentNode.Descendants("meta");
            var title = html.Where(m => m.GetAttributeValue("property", "") == "og:title").First();
            textBox2.Text = title.GetAttributeValue("content", "");
            var description = html.Where(m => m.GetAttributeValue("property", "") == "og:description").First();
            textBox3.Text = description.GetAttributeValue("content", "");
            var image = html.Where(m => m.GetAttributeValue("property", "") == "og:image").First();
            pictureBox1.Load(image.GetAttributeValue("content", ""));

            var html2 = doc.DocumentNode.Descendants("span");
            //var pice = html2.Where(m => m.GetDirectInnerText());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "dsdsd \n" +
                          "asadasd";
        }
    }
}
