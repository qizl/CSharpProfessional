global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpProfessional.Core.Tests.CSharp10
{
    [TestClass]
    public class GlobalUsing
    {
        [TestMethod]
        public void Run()
        {
            List<int> list = new() { 1, 2, 3, 4 };
            int sum = list.Sum();
            Console.WriteLine(sum);
        }
    }
}
