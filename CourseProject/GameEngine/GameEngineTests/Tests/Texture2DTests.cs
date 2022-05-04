using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Tests
{
    /// <summary>
    /// Тестирование создания текстур.
    /// </summary>
    [TestClass()]
    public class Texture2DTests
    {
        /// <summary>
        /// Тестовый метод для создания текстур. 
        /// </summary>
        [TestMethod()]
        public void EqualsTest()
        {
            Texture2D t1 = new Texture2D(1, 1, 1);
            Texture2D t2 = new Texture2D(1, 1, 1);
            Texture2D t3 = new Texture2D(1, 2, 1);
            Texture2D t4 = new Texture2D(1, 2, 3);

            Assert.AreEqual(t1.Equals(t2), true);
            Assert.AreEqual(t1.Equals(t3), false);
            Assert.AreEqual(t1.Equals(t4), false);
        }
    }
}