using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    /// <summary>
    /// Работа с блоками.
    /// </summary>
    public class Block
    {
        private BlockType type;
        private int posX, posY;
        private bool solid, platform, ladder, spike, key;

        /// <summary>
        /// Тип блока.
        /// </summary>
        public BlockType Type
        {
            get { return type; }
        }

        /// <summary>
        /// Позиция X.
        /// </summary>
        public int X
        {
            get { return posX; }
        }

        /// <summary>
        /// Позиция Y.
        /// </summary>
        public int Y
        {
            get { return posY; }
        }

        /// <summary>
        /// Является ли объект непроходимым.
        /// </summary>
        public bool IsSolid
        {
            get { return solid; }
        }

        /// <summary>
        /// Является ли объект платформой.
        /// </summary>
        public bool IsPlatform
        {
            get { return platform; }
        }

        /// <summary>
        /// Является ли объект лестницой.
        /// </summary>
        public bool IsLadder
        {
            get { return ladder; }
        }

        /// <summary>
        /// Является ли объект шипом.
        /// </summary>
        public bool IsSpike
        {
            get { return spike; }
        }

        /// <summary>
        /// Является ли объект ключом.
        /// </summary>
        public bool IsKey
        {
            get { return key; }
        }

        /// <summary>
        /// Конструктор блоков.
        /// </summary>
        /// <param name="type">Тип блока.</param>
        /// <param name="x">Координата x.</param>
        /// <param name="y">Координата y.</param>
        public Block(BlockType type, int x, int y)
        {
            this.posX = x;
            this.posY = y;
            this.type = type;

            this.ladder = false;
            this.solid = false;
            this.platform = false;
            this.spike = false;
            this.key = false;

            GetBlockType();
        }

        /// <summary>
        /// Метод получения типа блока.
        /// </summary>
        public void GetBlockType()
        {
            switch (type)
            {
                case BlockType.Solid:
                    this.solid = true;
                    break;
                case BlockType.Platform:
                    this.platform = true;
                    break;
                case BlockType.Ladder:
                    this.ladder = true;
                    break;
                case BlockType.LadderPlatform:
                    this.ladder = true;
                    this.platform = true;
                    break;
                case BlockType.SpikeUp:
                    this.spike = true;
                    break;
                case BlockType.SpikeDown:
                    this.spike = true;
                    break;
                case BlockType.SpikeLeft:
                    this.spike = true;
                    break;
                case BlockType.SpikeRight:
                    this.spike = true;
                    break;
                case BlockType.Key:
                    this.key = true;
                    break;
            }
        }
    }
}
