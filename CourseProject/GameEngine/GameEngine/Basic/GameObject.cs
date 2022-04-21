using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    /// <summary>
    /// Игровой объект.
    /// </summary>
    public abstract class GameObject
    {
        /// <summary>
        /// Количество жизней.
        /// </summary>
        public int LivesCount
        {
            get;
            set;
        }

        /// <summary>
        /// Очки здоровья для одной жизни.
        /// </summary>
        public int Health
        {
            get;
            set;
        }

        /// <summary>
        /// Инициализатор игрового объекта.
        /// </summary>
        public GameObject()
        {
            this.LivesCount = 1;
            this.Health = 0;
        }

    }
}
