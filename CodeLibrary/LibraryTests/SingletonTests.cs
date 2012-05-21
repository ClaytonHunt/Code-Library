using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Linq.Expressions;
using CodeLibrary;

namespace LibraryTests
{
    [TestClass]
    public class SingletonTests
    {
        // 1. Should not be able to manually instatiate a singleton object
        // 2. Every instance of a singleton should be the same/equal
        // 3. Should be inheritable to allow for quick and easy singleton creation - this is a hope more than a requirement

        [TestMethod]
        public void Given_Invoke_When_Singleton_Then_Error()
        {
            // Arrange
            TestableSingleton singleton;
            var constructor = typeof(TestableSingleton).GetConstructors().SingleOrDefault();

            try
            {
                // Act
                singleton = (TestableSingleton)constructor.Invoke(null);

                // Assert
                Assert.Fail();
            }
            catch (NullReferenceException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Given_Instance_When_AssignedToTwoVariables_Then_VariablesAreSame()
        {
            // Arrange
            var s1 = TestableSingleton.Instance;
            var s2 = TestableSingleton.Instance;

            Assert.AreSame(s1, s2);
        }

        [TestMethod]
        public void Given_DoSomething_When_DifferentInstances_Then_CounterShouldIncrease()
        {
            // Arrange
            var s1 = TestableSingleton.Instance;
            var s2 = TestableSingleton.Instance;

            // Act
            s1.Counter = 0;
            s1.DoSomething();
            s2.DoSomething();

            // Assert
            Assert.AreEqual(2, s1.Counter);
        }
    }

    public class TestableSingleton : SingletonBase<TestableSingleton>
    {
        private TestableSingleton() { }

        public int Counter { get; set; }

        public void DoSomething()
        {
            Counter++;
        }
    }
}
