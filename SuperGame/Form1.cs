using SuperGame.DedGameClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && e.Modifiers == Keys.None)
            {
                d_e_d.Jump();
            }
                //MessageBox.Show("Ok");
        }

        D_E_D d_e_d = new D_E_D();

        private void timer1_Tick(object sender, EventArgs e)
        {
            d_e_d.Tick();

            Graphics graphics = this.CreateGraphics();
            d_e_d.Draw(graphics, this.BackColor);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
