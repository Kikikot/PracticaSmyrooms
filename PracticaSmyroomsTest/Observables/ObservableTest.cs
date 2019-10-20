using Domain.ClientAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PracticaSmyroomsTest.Observables
{
    [TestClass]
    public class ObservableTest
    {
        [TestMethod]
        public void AddObserver_AddNull_NotError()
        {
            bool error = false;

            try
            {
                GeneralObserver observer01 = null;
                var observable01 = new GeneralObservable { Id = Guid.NewGuid() };
                observable01.Property = "Status 01";
                observable01.AddObserver(observer01);
                observable01.Property = "Status 02";
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
        }

        [TestMethod]
        public void AddObserver_OneObserverOneModification_ObserverCountOne()
        {
            bool error = false;
            int? preCount = null;
            int? postCount = null;

            try
            {
                var observer01 = new GeneralObserver { Id = Guid.NewGuid() };
                var observable01 = new GeneralObservable { Id = Guid.NewGuid() };
                observable01.Property = "Status 01";
                preCount = observer01.Count;
                observable01.AddObserver(observer01);
                observable01.Property = "Status 02";
                postCount = observer01.Count;
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
            Assert.IsNotNull(preCount);
            Assert.IsNotNull(postCount);
            Assert.IsTrue(preCount.Value == 0);
            Assert.IsTrue(postCount.Value == 1);
        }

        [TestMethod]
        public void AddObserver_OneObserverTwoTimesOneModification_ObserverCountOne()
        {
            bool error = false;
            int? preCount = null;
            int? postCount = null;

            try
            {
                var observer01 = new GeneralObserver { Id = Guid.NewGuid() };
                var observable01 = new GeneralObservable { Id = Guid.NewGuid() };
                observable01.Property = "Status 01";
                preCount = observer01.Count;
                observable01.AddObserver(observer01);
                observable01.AddObserver(observer01);
                observable01.Property = "Status 02";
                postCount = observer01.Count;
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
            Assert.IsNotNull(preCount);
            Assert.IsNotNull(postCount);
            Assert.IsTrue(preCount.Value == 0);
            Assert.IsTrue(postCount.Value == 1);
        }

        [TestMethod]
        public void AddObserver_TwoObserversOneModification_BothCountOne()
        {
            bool error = false;
            int? count01 = null;
            int? count02 = null;

            try
            {
                var observer01 = new GeneralObserver { Id = Guid.NewGuid() };
                var observer02 = new GeneralObserver { Id = Guid.NewGuid() };
                var observable01 = new GeneralObservable { Id = Guid.NewGuid() };
                observable01.Property = "Status 01";
                observable01.AddObserver(observer01);
                observable01.AddObserver(observer02);
                observable01.Property = "Status 02";
                count01 = observer01.Count;
                count02 = observer02.Count;
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
            Assert.IsNotNull(count01);
            Assert.IsNotNull(count02);
            Assert.IsTrue(count01.Value == 1);
            Assert.IsTrue(count02.Value == 1);
        }

        [TestMethod]
        public void RemoveObserver_RemoveBeforeModification_CountZero()
        {
            bool error = false;
            int? preCount = null;
            int? postCount = null;

            try
            {
                var observer01 = new GeneralObserver { Id = Guid.NewGuid() };
                var observable01 = new GeneralObservable { Id = Guid.NewGuid() };
                observable01.Property = "Status 01";
                observable01.AddObserver(observer01);
                preCount = observer01.Count;
                observable01.RemoveObserver(observer01);
                observable01.Property = "Status 02";
                postCount = observer01.Count;
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
            Assert.IsNotNull(preCount);
            Assert.IsNotNull(postCount);
            Assert.IsTrue(preCount.Value == 0);
            Assert.IsTrue(postCount.Value == 0);
        }

        [TestMethod]
        public void RemoveObserver_RemoveNotExisting_CountOne()
        {
            bool error = false;
            int? preCount = null;
            int? postCount = null;

            try
            {
                var observer01 = new GeneralObserver { Id = Guid.NewGuid() };
                var observer02 = new GeneralObserver { Id = Guid.NewGuid() };
                var observable01 = new GeneralObservable { Id = Guid.NewGuid() };
                observable01.Property = "Status 01";
                observable01.AddObserver(observer01);
                preCount = observer01.Count;
                observable01.RemoveObserver(observer02);
                observable01.Property = "Status 02";
                postCount = observer01.Count;
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
            Assert.IsNotNull(preCount);
            Assert.IsNotNull(postCount);
            Assert.IsTrue(preCount.Value == 0);
            Assert.IsTrue(postCount.Value == 1);
        }

        [TestMethod]
        public void RemoveObserver_RemoveNull_NotError()
        {
            bool error = false;

            try
            {
                GeneralObserver observer01 = null;
                var observable01 = new GeneralObservable { Id = Guid.NewGuid() };
                observable01.Property = "Status 01";
                observable01.RemoveObserver(observer01);
                observable01.Property = "Status 02";
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
        }
    }
}
