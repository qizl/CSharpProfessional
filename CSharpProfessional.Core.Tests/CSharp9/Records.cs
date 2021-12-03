using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        { }
    }
}
