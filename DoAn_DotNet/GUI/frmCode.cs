using AForge.Video;
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
namespace DoAn_DotNet.GUI
{
    public partial class frmCode : Form
    {
        public frmCode()
        {
            InitializeComponent();
        }
        MJPEGStream stream;

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (btn_Connect.Text == "Connect")
            {
                stream = new MJPEGStream(txt_url_DroidCam.Text);
                stream.NewFrame += stream_NewFrame;
                stream.Start();
                timer1.Enabled = true;
                timer1.Start();
                btn_Connect.Text = "Disconnect";
            }
            else
            {
                btn_Connect.Text = "Connect";
                timer1.Stop();
                stream.Stop();
            }

        }
        public void stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            pic_cam.Image = bmp;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap img = (Bitmap)pic_cam.Image;
            if (img != null)
            {
                ZXing.BarcodeReader Reader = new ZXing.BarcodeReader();
                Result result = Reader.Decode(img);
                try
                {
                    string decoded = result.ToString().Trim();
                    if (!listBox1.Items.Contains(decoded))
                    {
                        listBox1.Items.Insert(0, decoded);
                    }

                    img.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "");
                }

            }
        }
    }
}
