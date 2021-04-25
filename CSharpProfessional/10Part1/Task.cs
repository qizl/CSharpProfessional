using System;
using System.Threading.Tasks;

namespace CSharpProfessional._10Part1
{
    public class TaskDemo
    {
        private void throwException()
        {
            var a = 1;
            var b = 0;
            var c = a / b;
        }

        public async void TaskCannotCatch()
        {
            await Task.Run(() =>
            {
                this.throwException();
            });
        }

        public async Task TaskCanCatch()
        {
            await Task.Run(() =>
            {
                this.throwException();
            });
        }

        public void RunTask()
        {
            Task.Run(async () =>
            {
                try
                {
                    this.TaskCannotCatch();

                    await this.TaskCanCatch();
                }
                catch (Exception ex) { }
            });
        }
    }
}
