using GameEngine;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class ShootEnemy : Enemy
    {
        private int Gridsize = 32;
        Enemy enemy;
        public ShootEnemy(Enemy enemy, Vector2 startPos)
        {
            this.speed = Vector2.Zero;
            this.position = startPos;
            this.enemy = enemy;
            this.sprite = ContentPipe.LoadTexture("fly.png");
        }
        public override void Update(ref Level level)
        {
            base.Update(ref level);
        }
    }
}
