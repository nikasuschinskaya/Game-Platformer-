using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        /// Размер сетки.
        /// </summary>
        public static readonly int Gridsize = 32;

        /// <summary>
        /// Позиция.
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// Размер.
        /// </summary>
        public Vector2 size;

        /// <summary>
        /// Прямоугольник сталкновения.
        /// </summary>
        public RectangleF ColRec
        {
            get
            {
                return new RectangleF(position.X - size.X / 2.0f, position.Y - size.Y / 2.0f, size.X, size.Y);
            }
        }

        /// <summary>
        /// Отрисовка прямоугольника.
        /// </summary>
        public RectangleF DrawRec
        {
            get
            {
                return new RectangleF(ColRec.X - 5, ColRec.Y, ColRec.Width + 10, ColRec.Height);
            }
        }

        /// <summary>
        /// Инициализатор игрового объекта.
        /// </summary>
        //public GameObject()
        //{
        //    this.LivesCount = 1;
        //    this.Health = 0;
        //}
    }
}
