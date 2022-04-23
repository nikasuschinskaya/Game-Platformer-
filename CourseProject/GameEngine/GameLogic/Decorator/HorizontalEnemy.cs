using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class HorizontalEnemy : EnemyDecorator
    {
        public HorizontalEnemy(Vector2 position, Enemy enemy) : base(position, enemy)
        {
        }
    }
}
