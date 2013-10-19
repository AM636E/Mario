using System;
using System.Windows.Forms;

namespace Mario
{
    partial class Game
    {
        public void OnKeyDown(Object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left)
            {
                _player.MotionState = MotionState.MovingLeft;
            }
            if (e.KeyData == Keys.Right)
            {
                _player.MotionState = MotionState.MovingRight;
            }
            if(e.KeyData == Keys.Up)
            {
                _player.MotionState = MotionState.MovingUp;
            }
            if(e.KeyData == Keys.Space)
            {
                _player = new Player(@"Images/Mario.jpg", 100, new System.Drawing.Point(0, 500 - 200));
            }
            if(e.KeyCode == Keys.D)
            {
                console.log("start debug");
            }
        }

        public void OnKeyUp(Object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right && _player.MotionState == MotionState.MovingLeft)
            {
                _player.MotionState = MotionState.NotMoving;
                return;
            }
            if (e.KeyData == Keys.Left && _player.MotionState == MotionState.Jump)
            {
                _player.MotionState = MotionState.JumpLeft;
                return;
            }
            if (_player.MotionState != MotionState.Jump)
            {
                _player.MotionState = MotionState.NotMoving;
            }
        }
    }
}