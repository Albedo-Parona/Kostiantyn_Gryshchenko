using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace ClassLibrary1
{

    [TestFixture]

    public class Task_1
    {
        public List<object> GetIntegersFromList(List<object> input)
        {
            var filtered = new List<object>();

            foreach (var word in input)
            {
                if (word is int)
                {
                    filtered.Add(word); ;
                }
            }

            return filtered;
        }
        [Test]
        public void GetIntegersFromListTest1()
        {
            List<object> expected = new List<object>() { 1, 2 };
            List<object> actual = GetIntegersFromList(new List<object>() { 1, 2, 'a', 'b' });
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetIntegersFromListTest2()
        {
            List<object> expected = new List<object>() { 1, 2, 0, 15 };
            List<object> actual = GetIntegersFromList(new List<object>() { 1, 2, 'a', 'b', 0, 15 });
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetIntegersFromListTest3()
        {
            List<object> expected = new List<object>() { 1, 2, 231 };
            List<object> actual = GetIntegersFromList(new List<object>() { 1, 2, 'a', 'b', "aasf", '1', "123", 231 });
            Assert.AreEqual(expected, actual);
        }
    }
}

