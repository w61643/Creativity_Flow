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
    public class TextCheck_UnitTest
    {
        [TestMethod]
        public void TextCheck_Test()
        {
            //arrange
            int var = 1;
            string senderText = "3";

            bool expected = true;

            //act
            bool result = SettingsLogic.TextCheck(ref var, senderText);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}