using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using GameEngine;

namespace GameLogic
{
    public abstract class Enemy : GameObject
    {

        private int heath, damage;
        private Vector2 speed;
        public Vector2 startPos;

        /// <summary>
        /// Тип врага до декарирования.
        /// </summary>
        public Type BasicType { get; protected set; }

        public Enemy(Vector2 startPos)
        {
            Health = 5;
            Speed = Vector2.Zero;
            BasicType = this.GetType();
        }

    }
}
