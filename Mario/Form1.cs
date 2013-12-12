using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 5000;
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Invalidate();
            this.Paint += Form1_Paint;
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Ball b = new Ball(new Point(00, 00), 80);

            b.Draw(e.Graphics);
        }
    }
}
