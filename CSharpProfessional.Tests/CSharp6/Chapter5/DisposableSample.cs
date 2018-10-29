﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
