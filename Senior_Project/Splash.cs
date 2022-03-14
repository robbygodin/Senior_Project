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

namespace Senior_Project
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            Thread.Sleep(100);
            welcomePB.Visible = true;
            Thread.Sleep(200);
            toPB.Visible = true;
            Thread.Sleep(200);
            robbyPB.Visible = true;
            Thread.Sleep(1000);
            this.Close();
            
        }
    }
}
