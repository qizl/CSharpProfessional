using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace CSharpProfessional.Tests.CSharp6.Charpter23
{
    [TestClass]
    public class SampleTaskTests
    {
        [TestMethod]
        public void RaceConditions()
        {
            var state = new StateObject();
            var task = null as Task;
            for (int i = 0; i < 2; i++)
            {
                task = Task.Run(() => new SampleTask().RaceCondition(state));
            }

            Task.WaitAll(task);
        }

        [TestMethod]
        public void Deadlock()
        {
            var s1 = new StateObject();
            var s2 = new StateObject();
            Task.Run(() => new SampleTask(s1, s2).Deadlock1());
            Task.Run(() => new SampleTask(s1, s2).Deadlock2());

            Task.Delay(10000).Wait();
        }
    }
}
