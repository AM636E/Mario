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
        public String BitmapPath { get; set; }

        public Bitmap Image { get { return bitmap; } }

        public BitMapSprite()
        {
            bitmap = new Bitmap(1, 1);
            position = new Point();
        }

        public BitMapSprite(string path)
        {
            BitmapPath = path;
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

        public BitMapSprite(string path, Point position, int width, int height)
            :this(position,path)
        {
            this.width = width;
            this.height = height;
        }

        public void FillRectangle(Graphics g)
        {
            TextureBrush tb = new TextureBrush(this.bitmap);

            g.FillRectangle(tb, this.Rectangle);
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(bitmap, position);
        }
    }
}
