using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    /// <summary>
    /// Перечисление TweenType.
    /// </summary>
    public enum TweenType
    {
        /// <summary>
        /// Мгновенный тип.
        /// </summary>
        Instant,
        /// <summary>
        /// Линейный тип.
        /// </summary>
        Linear,
        /// <summary>
        /// Квадратичный тип.
        /// </summary>
        QuadraticInOut,
        /// <summary>
        /// Кубический тип.
        /// </summary>
        CubicInOut,
        /// <summary>
        /// Суперкубический тип.
        /// </summary>
        QuarticOut
    }
}
