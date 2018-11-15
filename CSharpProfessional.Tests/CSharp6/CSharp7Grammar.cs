using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CSharpProfessional.Tests.CSharp6
{
    [TestClass]
    public class CSharp7Grammar
    {
        private int n = 0b0001_0000;

        [TestMethod]
        public void Tuple()
        {
            var t = this.range(new int[] { 1, 2, 3, 123, 4, 123, 45, 567, 0 });
            Assert.IsTrue(t.Min < t.Max);
        }

        /// <summary>
        /// 参考：https://www.cnblogs.com/tdfblog/archive/2017/11/06/dissecting-the-tuples-in-c-7.html
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private (int Max, int Min) range(IEnumerable<int> numbers)
        {
            var max = numbers.Max();
            var min = numbers.Min();
            return (max, min);
        }

        [TestMethod]
        public void OutVariable()
        {
            var input = "12t31";

            if (int.TryParse(input, out int result))
                Debug.WriteLine(result);
            else
                Debug.WriteLine($"could not parse input:{input}");
        }
    }
}
