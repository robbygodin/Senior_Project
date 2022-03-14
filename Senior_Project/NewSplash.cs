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
using System.Windows.Media;

namespace Senior_Project
{
    public partial class NewSplash : Form
    {
        public NewSplash()
        {
            InitializeComponent();
        }

        System.Windows.Forms.Timer tmr;

        MediaPlayer neonSound = new MediaPlayer();

        private void NewSplash_Shown(object sender, EventArgs e)
        {
            neonSound.Open(new Uri(Application.StartupPath + "\\Sounds\\Neon Sound Effect.wav"));
            neonSound.Play();
            flasher.RunWorkerAsync();
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 3000;
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();

            Form1 frm1 = new Form1();
            frm1.Show();
            neonSound.Stop();
            this.Close();
        }

        private void flasher_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);

            for (int i = 0; i < 6; i++)
            {
                flasher.ReportProgress(1);
                Thread.Sleep(500);
            }
        }

        private void flasher_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            robby.Visible = !robby.Visible;
        }
    }
}
