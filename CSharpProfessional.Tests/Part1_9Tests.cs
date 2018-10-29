using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpProfessional.Tests
{
    [TestClass]
    public class Part1_9Tests
    {
        #region Override
        public class P
        {
            public virtual string Name { get; set; } = "Dad";
            public virtual bool Sex { get; set; } = true;
            public DateTime Birthday { get; set; } = new DateTime(1995, 1, 1);

            public virtual void SayHello() => Debug.WriteLine("Papa~");

            public virtual void SaySomething() => Debug.WriteLine("blablabla...");
        }
        public class C1 : P
        {
            public override string Name { get; set; } = "C1";
            public bool Sex { get; set; } = false;
            public DateTime Birthday { get; set; } = new DateTime(2008, 1, 12);

            public override void SayHello() => Debug.WriteLine("C1");

            public new void SaySomething() => Debug.WriteLine("claclacla...");
        }
        [TestMethod]
        public void TestOverride()
        {
            P p = new C1();
            Debug.WriteLine(p.Name);
            Debug.WriteLine(p.Sex);
            Debug.WriteLine(p.Birthday);
            p.SayHello();
            p.SaySomething();

            var c = new C1();
            Debug.WriteLine(c.Name);
            Debug.WriteLine(c.Sex);
            Debug.WriteLine(c.Birthday);
            c.SayHello();
            c.SaySomething();

            //Output:

            //C1
            //True
            //1995 / 1 / 1 0:00:00
            //C1
            //blablabla...

            //C1
            //False
            //2008 / 1 / 12 0:00:00
            //C1
            //claclacla...
        }
        #endregion

        #region Interface
        public interface IAnimal
        {
            void SaySomething();
        }
        public class Fish : IAnimal
        {
            public void SaySomething()
            {
                Debug.WriteLine("i'm a fish!");
            }
        }
        public class Chicken : IAnimal
        {
            /// <summary>
            /// 显示实现接口，只能通过接口访问方法。适用于多接口实现时区分接口方法。
            /// </summary>
            void IAnimal.SaySomething()
            {
                Debug.WriteLine("i'm a chichen!");
            }
        }

        [TestMethod]
        public void TestInterface()
        {
            IAnimal iF = new Fish();
            iF.SaySomething();

            var f = new Fish();
            f.SaySomething();

            IAnimal iC = new Chicken();
            iC.SaySomething();

            var c = new Chicken();
            (c as IAnimal).SaySomething();
            //c.SaySomething(); // 无法访问

            // Output:
            //i'm a fish!
            //i'm a fish!
            //i'm a chichen!
            //i'm a chichen!
        }
        #endregion
    }
}