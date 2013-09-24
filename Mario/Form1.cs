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
        Game _game;
        public Form1()
        {
            InitializeComponent();

            

            _p = new Player(@"D:\GitHub\GDI+\GDI+\bin\Debug\images.jpg", 100);
        }

        Player _p;

        private void _p_MovedLeft(Object sender, EventArgs args)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _game = new Game(this, _p,  1000, 500);
            _game.Start();
            _game.GameLoopInterval = 100;

            this.KeyDown += _game.OnKeyDown;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            _game.UpdateView();
        }
    }
}
