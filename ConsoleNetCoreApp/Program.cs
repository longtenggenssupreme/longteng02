using System;
using System.Threading.Tasks;

namespace ConsoleNetCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TestQuartz();
            Console.Read();
        }

        /// <summary>
        /// 测试mongodb
        /// </summary>
        public static void TestMongoDB()
        {
            MongoDBTest dBTest = new MongoDBTest();
            dBTest.InsertMany();
        }

        /// <summary>
        /// 测试mongodb
        /// </summary>
        public async static Task TestQuartz()
        {
            QuartzTest quartzTest = new QuartzTest();
            await quartzTest.StartQuartz();
        }
    }
}
