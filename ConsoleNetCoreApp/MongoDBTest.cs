using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleNetCoreApp
{
    public class MongoDBTest
    {
        public MongoClient MongoClient { get; set; }

        public MongoDBTest()
        {
            //连接字符串格式：mongodb://用户名:密码@服务器地址:27017/数据库
            var builder =new  MongoUrlBuilder("mongodb://linjie:123456@192.168.1.133:27017/test");

            #region MongoDB连接方式 第一种
            var mongoClientSettings = new MongoClientSettings
            {
                ConnectTimeout = TimeSpan.FromSeconds(10),
                MinConnectionPoolSize = 10,
                Credential = MongoCredential.CreateCredential(builder.DatabaseName, builder.Username, builder.Password),
                Server = builder.Server,
                ReadPreference = new ReadPreference(ReadPreferenceMode.Primary)
            };
            MongoClient = new MongoClient(mongoClientSettings);
            #endregion

            #region MongoDB连接方式 第二种
            //MongoClient = new MongoClient("mongodb://linjie:123456@192.168.1.133:27017"); 
            #endregion
        }

        public void InsertMany()
        {
            List<DBTest> bTests = new List<DBTest>();
            for (int i = 0; i < 10; i++)
            {
                bTests.Add(new DBTest { Name = $"名字{i}", Age = i, Address = $"北京东路{i}号" });
            }
            IMongoDatabase database = MongoClient.GetDatabase("test");
            database.GetCollection<DBTest>("linjie").InsertMany(bTests);
        }
    }
    public class DBTest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
