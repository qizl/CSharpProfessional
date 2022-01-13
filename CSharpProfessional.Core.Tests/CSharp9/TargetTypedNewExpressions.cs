using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace CSharpProfessional.Core.Tests.CSharp9
{
    [TestClass]
    public class TargetTypedNewExpressions
    {
        [TestMethod]
        public void Test()
        {
            Point p = new(3, 5);

            Point[] ps = { new(1, 2), new(5, 2), new(5, -3), new(1, -3) };
        }
    }
}
