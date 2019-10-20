using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticaSmyroomsTest.Repositories
{
    [TestClass]
    public class GeneralRepositoryTest
    {
        [TestMethod]
        public void Set_AddNull_NotStoredAndNotError()
        {
            bool error = false;

            List<GeneralClass> preList = null;
            List<GeneralClass> postList = null;

            try
            {
                GeneralClass item = null;

                var repository = new GeneralRepository();
                repository.Reset();

                preList = repository.GetAll().ToList();
                repository.Set(item);
                postList = repository.GetAll().ToList();
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
            Assert.IsNotNull(preList);
            Assert.IsNotNull(postList);
            Assert.IsTrue(preList.Count() == 0);
            Assert.IsTrue(postList.Count() == 0);
        }

        [TestMethod]
        public void Set_AddOnlyOne_ContainsOnlyThat()
        {
            bool error = false;

            List<GeneralClass> preList = null;
            List<GeneralClass> postList = null;

            Guid id = Guid.NewGuid();
            var name = "Name 1";

            try
            {
                var item = new GeneralClass { Id = id, Name = name };

                var repository = new GeneralRepository();
                repository.Reset();

                preList = repository.GetAll().ToList();
                repository.Set(item);
                postList = repository.GetAll().ToList();
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
            Assert.IsNotNull(preList);
            Assert.IsNotNull(postList);
            Assert.IsTrue(preList.Count() == 0);
            Assert.IsTrue(postList.Count() == 1);
            Assert.IsTrue(postList.First().Id == id);
            Assert.IsTrue(postList.First().Name == name);
        }

        [TestMethod]
        public void Set_AddOnlyOneInOneWithTwoRepositories_BothContainingSame()
        {
            bool error = false;

            List<GeneralClass> list01 = null;
            List<GeneralClass> list02 = null;

            Guid id = Guid.NewGuid();
            var name = "Name 1";

            try
            {
                var item = new GeneralClass { Id = id, Name = name };

                var repository01 = new GeneralRepository();
                repository01.Reset();

                var repository02 = new GeneralRepository();
                repository02.Reset();

                repository01.Set(item);

                list01 = repository01.GetAll().ToList();
                list02 = repository02.GetAll().ToList();
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
            Assert.IsNotNull(list01);
            Assert.IsNotNull(list02);
            Assert.IsTrue(list01.Count() == 1);
            Assert.IsTrue(list02.Count() == 1);
            Assert.IsTrue(list01.First().Id == list02.First().Id);
            Assert.IsTrue(list01.First().Name == list02.First().Name);
        }

        [TestMethod]
        public void Set_AddSameTwice_OnlyOneItem()
        {
            bool error = false;

            List<GeneralClass> list01 = null;

            Guid id = Guid.NewGuid();
            var name = "Name 1";

            try
            {
                var item = new GeneralClass { Id = id, Name = name };

                var repository01 = new GeneralRepository();
                repository01.Reset();

                repository01.Set(item);
                repository01.Set(item);

                list01 = repository01.GetAll().ToList();
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
            Assert.IsNotNull(list01);
            Assert.IsTrue(list01.Count() == 1);
        }

        [TestMethod]
        public void Get_AddOneGetSameId_SameIsReturned()
        {
            bool error = false;

            GeneralClass returned = null;

            Guid id = Guid.NewGuid();
            var name = "Name 1";

            try
            {
                var item = new GeneralClass { Id = id, Name = name };

                var repository01 = new GeneralRepository();
                repository01.Reset();

                repository01.Set(item);

                returned = repository01.Get(id);
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
            Assert.IsNotNull(returned);
            Assert.IsTrue(returned.Id == id);
            Assert.IsTrue(returned.Name == name);
        }

        [TestMethod]
        public void Get_AddOneGetOtherId_ReturnsNull()
        {
            bool error = false;

            GeneralClass returned = null;

            Guid id = Guid.NewGuid();
            var name = "Name 1";

            try
            {
                var item = new GeneralClass { Id = id, Name = name };

                var repository01 = new GeneralRepository();
                repository01.Reset();

                repository01.Set(item);

                returned = repository01.Get(Guid.NewGuid());
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
            Assert.IsNull(returned);
        }

        [TestMethod]
        public void GetAll_AddNDifferent_ReturnsSameN()
        {
            int n = 5;

            bool error = false;

            List<GeneralClass> list = null;

            List<GeneralClass> toDoList = new List<GeneralClass>();
            for (int i = 0; i < n; i++)
                toDoList.Add(new GeneralClass { Id = Guid.NewGuid(), Name = $"Name { i }" });

            try
            {
                var repository01 = new GeneralRepository();
                repository01.Reset();

                foreach (var item in toDoList)
                    repository01.Set(item);

                list = repository01.GetAll().ToList();
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
            Assert.IsNotNull(list);
            Assert.IsTrue(toDoList.All(x => list.Any(y => y.Id == x.Id && y.Name == x.Name)));
            Assert.IsTrue(list.All(x => toDoList.Any(y => y.Id == x.Id && y.Name == x.Name)));
        }

        [TestMethod]
        public void Delete_AddTwoDeleteOne_RemainsOne()
        {
            bool error = false;

            List<GeneralClass> preList = null;
            List<GeneralClass> postList = null;

            Guid id01 = Guid.NewGuid();
            var name01 = "Name 1";

            Guid id02 = Guid.NewGuid();
            var name02 = "Name 2";

            try
            {
                var item01 = new GeneralClass { Id = id01, Name = name01 };
                var item02 = new GeneralClass { Id = id02, Name = name02 };

                var repository = new GeneralRepository();
                repository.Reset();
                repository.Set(item01);
                repository.Set(item02);

                preList = repository.GetAll().ToList();
                repository.Delete(id02);
                postList = repository.GetAll().ToList();
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
            Assert.IsNotNull(preList);
            Assert.IsNotNull(postList);
            Assert.IsTrue(preList.Count() == 2);
            Assert.IsTrue(postList.Count() == 1);
            Assert.IsTrue(postList.First().Id == id01);
            Assert.IsTrue(postList.First().Name == name01);
        }

        [TestMethod]
        public void Reset_AddTwoAndReset_Empty()
        {
            bool error = false;

            List<GeneralClass> preList = null;
            List<GeneralClass> postList = null;

            Guid id01 = Guid.NewGuid();
            var name01 = "Name 1";

            Guid id02 = Guid.NewGuid();
            var name02 = "Name 2";

            try
            {
                var item01 = new GeneralClass { Id = id01, Name = name01 };
                var item02 = new GeneralClass { Id = id02, Name = name02 };

                var repository = new GeneralRepository();
                repository.Reset();
                repository.Set(item01);
                repository.Set(item02);

                preList = repository.GetAll().ToList();
                repository.Reset();
                postList = repository.GetAll().ToList();
            }
            catch (Exception e)
            {
                error = true;
            }

            Assert.IsFalse(error);
            Assert.IsNotNull(preList);
            Assert.IsNotNull(postList);
            Assert.IsTrue(preList.Count() == 2);
            Assert.IsTrue(postList.Count() == 0);
        }
    }
}
