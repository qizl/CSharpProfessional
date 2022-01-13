namespace CSharpProfessional.Core.Tests.CSharp10
{
    [TestClass]
    public class AnonymousWith
    {
        [TestMethod]
        public void Run()
        {
            var potato = new { Name = "Potato", Category = "Vegetable" };
            var onion = potato with { Name = "Onion" };
        }
    }
}
