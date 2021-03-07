using System;
using System.IO;

namespace TheLargestAmount
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                var fInfo = new FileInfo(args[0]);

                if (fInfo.Exists)
                {
                    try
                    {
                        var file = new LineNumber(args[0]);

                        file.PrintOnConsole();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                    Console.ReadKey();
                    return;
                }
            }

            try
            {
                Console.Write("Enter the path: ");

                var path = Console.ReadLine();
                var file = new LineNumber(path);

                file.PrintOnConsole();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();

        }
    }
}
