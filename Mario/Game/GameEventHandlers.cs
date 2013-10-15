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
            if (_collisionPrizes != CollisionType.LEFT && _collisionEnemies != CollisionType.LEFT && _player.X >= 0)
            {
                _player.MoveLeft();
            }
        }

        public void EnemyMoveHandler(Object sender, EventArgs e)
        {
            Enemy enemy = sender as Enemy;

            enemy.Collision = enemy.CheckCollision(_prizes);

            if (enemy.Collision == CollisionType.NONE && enemy.X > 0)
            {
                enemy.MoveRight();
            }
            else
            {
                _player.Dead();
            }
        }

        private void _gameLoop_Tick(object sender, EventArgs e)
        {
            _player.CollisionPrizes = _player.CheckCollision(_enemyes);
            _player.CollisionEnemies = _player.CheckCollision(_prizes);

            _enemyes[0].FireMoveRightEvent();

            _player.Move();
            _canvas.Invalidate();
        }

        delegate void Jumper();
        Jumper _jump;

        void _player_Jumping(object sender, EventArgs e)
        {
            _player.CollisionPrizes = _player.CheckCollision(_enemyes);
            _player.CollisionEnemies = _player.CheckCollision(_prizes);
            _jump();

            if (_player.Y < 200)
            {
                _jump = _player.MoveDown;
            }
            console.log(_collisionEnemies);
            console.log(_collisionPrizes);
            if (_player.IsSpriteBottom(_ground) || _player.IsSpriteBottom(_prizes[0]))
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
