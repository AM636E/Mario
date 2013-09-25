using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Mario
{
    partial class Game
    {
        private void _player_MovedRight(object sender, EventArgs e)
        {

        }

        private void _player_MovedLeft(object sender, EventArgs e)
        {
            if (_player.IsCollisedLeft(_mustUpdate[0]) == false)
            {

               // _player.CanMoveLeft = false;
                _player.MoveLeft();
                return;
            }

            _player.CanMoveLeft = true;
        }

        private void _gameLoop_Tick(object sender, EventArgs e)
        {
          //  Logger.Log(_player.MotionState.ToString());
            _player.Move();
            _canvas.Invalidate();           
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyData.ToString());
        }

        private void KeyUp(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyData.ToString());
        }
    }
}
