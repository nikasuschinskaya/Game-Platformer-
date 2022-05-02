using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using OpenTK;

namespace GameLogic
{
    /// <summary>
    /// Декоратор врагов.
    /// </summary>
    public abstract class EnemyDecorator : Enemy
    {
        /// <summary>
        /// Враг.
        /// </summary>
        protected Enemy enemy;

        /// <summary>
        /// Инициализатор.
        /// </summary>
        /// <param name="enemy">Враг.</param>
        /// <param name="startPos">Начальная позиция.</param>

        public EnemyDecorator(Enemy enemy, Vector2 startPos) : base(startPos)
        {
            this.enemy = enemy;
        }
    }
}
