using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using GameEngine;

namespace GameLogic
{
    abstract class EnemyDecorator : Enemy
    {
        protected Enemy enemy;
        private Vector2 startPos;

        protected EnemyDecorator(Enemy enemy) : base(enemy.startPos)
        {
            enemy.startPos = startPos;
            if (enemy == null)
            {
                throw new ArgumentNullException();
            }

            this.enemy = enemy;
            //Health = ememy.Health;
        }


    }
}
