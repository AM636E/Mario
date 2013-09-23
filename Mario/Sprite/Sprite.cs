using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Mario
{
    public  abstract class Sprite
    {
        public event EventHandler NeedUpdateTrue;

        protected Point position;
        protected int width;
        protected int height;

        public int X { get { return position.X; } set { position.X = value; } }
        public int Y { get { return position.Y; } set { position.Y = value; } }
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public int UpRightX { get { return X + width; } }
        public int DownRightX { get { return Y + height + width; } }

        public Point UpRight { get { return new Point(UpRightX, Y); } }
        public Point DownRight { get { return new Point(DownRightX, Y + height); } }

        protected bool isNeedUpdate;

        public bool NeedUpdate
        {
            get { return isNeedUpdate; }
            set
            {
                isNeedUpdate = value;
                if (isNeedUpdate == true && NeedUpdateTrue != null)
                {
                    NeedUpdateTrue(this, EventArgs.Empty);
                }
            }
        }

        public Sprite()
        {
            position = new Point();
            isNeedUpdate = false;
        }

        public Sprite(Point position, int width, int height):
            this()
        {
            this.position = position;
            this.height = height;
            this.width = width;
        }

        public abstract void Draw(Graphics g);
    }
}