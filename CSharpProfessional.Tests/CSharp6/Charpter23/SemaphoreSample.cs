using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

namespace CSharpProfessional.Tests.CSharp6.Charpter23
{
    [TestClass]
    public class SemaphoreSample
    {
        [TestMethod]
        public void Test()
        {
            int taskCount = 6;
            int semaphoreCount = 3;
            var semaphore = new SemaphoreSlim(semaphoreCount, semaphoreCount);
            var tasks = new Task[taskCount];

            for (int i = 0; i < taskCount; i++)
            {
                tasks[i] = Task.Run(() => TaskMain(semaphore));
            }

            Task.WaitAll(tasks);
            WriteLine("All tasks finished!");
        }

        public void TaskMain(SemaphoreSlim semaphoreSlim)
        {
            bool isCompleted = false;
            while (!isCompleted)
            {
                if (semaphoreSlim.Wait(600))
                {
                    try
                    {
                        WriteLine($"Task {Task.CurrentId} locks the semaphore");
                        Task.Delay(2000).Wait();
                    }
                    finally
                    {
                        WriteLine($"Task {Task.CurrentId} releases the semaphore");
                        semaphoreSlim.Release();
                        isCompleted = true;
                    }
                }
                else
                {
                    WriteLine($"Timeout for task {Task.CurrentId}; wait again");
                }
            }
        }
    }
}
