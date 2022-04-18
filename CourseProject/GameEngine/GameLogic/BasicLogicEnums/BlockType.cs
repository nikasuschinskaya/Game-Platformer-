using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    /// <summary>
    /// Тип блока.
    /// </summary>
    public enum BlockType
    {
        /// <summary>
        /// Твердый(непроходимый) объект.
        /// </summary>
        Solid,
        /// <summary>
        /// Пустота.
        /// </summary>
        Empty,
        /// <summary>
        /// Объект-платформа.
        /// </summary>
        Platform,
        /// <summary>
        /// Объект-лестница.
        /// </summary>
        Ladder,
        /// <summary>
        /// Объект-лестница с платформой.
        /// </summary>
        LadderPlatform,
        /// <summary>
        /// Объект-шипы вверх.
        /// </summary>
        SpikeUp,
        /// <summary>
        /// Объект-шипы вниз.
        /// </summary>
        SpikeDown,
        /// <summary>
        /// Объект-шипы влево.
        /// </summary>
        SpikeLeft,
        /// <summary>
        /// Объект-шипы вправо.
        /// </summary>
        SpikeRight,
        /// <summary>
        /// Объект-ключ (переход на новый уровень)
        /// </summary>
        Key,
        /// <summary>
        /// Объект-дверь (игрок побеждает)
        /// </summary>
        Door
    }
}
