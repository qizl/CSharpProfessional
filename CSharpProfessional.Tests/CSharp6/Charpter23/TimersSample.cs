using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

namespace CSharpProfessional.Tests.CSharp6.Charpter23
{
    [TestClass]
    public class TimersSample
    {
        [TestMethod]
        public void Test()
        {
            using (var t1 = new Timer(TimeAction, null, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3)))
            {
                Task.Delay(15000).Wait();
            }
        }

        public void TimeAction(object obj)
        {
            WriteLine($"System.Threading.Timer {DateTime.Now:T}");
        }
    }
}
