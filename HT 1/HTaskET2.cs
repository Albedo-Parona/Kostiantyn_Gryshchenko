using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    [TestFixture]
    public class Extra_Task_2
    {

        public string IP_address(long k)
        {
            //long x = ((k - k % 256) / 256) % 256); 
            string[] str1 = { ((k - (((k - k%256 - (((k- k % 256) / (256)))%256)/(256*256))%256) - (((k- k % 256) / (256))%256) - k%256)/(256*256*256)).ToString(),
                    (((k - k%256 - (((k- k % 256) / (256)))%256)/(256*256))%256).ToString(),
                    (((k- k % 256) / (256))%256).ToString(),
                    (k%256).ToString()};

            return string.Join('.', str1);
        }
        [Test]
        public void Test_IP1()
        {
            Assert.AreEqual("128.32.10.1", IP_address(2149583361));
        }

        [Test]
        public void Test_IP2()
        {
            Assert.AreEqual("0.0.0.32", IP_address(32));
        }
        [Test]
        public void Test_IP3()
        {
            Assert.AreEqual("0.0.0.0", IP_address(0));
        }
    }
}
