namespace CSharpProfessional.Core.Tests.CSharp10
{
    [TestClass]
    public class ConstantIterpolatedSrings
    {
        const string Name = "Oleg";
        const string Greeting = $"Hello {Name}";

        [TestMethod]
        public void Run()
        {
            Console.WriteLine(Greeting);
        }
    }
}
