namespace CSharpProfessional.Core.Tests.CSharp10;

[TestClass]
public class RecordStruct
{
    record struct Persion
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }

    record struct Product(string Name, decimal Price);

    [TestMethod]
    public void Run()
    {
        Persion me = new() { FirstName = "Oleg", LastName = "Kyrylchuk" };
        var s = $"{me}";

        Persion otherPersion = me with { FirstName = "John" };
        var s1 = $"{otherPersion}";

        Persion anotherMe = new() { FirstName = "Oleg", LastName = "Kyrylchuk" };
        var r = me == anotherMe;
    }
}
