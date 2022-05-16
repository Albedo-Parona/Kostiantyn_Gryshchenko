using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    [TestFixture]
    public class Task_4
    {

        static int getPairs(List <int> arr, int sum)
        {

            int count = 0;


            for (int i = 0; i < arr.Count; i++)
                for (int j = i + 1; j < arr.Count; j++)
                    if ((arr[i] + arr[j]) == sum)
                        count++;

            return count;
        }
        [Test]
        public void getPairs1()
        {
            Assert.AreEqual(4, getPairs(new List<int>() { 1, 3, 6, 2, 2, 0, 4, 5 }, 5));
        }
        [Test]
        public void getPairs2()
        {
            Assert.AreEqual(0, getPairs(new List<int>() { 1, 3, 0 }, 5));
        }
        [Test]
        public void getPairs3()
        {
            Assert.AreEqual(0, getPairs(new List<int>() { 3 }, 6));
        }
    }
}
