using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

namespace CSharpProfessional.Tests.CSharp6.Charpter23
{
    [TestClass]
    public class EventSample
    {
        [TestMethod]
        public void TestManualResetEventSlim()
        {
            const int taskCount = 4;

            var mEvents = new ManualResetEventSlim[taskCount];
            var waitHandles = new WaitHandle[taskCount];
            var calcs = new Calculator[taskCount];

            for (int i = 0; i < taskCount; i++)
            {
                int i1 = i;
                mEvents[i] = new ManualResetEventSlim(false);
                waitHandles[i] = mEvents[i].WaitHandle;
                calcs[i] = new Calculator(mEvents[i]);
                Task.Run(() => calcs[i1].Calculation(i1 + 1, i1 + 3));
            }

            for (int i = 0; i < taskCount; i++)
            {
                //int index = WaitHandle.WaitAny(mEvents.Select(e => e.WaitHandle).ToArray());
                int index = WaitHandle.WaitAny(waitHandles);
                if (index == WaitHandle.WaitTimeout)
                {
                    WriteLine("Timeout!!");
                }
                else
                {
                    mEvents[index].Reset();
                    WriteLine($"finished task for {index}, result: {calcs[index].Result}");
                }
            }
        }

        [TestMethod]
        public void TestCountdownEvent()
        {
            const int taskCount = 4;

            var cEvent = new CountdownEvent(taskCount);
            var calcs = new Calculator1[taskCount];

            for (int i = 0; i < taskCount; i++)
            {
                calcs[i] = new Calculator1(cEvent);
                int i1 = i;
                Task.Run(() => calcs[i1].Calculation(i1 + 1, i1 + 3));
            }

            cEvent.Wait();
            WriteLine("all finished");

            for (int i = 0; i < taskCount; i++)
            {
                WriteLine($"task for {i}, result: {calcs[i].Result}");
            }
        }
    }

    public class Calculator
    {
        private ManualResetEventSlim _mEvent;

        public int Result { get; private set; }

        public Calculator(ManualResetEventSlim ev)
        {
            this._mEvent = ev;
        }

        public void Calculation(int x, int y)
        {
            WriteLine($"Task {Task.CurrentId} starts calculation");
            Task.Delay(new Random().Next(3000)).Wait();
            Result = x + y;

            // signal the event-completed!
            WriteLine($"Task {Task.CurrentId} is ready");
            this._mEvent.Set();
        }
    }

    public class Calculator1
    {
        private CountdownEvent _cEvent;

        public int Result { get; private set; }

        public Calculator1(CountdownEvent ev)
        {
            this._cEvent = ev;
        }

        public void Calculation(int x, int y)
        {
            WriteLine($"Task {Task.CurrentId} starts calculation");
            Task.Delay(new Random().Next(3000)).Wait();
            Result = x + y;

            // signal the event-completed!
            WriteLine($"Task {Task.CurrentId} is ready");
            _cEvent.Signal();
        }
    }
}
