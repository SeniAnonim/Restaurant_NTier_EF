using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinUIMarla
{
    public partial class ResimForm : Form
    {
        public ResimForm()
        {
            InitializeComponent();
        }
        bool islem = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!islem)
            {
                this.Opacity += 0.005;
            }
            if (this.Opacity == 1.0)
            {
                islem = true;
            }
            if (islem)
            {
                this.Opacity -= 0.005;
                if (this.Opacity == 0)
                {
                    GirisForm fm1 = new GirisForm();
                    fm1.Show();
                    timer1.Enabled = false;
                    this.Hide(); // kapattı
                }
            }
        }

    }
}
