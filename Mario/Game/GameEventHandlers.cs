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
        void _player_MoveUpEvent(object sender, EventArgs e)
        {
        }

        void _player_MoveDownEvent(object sender, EventArgs e)
        {
            if (_collisionPrizes != CollisionType.NONE)
            {
               // MessageBox.Show(_collisionPrizes.ToString());
            }
        }

        public void EnemyMoveHandler(Object sender, EventArgs e)
        {
            Enemy enemy = sender as Enemy;

            enemy.CollisionGround = enemy.CheckCollision(_prizes);

            if (enemy.CollisionGround == CollisionType.NONE && enemy.X > 0)
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
            _player.CollisionPrizes = _collisionPrizes = _player.CheckCollision(_enemyes);
            _player.CollisionEnemies = _collisionEnemies = _player.CheckCollision(_prizes);
            _player.CollisionGround = (_player.IsSpriteBottom(_ground)) ? CollisionType.GROUND : CollisionType.NONE;

            ActOnList(_enemyes, (enemy) => { enemy.CollisionEnemies = enemy.CheckCollision(_enemyes); enemy.CollisionPrizes = enemy.CheckCollision(_prizes); return enemy; });

            ActOnList(_enemyes, (enemy) => { enemy.MoveRight(); return enemy; });
            _player.Move();
            _player.MoveDown();
            _canvas.Invalidate();
        }


        private delegate Enemy ActOnUnit(Enemy u);

        private List<Enemy> ActOnList(List<Enemy> units, ActOnUnit act)
        {
            List<Enemy> newList = new List<Enemy>(units.Count);

            for (var i = 0; i < units.Count; i++)
            {
                units[i] = act(units[i]);
            }

            return newList;
        }

        delegate void Jumper();
        Jumper _jump;

        void _player_Jumping(object sender, EventArgs e)
        {
            
        }

        private void OnUnitNeedUpdate(object sender, EventArgs e)
        {
            Unit u = sender as Unit;
            _mustUpdate.Add(u);
            u.NeedUpdate = false;
        }
    }
}
