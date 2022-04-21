using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using GameEngine;

namespace GameLogic
{
    public abstract class EnemyDecorator : Enemy
    {
        protected Enemy enemy;

        private Vector2 startPos;

        protected EnemyDecorator(Enemy enemy) : base(enemy.position)
        {
            enemy.position = startPos;
            if (enemy == null)
            {
                throw new ArgumentNullException();
            }

            this.enemy = enemy;
        }


    }
}
