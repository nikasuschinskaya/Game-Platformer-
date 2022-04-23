using GameEngine;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class HorizontalEnemy : Enemy
    {
        Enemy enemy;
        public HorizontalEnemy(Enemy enemy, Vector2 startPos)
        {
            this.position = startPos;
            this.enemy = enemy;
            this.sprite = ContentPipe.LoadTexture("snail_move.png");
        }
        public override void Move()
        {
            base.Move();
        }
    }
}
