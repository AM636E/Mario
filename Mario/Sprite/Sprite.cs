using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Mario
{
    public enum ConflictType
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        NONE,
    }

    public  abstract class Sprite
    {
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

      /*  public bool IsConflictedLeft(Sprite s)
        {
            return (UpRightX >= s.X && UpRightX <= s.UpRightX);
        }

        public bool IsConflictedRight(Sprite s)
        {
            return (X >= s.UpRightX && X <= s.X);
        }
        */
        /*public bool IsUp(Rectangle r)
        {
            int distance = Math.Abs(r.Y - this.Y);
        }*/

        public void CheckConflict(Sprite s)
        {
            
        }
    }
}