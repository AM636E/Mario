using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Mario
{
    public enum CollisionType 
    {
        NONE,
        LEFT,
        RIGHT,
        UP,
        BOTTOM,
    }

    public  abstract class Sprite
    {
        public event EventHandler OnNeedUpdate;

        protected Point position;
        protected int width;
        protected int height;

        public Point Position { get { return position; } }
        public int X { get { return position.X; } set { position.X = value; NeedUpdate = true; } }
        public int Y { get { return position.Y; } set { position.Y = value; NeedUpdate = true; } }
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public int UpRightX { get { return X + width; } }
        public int DownRightX { get { return Y + height + width; } }

        public Point UpRight { get { return new Point(UpRightX, Y); } }
        public Point DownRight { get { return new Point(DownRightX, Y + height); } }

        public Rectangle Rectangle { get { return new Rectangle(this.Position, new Size(this.width, this.height)); } }

        protected bool isNeedUpdate;

        public bool NeedUpdate
        {
            get { return isNeedUpdate; }
            set
            {
                isNeedUpdate = value;
                if (value == true && OnNeedUpdate != null)
                {
                    OnNeedUpdate(this, EventArgs.Empty);
                }
            }
        }

        public Sprite()
        {
            position = new Point();
            isNeedUpdate = true;
        }

        public Sprite(Point position, int width, int height):
            this()
        {
            this.position = position;
            this.height = height;
            this.width = width;
        }

        public abstract void Draw(Graphics g);


        public bool IsCollisedUp(Sprite s)
        {
            if (this.Rectangle.IntersectsWith(s.Rectangle) && this.Y >= s.Y)
            {
                return true;
            }

            return false;
        }

        public bool IsCollisedBottom(Sprite s)
        {
            if (this.Rectangle.IntersectsWith(s.Rectangle) && this.Y <= s.Y)
            {
                return true;
            }

            return false;
        }

        public bool IsCollisedRight(Sprite s)
        {
            if (this.Rectangle.IntersectsWith(s.Rectangle) && this.X < s.X)
            {
                return true;
            }

            return false;
        }

        public bool IsCollisedLeft(Sprite s)
        {
            if (this.Rectangle.IntersectsWith(s.Rectangle) && this.X > s.X)
            {
                return true;
            }

            return false;
        }

        public CollisionType Collision(Sprite s)
        {
            if (IsCollisedRight(s))
            {
                return CollisionType.LEFT;
            }
            if (IsCollisedRight(s))
            {
                return CollisionType.RIGHT;
            }

            if (IsCollisedUp(s))
            {
                return CollisionType.UP;
            }

            if (IsCollisedBottom(s))
            {
                return CollisionType.BOTTOM;
            }

            return CollisionType.NONE;
        }
    }
}