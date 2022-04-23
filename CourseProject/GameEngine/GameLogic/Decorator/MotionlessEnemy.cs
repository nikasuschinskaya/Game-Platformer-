using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class MotionlessEnemy : EnemyDecorator
    {
        public MotionlessEnemy(Vector2 position, Enemy enemy) : base(position, enemy)
        {
            
        }
    }
}
