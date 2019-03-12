using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpProfessional.Tests.CSharp8
{
    /// <summary>
    /// 泛型协变与抗变
    /// </summary>
    [TestClass]
    public class GenericTests
    {
        public class Person
        {
            public string Name { get; set; }
            public DateTime Birthday { get; set; }
        }

        public class Son : Person
        {
            public string Address { get; set; }
        }

        public class Daughter : Person
        {
            public string HomeAddr { get; set; }
        }

        public class GrandSon : Son
        {
            public string Country { get; set; }
        }

        public string GetName(Person p) => p.Name; // 参数协变
        public Son GetPerson() => new GrandSon(); // 返回类型抗变
        //public Son GetPerson1() => new Person(); // 报错，需要显示转换

        [TestMethod]
        public void Test()
        {
            var name = this.GetName(new Son { Name = "Potter" }); // 参数协变
            var person = this.GetPerson(); // 返回类型抗变
        }
    }
}
