using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static System.Diagnostics.Debug;

namespace CSharpProfessional.Tests.CSharp10.Chapter5
{
    [TestClass]
    public class DisposableSample
    {
        [TestMethod]
        public void Test()
        {
            using (var resource = new SomeResource())
            {
                resource.Foo();
            }
        }

        [TestMethod]
        unsafe public void TestUnsafe()
        {
            int x = 10;
            short y = -1;
            byte y2 = 4;
            double z = 1.5;
            int* pX = &x;
            short* pY = &y;
            double* pZ = &z;

            WriteLine($"Address of x is 0x{(ulong)&x:X}, size is {sizeof(int)}, value is {x}");
            WriteLine($"Address of y is 0x{(ulong)&y:X}, size is {sizeof(short)}, value is {y}");
            WriteLine($"Address of y2 is 0x{(ulong)&y2:X}, size is {sizeof(byte)}, value is {y2}");
            WriteLine($"Address of z is 0x{(ulong)&z:X}, size is {sizeof(double)}, value is {z}");
            WriteLine($"Address of pX=&x is 0x{(ulong)&pX:X}, size is {sizeof(int*)}, value is 0x{(ulong)pX:X}");
            WriteLine($"Address of pY=&y is 0x{(ulong)&pY:X}, size is {sizeof(short*)}, value is 0x{(ulong)pY:X}");
            WriteLine($"Address of pZ=&z is 0x{(ulong)&pZ:X}, size is {sizeof(double*)}, value is 0x{(ulong)pZ:X}");
            *pX = 20;
            WriteLine($"After setting *pX, x = {x}");
            WriteLine($"*pX = {*pX}");

            pZ = (double*)pX;
            WriteLine($"x treated as a double = {*pZ}");
            WriteLine($"Address of pZ=&z is 0x{(ulong)&pZ:X}, size is {sizeof(double*)}, value is 0x{(ulong)pZ:X}");

            *pX = 30;
            WriteLine($"x = {x}");
            WriteLine($"*pX = {*pX}");
            WriteLine($"*pZ = {*pZ}");
        }
    }

    public class SomeInnerResource : IDisposable
    {
        public SomeInnerResource()
        {
            WriteLine("simulation to allocate native memory");
        }

        public void Foo()
        {
            if (disposedValue) throw new ObjectDisposedException(nameof(SomeInnerResource));
            WriteLine($"{nameof(SomeInnerResource)}.{nameof(Foo)}");
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                WriteLine("simulation to release native memory");
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~SomeInnerResource()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
    }
    public class SomeResource : IDisposable
    {
        private SomeInnerResource _innerResource;

        public SomeResource()
        {
            _innerResource = new SomeInnerResource();
        }

        public void Foo()
        {
            if (disposedValue) throw new ObjectDisposedException(nameof(SomeResource));
            WriteLine($"{nameof(SomeResource)}.{nameof(Foo)}");
            _innerResource?.Foo();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).
                    _innerResource?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SomeResource() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
