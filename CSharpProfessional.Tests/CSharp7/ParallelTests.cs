using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpProfessional.Tests.CSharp7
{
    [TestClass]
    public class ParallelTests
    {
        [TestMethod]
        public void TestParallel()
        {
            Debug.WriteLine("begin stop codes:");
            Parallel.For(0, 100, (i, loopState) =>
            {
                Debug.WriteLine(i);
                if (i >= 10)
                {
                    Debug.WriteLine("stop!");
                    loopState.Stop();
                }
            });
            Debug.WriteLine("begin break codes:");
            Parallel.For(0, 100, (i, loopState) =>
            {
                Debug.WriteLine(i);
                if (i >= 10)
                {
                    Debug.WriteLine("break!");
                    loopState.Break();
                }
            });
        }
    }
}
