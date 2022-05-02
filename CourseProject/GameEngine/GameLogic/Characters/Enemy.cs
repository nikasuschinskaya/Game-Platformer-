using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using GameEngine;
using System.Drawing;

namespace GameLogic
{
    /// <summary>
    /// Базовый класс для врагов.
    /// </summary>
    public class Enemy : GameObject
    {
        /// <summary>
        /// Урон.
        /// </summary>
        public int damage;

        /// <summary>
        /// Спрайт.
        /// </summary>
        public Texture2D sprite;

        /// <summary>
        /// Повернут ли объект вправо, на земли ли.
        /// </summary>
        public bool facingRight, grounded;

        /// <summary>
        /// Инициализация врагов.
        /// </summary>
        /// <param name="startPos">Начальная позиция.</param>
        public Enemy(Vector2 startPos)
        {
            this.position = startPos;
            this.facingRight = false;
            this.grounded = false;
            this.size = new Vector2(20, 30);
        }

        /// <summary>
        /// Отрисовка.
        /// </summary>
        public void Draw()
        {
            RectangleF rec = DrawRec;
            if (!facingRight)
            {
                rec.X += rec.Width;
                rec.Width = -rec.Width;
            }
            Spritebatch.Draw(sprite, rec);
        }

        /// <summary>
        /// Обновление.
        /// </summary>
        /// <param name="level">Уровень.</param>
        public virtual void Update(ref Level level) { }
    }
}
