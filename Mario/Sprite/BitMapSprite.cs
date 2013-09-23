using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Mario
{
    public class BitMapSprite : Sprite
    {
        protected Bitmap bitmap;

        public Bitmap Image { get { return bitmap; } }

        public BitMapSprite()
        {
            bitmap = new Bitmap(0, 0);
            position = new Point();
        }

        public BitMapSprite(string path)
        {
            this.bitmap = new Bitmap(path);
            this.width = bitmap.Width;
            this.height = bitmap.Height;
        }

        public BitMapSprite(Point position, string path)
            :this( path )
        {
            this.position = position;
        }

        public BitMapSprite(Bitmap bitmap, Point position)
        {
            this.position = position;
            this.width = bitmap.Width;
            this.height = bitmap.Height;
            this.bitmap = bitmap;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(bitmap, position);
        }
    }
}
