using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

namespace CSharpProfessional.Tests.CSharp6.Charpter23
{
    [TestClass]
    public class AsyncDelegate
    {
        public delegate int TakesAWhileDeletegate(int x, int ms);

        [TestMethod]
        public void Test()
        {
            TakesAWhileDeletegate dl = TakesAWhile;

            IAsyncResult ar = dl.BeginInvoke(1, 3000, null, null);
            var beginTime = DateTime.Now;
            while (true)
            {
                Write('.');
                if (ar.AsyncWaitHandle.WaitOne(50))
                {
                    WriteLine("Can get the result now");
                    break;
                }
            }
            int result = dl.EndInvoke(ar);
            WriteLine($"result:{result}");
        }

        public int TakesAWhile(int x, int ms)
        {
            Task.Delay(ms).Wait();
            return 42;
        }
    }
}
