using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharpProfessional.Tests.CSharp9
{
    [TestClass]
    public class InitOnlySetters
    {
        public class Person
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
        }

        public void InitPersion()
        {
            var person = new Person { FirstName = "Mads", LastName = "Torgersen" };
        }

        public class Person1
        {
            public string? FirstName { get; init; }
            public string? LastName { get; init; }
        }

        [TestMethod]
        public void InitOnly()
        {
            var person = new Person1 { FirstName = "Mads", LastName = "Nielsen" }; // OK
            //person.LastName = "Torgersen"; // ERROR!
        }

        public class Person2
        {
            private readonly string firstName = "<unknown>";
            private readonly string lastName = "<unknown>";

            public string FirstName
            {
                get => firstName;
                init => firstName = (value ?? throw new ArgumentNullException(nameof(FirstName)));
            }
            public string LastName
            {
                get => lastName;
                init => lastName = (value ?? throw new ArgumentNullException(nameof(LastName)));
            }
        }
    }
}
