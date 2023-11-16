namespace CSharpProfessional.Core.Tests.CSharp10;

[TestClass]
public class StructPropertyInit
{
    [TestMethod]
    public void Run()
    {
        Persion persion = new() { Name = "Oleg" };
        var s = $"{persion.Id},{persion.Name}";
    }

    struct Persion
    {
        public Persion() { }

        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}
