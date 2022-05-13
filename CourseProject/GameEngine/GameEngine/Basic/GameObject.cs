using OpenTK;
using System.Drawing;

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
        public Vector2 Position { get; set; }

        /// <summary>
        /// Размер.
        /// </summary>
        public Vector2 size;

        /// <summary>
        /// Прямоугольник столкновения.
        /// </summary>
        public RectangleF ColRec
        {
            get
            {
                return new RectangleF(Position.X - size.X / 2.0f, Position.Y - size.Y / 2.0f, size.X, size.Y);
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
        public GameObject()
        {
            this.Position = Vector2.Zero;
            this.size = Vector2.Zero;
        }
    }
}
