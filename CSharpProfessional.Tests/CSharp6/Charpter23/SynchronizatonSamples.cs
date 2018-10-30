using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

namespace CSharpProfessional.Tests.CSharp6.Charpter23
{
    [TestClass]
    public class SynchronizatonSamples
    {
        [TestMethod]
        public void Test()
        {
            int numTasks = 20;
            var state = new SharedState();
            var tasks = new Task[numTasks];

            for (int i = 0; i < numTasks; i++)
            {
                tasks[i] = Task.Run(() => new Job(state).DoTheJob());
            }

            Task.WaitAll(tasks);

            WriteLine($"summarized {state.State}");
        }
    }

    public class SharedState
    {
        public int State { get; set; }
    }

    public class Job
    {
        private SharedState _sharedState;

        public Job(SharedState sharedState)
        {
            _sharedState = sharedState;
        }

        public void DoTheJob()
        {
            for (int i = 0; i < 50000; i++)
            {
                lock (_sharedState)
                {
                    _sharedState.State += 1;
                }
            }
        }
    }
}
