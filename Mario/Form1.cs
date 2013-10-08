﻿using System;
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
        Player _p;
        
        public Form1()
        {
            InitializeComponent();

            _p = new Player(@"Images/Mario.jpg", 100);
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
