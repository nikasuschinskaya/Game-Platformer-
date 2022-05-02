using GameEngine;
using OpenTK;

namespace GameLogic
{
    /// <summary>
    /// Стреляющий враг.
    /// </summary>
    public class ShootEnemy : EnemyDecorator
    {
        /// <summary>
        /// Инициализация стреляющего врага.
        /// </summary>
        /// <param name="enemy">Враг.</param>
        /// <param name="startPos">Начальная позиция.</param>
        public ShootEnemy(Enemy enemy, Vector2 startPos) : base(enemy, startPos)
        {
            this.position = startPos;
            this.enemy = enemy;
            this.sprite = ContentPipe.LoadTexture("fly.png");
        }

        /// <summary>
        /// Метод обновления.
        /// </summary>
        /// <param name="level">Уровень.</param>
        public override void Update(ref Level level)
        {
            base.Update(ref level);
        }
    }
}
