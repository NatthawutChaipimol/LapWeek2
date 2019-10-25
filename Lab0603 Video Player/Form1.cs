using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab0603_Video_Player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.add(new Uri(textBox1.Text).AbsoluteUri);
            axVLCPlugin21.volume = 50;
            axVLCPlugin21.playlist.play();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.togglePause();
        }
    }
}
