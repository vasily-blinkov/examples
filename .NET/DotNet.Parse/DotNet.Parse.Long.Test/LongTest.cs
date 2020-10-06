using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNet.Parse.Core.Abstractions;
using DotNet.Parse.Core.Exceptions;
using DotNet.Parse.Long;

namespace DotNet.Parse.Tests
{
    [TestClass]
    public class LongTest
    {
        IParser<long> _parser;

        [TestInitialize]
        public void TestInitialize()
        {
            _parser = new Parser();
        }

        [TestMethod]
        public void Test293Image() => Assert.AreEqual(293, _parser.Parse("293"));

        [TestMethod]
        public void Test2709201215Image() => Assert.AreEqual(2709201215, _parser.Parse("2709201215"));

        [TestMethod]
        [ExpectedException(typeof(NotDigitException))]
        public void TestNotDigitInImage() => _parser.Parse("String");

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullImage() => _parser.Parse(null);

        [TestMethod]
        [ExpectedException(typeof(ImageEmptyOrWhitespaceException))]
        public void TestEmptyImage() => _parser.Parse(string.Empty);

        [TestMethod]
        [ExpectedException(typeof(ImageEmptyOrWhitespaceException))]
        public void TestWhitespaceImage() => _parser.Parse(" ");

        [TestMethod]
        public void TestDuplicatedZero() => Assert.AreEqual(0, _parser.Parse("00"));
    }
}
