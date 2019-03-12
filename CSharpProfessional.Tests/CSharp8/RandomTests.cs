using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpProfessional.Tests.CSharp8
{
    [TestClass]
    public class RandomTests
    {
        [TestMethod]
        public void GetNumberWithSameSeed()
        {
            for (var i = 0; i < 10; i++)
            {
                Debug.WriteLine(new Random().Next(100));
                //Thread.Sleep(1);
            }

            var rad = new Random();
            for (var i = 0; i < 10; i++)
                Debug.WriteLine(rad.Next(100));
        }

        int GetRandomSeed()
        {
            var bytes = new byte[4];
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        [TestMethod]
        public void GetNumber1()
        {
            for (var i = 0; i < 10; i++)
                Debug.WriteLine(new Random(this.GetRandomSeed()).Next(100));
        }
    }
}
