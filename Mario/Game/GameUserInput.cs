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
      /*      if (e.KeyData == Keys.Up)
            {
                _player.MotionState = MotionState.Jump;
            }*/
        }

        public void OnKeyUp(Object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left && _player.MotionState == MotionState.Jump)
            {
                 _player.MotionState = MotionState.JumpLeft;
            }
        }
    }
}