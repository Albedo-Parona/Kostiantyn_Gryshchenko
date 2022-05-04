using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    [TestFixture]
    public class Task_3
    {
        public int digital_root(int input)
        {
            if (input < 10)
            {
                return input;
            }
            char[] strInput = input.ToString().ToCharArray();
            int sum = 0;
            for (int i = 0; i < strInput.Length; i++)
            {
                sum += Int32.Parse((strInput[i].ToString()));
            }
            return digital_root(sum);
        }
        [Test]
        public void digital_root1()
        {
            Assert.AreEqual(7, digital_root(16));
        }
        [Test]
        public void digital_root2()
        {
            Assert.AreEqual(6, digital_root(942));
        }
        [Test]
        public void digital_root3()
        {
            Assert.AreEqual(6, digital_root(132189));
        }
        [Test]
        public void digital_root4()
        {
            Assert.AreEqual(2, digital_root(493193));
        }
        [Test]
        public void digital_root5()
        {
            Assert.AreEqual(0, digital_root(0));
        }
    }
}
