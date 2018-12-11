using System;
using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpProfessional.Tests.CSharp6.Chapter9
{
    [TestClass]
    public class AnonymousMethods
    {
        [TestMethod]
        public void Test()
        {
            var mid = ",middle part,";
            Func<string, string> anonDel = delegate (string param)
            {
                param += mid;
                param += " and this was added to the string.";
                return param;
            };
            Debug.WriteLine(anonDel("Start of string"));

            string localFunction(string param)
            {
                param += mid;
                param += " and this was added to the string.";
                return param;
            }
            Debug.WriteLine(localFunction("Start of string"));

            Func<string, string> lambda = param =>
            {
                param += mid;
                param += " and this was added to the string.";
                return param;
            };
            Debug.WriteLine(lambda("Start of string"));
            
            Func<double, double, double> twoParams = (x, y) => x * y;
            Debug.WriteLine(twoParams(4, 2));
        }
    }
}
