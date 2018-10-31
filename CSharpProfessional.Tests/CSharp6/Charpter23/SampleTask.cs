using System.Diagnostics;
using System.Text;
using static System.Diagnostics.Debug;

namespace CSharpProfessional.Tests.CSharp6.Charpter23
{
    public class StateObject
    {
        private int _state = 5;
        private object _sync = new object();

        public void ChangeState(int loop)
        {
            if (_state == 5)
            {
                _state++;
                Trace.Assert(_state == 6, $"Race condition occurred after {loop} loops");
            }
            _state = 5;
        }
    }

    public class StringObject
    {
        private string _str = "hello!";

        public void Change(int loop)
        {
            if (this._str == "hello!")
            {
                this._str = "hallo!!!";
                Trace.Assert(this._str == "hallo!!!", $"Race condition occurred after {loop} loops");
            }
            this._str = "hello!";
        }
    }

    public class SampleTask
    {
        public SampleTask() { }

        public void RaceCondition(object o)
        {
            Trace.Assert(o is StateObject, "o must be of type StateObject");
            var state = o as StateObject;

            int i = 0;
            while (true)
            {
                lock (state) // no race condition with this lock
                {
                    state.ChangeState(i++);
                }
            }
        }
        public void RaceConditionStr(object o)
        {
            Trace.Assert(o is StringObject, "o must be of type StringObject");
            var state = o as StringObject;

            int i = 0;
            while (true)
            {
                state.Change(i++);
            }
        }
        public void RaceConditionStr2(string str)
        {
            int i = 0;
            while (true)
            {
                if (str == "hello!")
                {
                    str = "hallo!!!";
                    Trace.Assert(str == "hallo!!!", $"Race condition occurred after {i++} loops");
                }
                str = "hello!";
            }
        }
        public void RaceConditionStringBuilder(StringBuilder sb)
        {
            int i = 0;
            while (true)
            {
                if (sb.ToString() == "hello!")
                {
                    sb.Clear();
                    sb.Append("hallo!!!");
                    Trace.Assert(sb.ToString() == "hallo!!!", $"Race condition occurred after {i++} loops");
                }
                sb.Clear();
                sb.Append("hello!");
            }
        }

        public SampleTask(StateObject s1, StateObject s2)
        {
            _s1 = s1;
            _s2 = s2;
        }

        private StateObject _s1;
        private StateObject _s2;

        public void Deadlock1()
        {
            int i = 0;
            while (true)
            {
                WriteLine("1 - waiting for s1");
                lock (_s1)
                {
                    WriteLine("1 - s1 locked, waiting for s2");
                    lock (_s2)
                    {
                        WriteLine("1 - s1 and s2 locked, now go on...");
                        _s1.ChangeState(i);
                        _s2.ChangeState(i++);
                        WriteLine($"1 still running, i: {i}");
                    }
                }
            }

        }

        public void Deadlock2()
        {
            int i = 0;
            while (true)
            {
                WriteLine("2 - waiting for s2");
                lock (_s2)
                {
                    WriteLine("2 - s2 locked, waiting for s1");
                    lock (_s1)
                    {
                        WriteLine("2 - s1 and s2 locked, now go on...");
                        _s1.ChangeState(i);
                        _s2.ChangeState(i++);
                        WriteLine($"2 still running, i: {i}");
                    }
                }
            }
        }
    }
}
