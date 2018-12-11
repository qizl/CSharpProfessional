using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpProfessional.Tests.CSharp6.Chapter9
{
    class MathOperations
    {
        public static double MultiplyByTwo(double value) => value * 2;

        public static double Square(double value) => value * value;
    }

    [TestClass]
    public class SimpleDelegates
    {
        delegate double DoubleOp(double x);

        [TestMethod]
        public void Test()
        {
            DoubleOp[] operations = {
                MathOperations.MultiplyByTwo,
                MathOperations.Square
            };

            for (int i = 0; i < operations.Length; i++)
            {
                Debug.WriteLine($"Using operations[{i}]:");
                ProcessAndDisplayNumber(operations[i], 2.0);
                ProcessAndDisplayNumber(operations[i], 7.94);
                ProcessAndDisplayNumber(operations[i], 1.414);
                Debug.Write(Environment.NewLine);
            }
        }
        void ProcessAndDisplayNumber(DoubleOp action, double value)
        {
            double result = action(value);
            Debug.WriteLine($"Value is {value}, result of operation is {result}");
        }

        [TestMethod]
        public void TestFunc()
        {
            Func<double, double>[] operations = {
                MathOperations.MultiplyByTwo,
                MathOperations.Square
            };

            for (int i = 0; i < operations.Length; i++)
            {
                Debug.WriteLine($"Using operations[{i}]:");
                ProcessAndDisplayNumberByFunc(operations[i], 2.0);
                ProcessAndDisplayNumberByFunc(operations[i], 7.94);
                ProcessAndDisplayNumberByFunc(operations[i], 1.414);
                Debug.Write(Environment.NewLine);
            }
        }
        void ProcessAndDisplayNumberByFunc(Func<double, double> func, double value)
        {
            double result = func(value);
            Debug.WriteLine($"Value is {value}, result of operation is {result}");
        }
    }
}
