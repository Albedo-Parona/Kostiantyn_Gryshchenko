using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace ClassLibrary1
{
    [TestFixture]
    public class Task_2
    {
        public char FirstNonRepeatingLetter(string str)
        {
            string stringHelper = str;
            str = str.ToLower();
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (!((str.Substring(0, i) + str.Substring(i + 1)).Contains(str[i])))
                {
                    return stringHelper[i];
                }
            }
            return ' ';
        }
        [Test]
        public void FirstNonRepeatingLetter1()
        {
            Assert.AreEqual('T', FirstNonRepeatingLetter("sTreSS"));
        }
        [Test]
        public void FirstNonRepeatingLetter2()
        {
            Assert.AreEqual(' ', FirstNonRepeatingLetter("sTreSSret"));
        }
        [Test]
        public void FirstNonRepeatingLetter3()
        {
            Assert.AreEqual('K', FirstNonRepeatingLetter("Kaalluupptt"));
        }
    }
}