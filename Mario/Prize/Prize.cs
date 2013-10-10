using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mario.Interface;
using System.Windows.Forms;

namespace Mario
{
    public class Prize: Unit
    {
        protected int cost;//score that prize add to player score

        public int Cost { get { return cost; } }

        public Prize()
            :base()
        { }

        public Prize(string path)
            : base(path)
        { }

        public Prize(string path, int life)
            : base(path, life)
        { }

        public Prize(string path, int life, System.Drawing.Point p)
            : base(path, life, p)
        { }

        public Prize(System.Drawing.Bitmap bitmap, System.Drawing.Point p)
            : base(bitmap, p)
        { }

        public override void ColliseUp(Player p)
        {
            Dead();
            p.Score += this.Cost;MessageBox.Show("Bottom");
        }

        public override void ColliseBottom(Player p)
        {
            MessageBox.Show("Bottom");
        }

        public override void ColliseRight(Player p) { }
        public override void ColliseLeft(Player p) { }

        public override void Dead()
        {
            console.log(this.ToString(), " dead");
        }
    }
}
