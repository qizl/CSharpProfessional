namespace CSharpProfessional.Core.Tests.CSharp10
{
    [TestClass]
    public class StructWith
    {
        [TestMethod]
        public void Run()
        {
            Product potato = new() { Name = "Potato", Category = "Vegetable" };

            Product tomato = potato with { Name = "Tomato" };
        }

        struct Product
        {
            public string Name { get; set; }
            public string Category { get; set; }
        }
    }
}
