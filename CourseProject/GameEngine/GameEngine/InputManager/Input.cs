using OpenTK;
using OpenTK.Input;
using System.Collections.Generic;

namespace GameEngine
{
    /// <summary>
    /// Работа с событиями клавиатуры.
    /// </summary>
    public class Input
    {
        private static List<Key> keysDown;
        private static List<Key> keysDownLast;

        /// <summary>
        /// Инициализация.
        /// </summary>
        /// <param name="game">Игровое окно.</param>
        public static void Initialize(GameWindow game)
        {
            keysDown = new List<Key>();
            keysDownLast = new List<Key>();

            game.KeyDown += game_KeyDown;
            game.KeyUp += game_KeyUp;
        }

        private static void game_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            while (keysDown.Contains(e.Key))
                keysDown.Remove(e.Key);
        }

        private static void game_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            keysDown.Add(e.Key);
        }

        /// <summary>
        /// Метод обновления.
        /// </summary>
        public static void Update()
        {
            keysDownLast = new List<Key>(keysDown);
        }

        /// <summary>
        /// Метод, возвращающий зажатую клавишу.
        /// </summary>
        /// <param name="key">Нажатая клавиша.</param>
        /// <returns>Нажатая клавиша.</returns>
        public static bool KeyPress(Key key)
        {
            return (keysDown.Contains(key) && !keysDownLast.Contains(key));
        }

        /// <summary>
        /// Метод, возвращающий последнее нажатие клавиши.
        /// </summary>
        /// <param name="key">Нажатая клавиша.</param>
        /// <returns>Нажатая клавиша.</returns>
        public static bool KeyRelease(Key key)
        {
            return (!keysDown.Contains(key) && keysDownLast.Contains(key));
        }

        /// <summary>
        /// Метод, возвращающий нажатую клавишу.
        /// </summary>
        /// <param name="key">Нажатая клавиша.</param>
        /// <returns>Нажатая клавиша.</returns>
        public static bool KeyDown(Key key)
        {
            return keysDown.Contains(key);
        }
    }
}
