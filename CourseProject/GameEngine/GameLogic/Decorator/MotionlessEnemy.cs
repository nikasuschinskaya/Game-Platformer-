using GameEngine;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class MotionlessEnemy : Enemy
    {
        Enemy enemy;
        public MotionlessEnemy(Enemy enemy, Vector2 startPos)
        {
            this.position = startPos;
            this.enemy = enemy;
            this.sprite = ContentPipe.LoadTexture("hedgehog_body.png");
        }
        public override void Move()
        {
            base.Move();
        }
    }
}
