using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLargestAmount;
using System;

namespace TheLargestAmountTest
{
    [TestClass]
    public class LineNumberTest
    {
        private LineNumber _file;

        [TestMethod]
        public void TestWrongExtension()
        {
            var path = @"D:\TextFile\File_1.docx";

            Assert.ThrowsException<Exception>(() => new LineNumber(path));
        }

        [TestMethod]
        public void TestNonExistentFile()
        {
            var path = @"D:\TextFile\File2.txt";

            Assert.ThrowsException<Exception>(() => new LineNumber(path));
        }

        [TestMethod]
        public void TestFile1()
        {
            var path = @"..\..\..\..\TheLargestAmount\Solution Items\File_1.txt";
            var expectedCorrectLine = 5;
            var expectedIncorrectLine = 2;
            _file = new LineNumber(path);


            Assert.AreEqual(expectedCorrectLine, _file.GetNumberWithMaxSum());
            Assert.AreEqual(expectedIncorrectLine, _file.GetIncorrectLineNumbers()[0]);
        }

        [TestMethod]
        public void TestFile2()
        {
            var path = @"..\..\..\..\TheLargestAmount\Solution Items\File_2.txt";
            var expectedCorrectLine = 5;
            var expectedIncorrectLine1 = 3;
            var expectedIncorrectLine2 = 4;
            var expectedSize = 2;
            _file = new LineNumber(path);


            Assert.AreEqual(expectedCorrectLine, _file.GetNumberWithMaxSum());
            Assert.AreEqual(expectedSize, _file.GetIncorrectLineNumbers().Count);
            Assert.AreEqual(expectedIncorrectLine1, _file.GetIncorrectLineNumbers()[0]);
            Assert.AreEqual(expectedIncorrectLine2, _file.GetIncorrectLineNumbers()[1]);
        }

    }
}
