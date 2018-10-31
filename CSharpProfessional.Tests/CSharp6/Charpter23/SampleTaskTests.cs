using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

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
        public void RaceConditionsStr()
        {
            var state = new StringObject();
            var task = null as Task;
            for (int i = 0; i < 2; i++)
            {
                task = Task.Run(() => new SampleTask().RaceConditionStr(state));
            }

            Task.WaitAll(task);
        }
        [TestMethod]
        public void RaceConditionsStr2()
        {
            string str = "hello!";
            var task = null as Task;
            for (int i = 0; i < 2; i++)
            {
                task = Task.Run(() => new SampleTask().RaceConditionStr2(str));
            }

            Task.WaitAll(task);
        }
        [TestMethod]
        public void RaceConditionsStringBuilder()
        {
            var sb = new StringBuilder("hello!");
            var task = null as Task;
            for (int i = 0; i < 2; i++)
            {
                task = Task.Run(() => new SampleTask().RaceConditionStringBuilder(sb));
            }

            Task.WaitAll(task);
        }

        [TestMethod]
        public void TestParameters()
        {
            var p = new Product();
            this.changeProduct(p);

            var str = "hello!";
            this.changeStr(str);
        }
        private class Product
        {
            public string Name { get; set; } = "iPhoneX";
            public int Price { get; set; } = 10000;
        }
        private void changeProduct(Product p)
        {
            p = new Product();
            p.Name = "iPhoneXP";
            p.Price = 11000;
        }
        private void changeStr(string str)
        {
            str = "hallo!!!";
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
