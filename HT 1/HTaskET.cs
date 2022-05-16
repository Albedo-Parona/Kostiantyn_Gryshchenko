using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    [TestFixture]
    public class Task_Extra
    {
        static void swap(char[] ar, int i, int j)
        {
            char temp = ar[i];
            ar[i] = ar[j];
            ar[j] = temp;
        }

        static int nextBigger(int re)
        {
            string num = re.ToString();
            char[] ar = new char[num.Length];
            for (var j = 0; j < num.Length; j++)
            {
                ar[j] = num[j];
            }

            int n = ar.Length;
            int i;
            for (i = n - 1; i > 0; i--)
            {
                if (ar[i] > ar[i - 1])
                {
                    break;
                }
            }

            if (i == 0)
            {
                int array1 = -1;
                return array1;
            }
            else
            {
                int x = ar[i - 1], min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (ar[j] > x && ar[j] < ar[min])
                    {
                        min = j;
                    }
                }

                swap(ar, i - 1, min);
                Array.Sort(ar, i, n - i);
                string s = new string(ar);
                int bar = Int32.Parse(s);
                return bar;
            }
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
