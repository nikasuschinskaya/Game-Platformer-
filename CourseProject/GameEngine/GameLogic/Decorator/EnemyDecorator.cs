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

       // private Vector2 startPos;

        protected EnemyDecorator(Vector2 position, Enemy enemy) : base(enemy.position)
        {
            enemy.position = position;
            if (enemy == null)
            {
                throw new ArgumentNullException();
            }

            this.enemy = enemy;
        }


    }
}
