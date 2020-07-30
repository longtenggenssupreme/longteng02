using System;

namespace ConsoleNetCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MongoDBTest dBTest = new MongoDBTest();
            dBTest.InsertMany();
            Console.Read();
        }
    }
}
