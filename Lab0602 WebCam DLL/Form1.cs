using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace Lab0602_WebCam_DLL
{
    public partial class Form1 : Form
    {
        FilterInfoCollection webcams;
        VideoCaptureDevice videoIn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webcams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo webcam in webcams) {
                comboBox1.Items.Add(webcam.Name);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int selectedCamIndex = comboBox1.SelectedIndex;
            videoIn = new VideoCaptureDevice(webcams[selectedCamIndex].MonikerString);
            videoSourcePlayer1.VideoSource = videoIn;
            videoSourcePlayer1.Start();
            timer1.Start();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (videoIn != null && videoIn.IsRunning) {
                videoSourcePlayer1.Stop();
                timer1.Stop();
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options.CharacterSet = "UTF-8";
            options.Width = 200;
            options.Height = 130;

            BarcodeWriter writer = new BarcodeWriter();
            writer.Options = options;
            if (radioButton1.Checked)
            {
                writer.Format = BarcodeFormat.CODE_39;
            }
            else {
                writer.Format = BarcodeFormat.QR_CODE;
            }
            var result = writer.Write(textBox1.Text);
            pictureBox1.Image = result;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save("Code.jpg");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            var capture = videoSourcePlayer1.GetCurrentVideoFrame();
            if (capture != null)
            {
                BarcodeReader reader = new BarcodeReader();
                var result = reader.Decode(capture);
                if (result != null) {
                    listBox1.Items.Insert(0, result.Text + " " + result.BarcodeFormat.ToString());
                }
            }
        }
    }
}
