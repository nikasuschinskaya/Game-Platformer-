using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class HorizontalEnemy : EnemyDecorator
    {
        public HorizontalEnemy(Enemy enemy) : base(enemy)
        {
        }
    }
}
