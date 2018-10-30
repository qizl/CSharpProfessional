using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

namespace CSharpProfessional.Tests.CSharp6.Charpter23
{
    [TestClass]
    public class MutextTests
    {
        [TestMethod]
        public void Test()
        {
            Task.Run(() =>
            {
                Task.Delay(1000).Wait();

                bool createdNew0;
                var mutex0 = new Mutex(false, "ProCSharpMutext", out createdNew0);
                while (true)
                {
                    WriteLine("wait from task...");
                    if (mutex0.WaitOne(1000))
                    {
                        try
                        {
                            WriteLine("get the mutex by task!");
                            break;
                        }
                        finally
                        {
                            mutex0.ReleaseMutex();
                            WriteLine("release the mutex by task!");
                        }
                    }
                }
            });

            bool createdNew;
            var mutex = new Mutex(false, "ProCSharpMutext", out createdNew);
            if (mutex.WaitOne())
            {
                try
                {
                    WriteLine("get the mutex by main thread!");

                    Task.Delay(10000).Wait();
                }
                finally
                {
                    mutex.ReleaseMutex();

                    WriteLine("release the mutex by main thread!");
                }
            }
            else
            {
                // error
            }
        }
    }
}
