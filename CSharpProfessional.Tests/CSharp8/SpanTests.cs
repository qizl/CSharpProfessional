using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpProfessional.Tests.CSharp8
{
    [TestClass]
    public class SpanTests
    {
        [TestMethod]
        public void SpanSlice()
        {
            var array = new byte[10];
            Span<byte> bytes = array;
            bytes = bytes.Slice(2, 5);
            bytes[0] = 15;

            Debug.WriteLine(string.Join(",", array.ToArray()));
            Debug.WriteLine(string.Join(",", bytes.ToArray()));
        }

        [TestMethod]
        public void Stackalloc()
        {
            Span<byte> bytes = stackalloc byte[2];
            bytes[0] = 2;
            bytes[1] = 3;

            Debug.WriteLine(string.Join(",", bytes.ToArray()));
        }

        [TestMethod]
        public void StackallocOverflow()
        {
            try
            {
                Span<double> bytes = stackalloc double[200000];
            }
            catch (Exception)
            {
                // 捕获不到
            }
        }

        [TestMethod]
        public void AllocHGlobal()
        {
            unsafe
            {
                var ptr = Marshal.AllocHGlobal(2); // 申请内存

                try
                {
                    var bytes = new Span<byte>((byte*)ptr, 2) { [0] = 34 };

                    Debug.WriteLine(string.Join(",", bytes.ToArray()));
                    Debug.WriteLine(Marshal.ReadByte(ptr));
                }
                finally
                {
                    Marshal.FreeHGlobal(ptr); // 需要自己释放内存
                }
            }
        }
    }
}
