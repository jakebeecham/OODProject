using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MCU_Hub;

namespace MCU_Hub.UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLongRandom()
        {
            //Arrange
            MainWindow mainWindow = new MainWindow();
            Random rng = new Random();
            long min = 100000000;
            long max = 9000000000;

            //Act
            var result = mainWindow.LongRandom(min, max, rng);

            //Assert
            Assert.IsInstanceOfType(result, min.GetType());
        }
    }
}
