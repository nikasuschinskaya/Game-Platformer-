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
            this.size = new Vector2(20, 20);
            this.speed = Vector2.Zero;
            this.position = startPos;
            this.enemy = enemy;
            this.sprite = ContentPipe.LoadTexture("hedgehog_body.png");
        }
        public override void Update(ref Level level)
        {
            if (level.CountOfMEnemy > 180)
            {
                this.size = new Vector2(60, 60);
            }
            else
            {
                this.size = new Vector2(20, 20);
            }
        }
    }
}
