using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace CSharpProfessional.Core.Tests.CSharp8
{
    interface ILogger
    {
        void Info(DateTime time, string message);
        void Info(string message) => Info(DateTime.Now, message);
    }

    class DebugLogger : ILogger
    {
        public void Info(DateTime time, string message) => Debug.WriteLine($"{time}  {nameof(message)}:{message}");
    }

    [TestClass]
    public class DefaultImplementationsOfInterfaceMembers
    {
        [TestMethod]
        public void Test()
        {
            ILogger logger = new DebugLogger();

            logger.Info("测试日志");
        }
    }
}
