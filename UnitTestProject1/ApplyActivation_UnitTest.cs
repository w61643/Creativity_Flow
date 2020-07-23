using Creativity_Flow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace UnitTests
{
    [TestClass]
    public class ApplyActivation_UnitTest
    {
        [TestMethod]
        public void TextCheck_Test()
        {
            //arrange
            int timeBeforeStart = 1;
            int timeBeforeErasing = 1;
            int erasingSpeed = 1;
            int stopPermissionTime = 1;
            
            bool expected = true;

            //act
            bool result = SettingsLogic.ApplyActivation(ref timeBeforeStart, ref timeBeforeErasing, ref erasingSpeed, ref stopPermissionTime);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
