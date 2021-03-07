using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace TheLargestAmount
{
    public class LineNumber
    {
        private int _numberWithMaxSum;
        private readonly List<int> _incorrectLineNumbers = new List<int>();
        private readonly string _path;

        public LineNumber(string path)
        {
            var fInfo = new FileInfo(path);

            if (!fInfo.Exists || fInfo.Extension != ".txt")
                throw new Exception("File does not exist or file's extension is wrong!");

            _path = path;
        }

        public void PrintOnConsole()
        {
            var arrayOfString = File.ReadAllLines(_path);
            var size = arrayOfString.Length;

            if (size == 0)
            {
                Console.WriteLine("File is empty!");
                return;
            }

            Console.WriteLine("line number with maximum sum: {0}", GetNumberWithMaxSum());
            Console.Write("Line numbers with incorrect data: ");

            if (GetIncorrectLineNumbers().Count == 0)
            {
                Console.Write("all lines are correct.");
                return;
            }

            Console.Write(string.Join(",", GetIncorrectLineNumbers()));
        }

        public int GetNumberWithMaxSum()
        { FindLineNumber(); return _numberWithMaxSum; }

        public List<int> GetIncorrectLineNumbers()
        {
            if (_incorrectLineNumbers.Count == 0)
                FindLineNumber();

            return _incorrectLineNumbers;
        }

        private void FindLineNumber()
        {
            var arrayOfString = File.ReadAllLines(_path);
            var lineNumber = 0;
            var maxSum = 0.0;
            var isFirstIteration = true;

            for (int i = 0; i < arrayOfString.Length; i++)
            {
                var mas = arrayOfString[i].Split(',');
                var sum = 0.0;
                var isCorrect = true;

                for (int k = 0; k < mas.Length; k++)
                {

                    if (!double.TryParse(mas[k], NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                    {
                        _incorrectLineNumbers.Add(i + 1);
                        isCorrect = false;
                        break;
                    }

                    sum += double.Parse(mas[k], CultureInfo.InvariantCulture);
                }

                if (isFirstIteration && isCorrect)
                {
                    maxSum = sum;
                    lineNumber = i + 1;
                    isFirstIteration = false;
                }

                if (maxSum < sum)
                {
                    maxSum = sum;
                    lineNumber = i + 1;
                }
            }

            _numberWithMaxSum = lineNumber;
        }

    }
}
