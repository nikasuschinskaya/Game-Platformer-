using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;

namespace GameEngine
{
    /// <summary>
    /// Тестирование камеры.
    /// </summary>
    [TestClass()]
    public class ViewTests
    {
        /// <summary>
        /// Тестирование линейной функции.
        /// </summary>
        [TestMethod()]
        public void GetLinearTest()
        {
            View view = new View(Vector2.Zero, 0.0, 1.0f);
            float expected = 1f;

            float actual = view.GetLinear(1f);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тестирование квадратичной функции.
        /// </summary>
        [TestMethod()]
        public void GetQuadraticInOutTest()
        {
            View view = new View(Vector2.Zero, 0.0, 1.0f);
            float expected = 1f;

            float actual = view.GetQuadraticInOut(1f);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тестирование кубической функции.
        /// </summary>
        [TestMethod()]
        public void GetCubicInOutTest()
        {
            View view = new View(Vector2.Zero, 0.0, 1.0f);
            float expected = 1f;

            float actual = view.GetCubicInOut(1f);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тестирование суперкубической функции.
        /// </summary>
        [TestMethod()]
        public void GetQuarticOutTest()
        {
            View view = new View(Vector2.Zero, 0.0, 1.0f);
            float expected = 1f;

            float actual = view.GetQuarticOut(1f);

            Assert.AreEqual(expected, actual);
        }
    }
}