namespace CSharpProfessional.Core.Tests.CSharp10
{
    [TestClass]
    public class ExtendedPropertyPatterns
    {
        class Persion
        {
            public string Name { get; set; }
            public Location Location { get; set; }
        }

        class Location
        {
            public string Country { get; set; }
        }

        [TestMethod]
        public void Run()
        {
            Persion persion = new() { Name = "Oleg", Location = new() { Country = "PL" } };

            if (persion is { Name: "Oleg", Location.Country: "PL" })
            {
                Console.WriteLine("It's me!");
            }
        }
    }
}
