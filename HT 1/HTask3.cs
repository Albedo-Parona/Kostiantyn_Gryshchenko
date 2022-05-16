using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace ClassLibrary1
{
    [TestFixture]
    public class Task_3
    {
        static int DigitalRoot(long num)
        {
            while (num > 9)
            {
                num = num.ToString().ToCharArray().Sum(x => x - '0');
            }

            return (int)num;
        }

        static int digital_root(long num)
        {
            var t = DigitalRoot(num);
            return t;
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
