using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    [TestFixture]
    public class Task_Extra
    {
        public int nextBigger(int input)
        {
            char[] inputStr = input.ToString().ToCharArray();
            for (int i = inputStr.Length - 1; i > 0; i--)
            {
                if ((int)inputStr[i] > (int)inputStr[i - 1])
                {
                    char tempswap = inputStr[i];
                    inputStr[i] = inputStr[i - 1];
                    inputStr[i - 1] = tempswap;
                    break;
                }
            }
            int result = Int32.Parse(string.Join("", inputStr));
            return result != input ? result : -1;
        }
        [Test]
        public void nextBiggerTest1()
        {
            Assert.AreEqual(2071, nextBigger(2017));
        }
        [Test]
        public void nextBiggerTest2()
        {
            Assert.AreEqual(2202, nextBigger(2022));
        }
        [Test]
        public void nextBiggerTest3()
        {
            Assert.AreEqual(-1, nextBigger(9731));
        }
    }
}
