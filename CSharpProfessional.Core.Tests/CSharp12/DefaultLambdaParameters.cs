namespace CSharpProfessional.Core.Tests.CSharp12
{
    [TestClass]
    public class DefaultLambdaParameters
    {
        [TestMethod]
        public void Test()
        {
            var IncrementBy = (int source, int increment = 1) => source + increment;

            Debug.WriteLine(IncrementBy(5)); // 6
            Debug.WriteLine(IncrementBy(5, 2)); // 7 

            var sum = (params int[] values) =>
            {
                int sum = 0;
                foreach (var value in values)
                    sum += value;

                return sum;
            };

            var empty = sum();
            Debug.WriteLine(empty); // 0

            var sequence = new[] { 1, 2, 3, 4, 5 };
            var total = sum(sequence);
            Debug.WriteLine(total); // 15
        }

        // 使用默认参数或 params 数组作为参数的 Lambda 表达式没有与 Func<> 或 Action<> 类型对应的自然类型。 但是，可以定义包含默认参数值的委托类型：
        delegate int IncrementByDelegate(int source, int increment = 1);
        delegate int SumDelegate(params int[] values);
    }
}
