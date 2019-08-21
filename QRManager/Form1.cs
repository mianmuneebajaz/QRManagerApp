using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            qRManager = new QRManager();
        }
        QRManager qRManager;
        private void Form1_Load(object sender, EventArgs e)
        {
            previewImg.Image = imageList1.Images[0];

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Preview

            try
            {
                var r = qRManager.ToQR(TextTbox.Text);
                 if (r != null)
                {
                    previewImg.Image = r;
                }
                else
                {
                    previewImg.Image = imageList1.Images[0];
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    previewImg.Image.Save(sfd.FileName+".jpeg", ImageFormat.Jpeg);
                }
            }
        }

        private void PreviewImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        TextTbox.Text = qRManager.Read(ofd.FileName);
                        var img = System.Drawing.Image.FromFile(ofd.FileName);
                        if (img != null)
                        {
                            previewImg.Image = img;
                        }
                        else
                        {
                            previewImg.Image = imageList1.Images[0];
                        }
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void TextTbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveToolStripMenuItem_Click(sender, e);
            }
        }
    }
}
