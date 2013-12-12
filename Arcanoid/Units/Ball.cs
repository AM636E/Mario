using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Common.Sprites;

namespace Mario.Arcanoid.Units
{
    class Ball : Sprite
    {
        private Point _center;
        private int _radius;

        public override int X
        {
            get
            {
                return _center.X;
            }
            set
            {
                _center.X = value;
            }
        }

        public override int Y
        {
            get
            {
                return _center.Y;
            }
            set
            {
                _center.Y = value;
            }
        }

        public int Diameter
        {
            get
            {
                return this._radius * 2;
            }
        }

        public Ball()
            : base()
        {

        }

        public Ball(Point position, int radius)
            : base(position, radius * 2, radius * 2)
        {
            _center = new Point(this.X - radius, this.Y - radius);
            _radius = radius;
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Aqua, 10), X, Y, Diameter, Diameter);
        }
    }
}
