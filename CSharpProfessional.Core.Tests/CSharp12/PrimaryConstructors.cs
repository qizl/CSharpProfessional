using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProfessional.Core.Tests.CSharp12
{
    [TestClass]
    public class PrimaryConstructors
    {
        [TestMethod]
        public void Test()
        { 
        }
    }

    public readonly struct Distance(double dx, double dy)
    {
        public readonly double Magnitude = Math.Sqrt(dx * dx + dy * dy);
        public readonly double Direction = Math.Atan2(dy, dx);
    }

    public readonly struct Distance1
    {
        public readonly double Magnitude { get; }

        public readonly double Direction { get; }

        public Distance1(double dx, double dy)
        {
            Magnitude = Math.Sqrt(dx * dx + dy * dy);
            Direction = Math.Atan2(dy, dx);
        }
    }

    public interface IService
    {
        Distance GetDistance();
    }
    public class ExampleController(IService service) 
    {
        public Distance Get()
        {
            return service.GetDistance();
        }
    }
}
