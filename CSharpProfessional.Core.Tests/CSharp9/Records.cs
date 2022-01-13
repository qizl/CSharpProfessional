using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpProfessional.Core.Tests.CSharp9
{
    [TestClass]
    public class Records
    {
        public record Person
        {
            public string? FirstName { get; init; }
            public string? LastName { get; init; }

            public bool Sex { get; set; }
        }

        public record Student : Person
        {
            public int Id { get; init; }
        }

        public record Person1(string FirstName, string LastName) { }

        [TestMethod]
        public void WithExpressions()
        {
            var person = new Person { FirstName = "Mads", LastName = "Nielsen" };
            var otherPerson = person with { LastName = "Torgersen" };
            var otherPerson1 = otherPerson with { LastName = $"{otherPerson.LastName} House" };
        }

        [TestMethod]
        public void ValueBasedEquality()
        {
            var person = new Person { FirstName = "Mads", LastName = "Nielsen" };
            var otherPerson = person with { Sex = true };

            var r = ReferenceEquals(person, otherPerson); // false
            var r1 = Equals(person, otherPerson); // false

            otherPerson.Sex = person.Sex;
            var r2 = Equals(person, otherPerson); //true

            otherPerson = person;
            var r3 = ReferenceEquals(person, otherPerson); // true
        }

        [TestMethod]
        public void Inheritance()
        {
            var s = new Student { FirstName = "Mads", Id = 0 };

            Person student = new Student { FirstName = "Mads", LastName = "Nielsen", Id = 129 };

            var otherStudent = student with { LastName = "Torgersen" };
            var r = otherStudent is Student; // true
        }

        [TestMethod]
        public void PositionalRecords()
        {
            var p = new Person1("Mads", "Nielsen");
            var firstName = p.FirstName;
        }
    }
}
