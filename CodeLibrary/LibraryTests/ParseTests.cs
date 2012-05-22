using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeLibrary;

namespace LibraryTests
{
    [TestClass]
    public class ParseTests
    {
        [TestMethod]
        public void Given_ParseToInt_When_BadValue_Then_ReturnDefaultInt()
        {
            // Arrange
            var badValue = "BadValue";
            var expected = default(int);

            // Act
            var actual = Parse.Instance.To<int>(badValue);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_ParseToInt_When_BadValueAndDefaultValue_Then_ReturnDefaultValue()
        {
            // Arrange
            var badValue = "BadValue";
            var expected = -1;

            // Act
            var actual = Parse.Instance.To<int>(badValue, expected);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_ParseToInt_When_GoodValue_Then_ReturnIntValue()
        {
            // Arrange
            var goodValue = "1";
            var expected = 1;

            // Act
            var actual = Parse.Instance.To<int>(goodValue);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_ToInt_When_BadValue_Then_ReturnDefaultInt()
        {
            // Arranage
            var badValue = "BadValue";
            var expected = default(int);

            // Act
            var actual = badValue.To<int>();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given_ToInt_When_BadValueAndDefaultValue_Then_ReturnDefaultValue()
        {
            // Arranage
            var badValue = "BadValue";
            var expected = -1;

            // Act
            var actual = badValue.To<int>(expected);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
