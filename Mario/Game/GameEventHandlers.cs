using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Mario
{
    partial class Game
    {
        public delegate void CollisionAction();

        private void _player_MovedRight(object sender, EventArgs e)
        {
            if (_collisionPrizes != CollisionType.RIGHT && _collisionEnemies != CollisionType.RIGHT)
            {
                _player.MoveRight();
            }
       }

        private void _player_MovedLeft(object sender, EventArgs e)
        {
            if (_collisionPrizes != CollisionType.LEFT && _collisionEnemies == CollisionType.LEFT && _player.X >= 0)
            {
                _player.MoveLeft();
            }
        }       

        private void _gameLoop_Tick(object sender, EventArgs e)
        {
            _collisionEnemies = _player.CheckCollision(_enemyes);
            _collisionPrizes = _player.CheckCollision(_prizes);
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

        delegate void Jumper();
        Jumper _jump;

        void _player_Jumping(object sender, EventArgs e)
        {
            _jump();

            if(_player.X < 200)
            {
                _jump = _player.MoveDown;
            }
            if(_player.IsSpriteBottom(_ground))
            {
                _jump = _player.MoveUp;
                _player.MotionState = MotionState.NotMoving;
            }
        }

        private void OnUnitNeedUpdate(object sender, EventArgs e)
        {
            Unit u = sender as Unit;
            _mustUpdate.Add(u);
            u.NeedUpdate = false;
        }
    }
}
