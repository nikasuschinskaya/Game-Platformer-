using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class ShootEnemy : EnemyDecorator
    {
        public ShootEnemy(Vector2 position, Enemy enemy) : base(position, enemy)
        {
        }
    }
}
