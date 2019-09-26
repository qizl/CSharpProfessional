using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace CSharpProfessional.Core.Tests.CSharp8
{
    [TestClass]
    public class IndexTests
    {
        [TestMethod]
        public void Test()
        {
            Index b = 3;
            Index e = 5;
            var a = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Debug.WriteLine($"{a[b]},{a[e]}");
        }
    }
}
