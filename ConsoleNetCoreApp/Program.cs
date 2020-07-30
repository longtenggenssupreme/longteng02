using System;
using System.Threading.Tasks;

namespace ConsoleNetCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestQuartz().Wait();
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
        /// 测试Quartz定时任务
        /// </summary>
        public async static Task TestQuartz()
        {
            QuartzTest quartzTest = new QuartzTest();
            await quartzTest.StartQuartz();
        }
    }
}
