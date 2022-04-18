using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public abstract class GameObject
    {
        public int LivesCount
        {
            get;
            set;
        }
        
        public int Health
        {
            get;
            set;
        }

        public Vector2 Speed
        {
            get;
            set;
        }

    }
}
