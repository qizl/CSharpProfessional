namespace CSharpProfessional.Core.Tests.CSharp10
{
    [TestClass]
    public class LambdaAttributes
    {
        [TestMethod]
        public void Run()
        {
            Action a =[MyAttribute]() => { };
            Action<int> b =[return: MyAttribute] (x) => { };
            Action<int> c =[MyAttribute] ([MyAttribute] x) => { };
        }
    }

    class MyAttribute : Attribute { }
}
