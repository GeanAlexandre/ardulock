using ArduLock.Core.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ArduLock.Core.Test
{
    [TestClass]
    public class LockScreenManagerTest
    {
        private Mock<ILockWorkStationStrategy> _lockWorkStationStrategy = new Mock<ILockWorkStationStrategy>();


        [TestMethod]
        public void Should_throw_Exception()
        {
            Assert.ThrowsException<NullReferenceException>(() => LockScreenManager.Use(null, m => m.LockNow()));
            _lockWorkStationStrategy.Verify(x => x.Lock(), Times.Never());

        }
        [TestMethod]
        public void Should_Call_LockNow()
        {
            LockScreenManager.Use(_lockWorkStationStrategy.Object, m => m.LockNow());
            _lockWorkStationStrategy.Verify(x => x.Lock(), Times.Once());

        }
    }
}
