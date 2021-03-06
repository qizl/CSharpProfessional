﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

namespace CSharpProfessional.Tests.CSharp6.Charpter23
{
    [TestClass]
    public class ReaderWriterLockSample
    {
        private static List<int> _items = new List<int>() { 0, 1, 2, 3, 4, 5 };
        private static ReaderWriterLockSlim _rwl = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        [TestMethod]
        public void Test()
        {
            var taskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
            var tasks = new Task[6];
            tasks[0] = taskFactory.StartNew(WriterMethod, 1);
            tasks[1] = taskFactory.StartNew(ReaderMethod, 1);
            tasks[2] = taskFactory.StartNew(ReaderMethod, 2);
            tasks[3] = taskFactory.StartNew(WriterMethod, 2);
            tasks[4] = taskFactory.StartNew(ReaderMethod, 3);
            tasks[5] = taskFactory.StartNew(ReaderMethod, 4);

            Task.WaitAll(tasks);
        }

        public void ReaderMethod(object reader)
        {
            try
            {
                _rwl.EnterReadLock();

                for (int i = 0; i < _items.Count; i++)
                {
                    WriteLine($"reader {reader}, loop: {i}, item: {_items[i]}");
                    Task.Delay(40).Wait();
                }
            }
            finally
            {
                _rwl.ExitReadLock();
            }
        }
        public void WriterMethod(object writer)
        {
            try
            {
                while (!_rwl.TryEnterWriteLock(50))
                {
                    WriteLine($"Writer {writer} waiting for the write lock");
                    WriteLine($"current reader count: {_rwl.CurrentReadCount}");
                }
                WriteLine($"Writer {writer} acquired the lock");
                for (int i = 0; i < _items.Count; i++)
                {
                    _items[i]++;
                    Task.Delay(50).Wait();
                }
                WriteLine($"Writer {writer} finished");
            }
            finally
            {
                _rwl.ExitWriteLock();
            }
        }
    }
}
