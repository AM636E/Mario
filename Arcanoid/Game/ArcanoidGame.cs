using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Arcanoid.Game
{
    class ArcanoidGame
    {
        private Graphics _graphics;
        private Form _canvas;

        public ArcanoidGame(int width, int height)
        {
            _canvas = new Form();

            _canvas.Width = width;
            _canvas.Height = height;

            Application.Run(_canvas);
        }
    }
}
