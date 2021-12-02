using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Common;

/// <summary>
///  Newtonsoft.Json 常用方法总结
///  https://www.jb51.net/article/205954.htm
///  
///  1 实体类的 Json 序列化和反序列化
///     1.1 Json 序列化
///     1.2 将不缩进的 JSON 字符串转成缩进形式
///     1.3 其他设置
///     1.4 Json 反序列化
///  2 JObject 使用
///      2.1 创建对象
///      2.2 JObject 中添加数组
///      2.3 从 Json 字符串创建 JObject
///      2.4 从 Entity 创建 JObject
///      2.5 获取值
///      2.6 获取数组
/// </summary>


namespace CSharp
{
    class TestJson
    {
        public static void Init() {
            //StringToJson();
            //json2();
            json3();
            json4();
            json5();
            json6();
        }

        static void StringToJson() {
            string Username = "";
            string Password = "admin123";

            string jsonText = "{Username:\"" + Username + "\",Password:\"" + Password + "\"}";

            JObject obj = JObject.Parse(jsonText);
            Console.WriteLine(obj);

            string pwd = obj["Password"].ToString();
            Console.WriteLine(pwd);
        }

        static void json2() {
            JObject obj = JObject.FromObject(new { name = "jack", age = 18 });
            Console.WriteLine(obj);
            string name = (string)obj["name"];

            string name2 = obj["name"].Value<string>();

            Console.WriteLine(name +" --- " + name2);
        }

        static void json3() {
            string Username = "login";
            string Password = "admin123";

            string jsonText = "{Username:\"" + Username + "\",Password:\"" + Password + "\"}";

            // 客户端发送
            Dictionary<byte, string> dic = new Dictionary<byte, string>();
            dic.Add((byte)ReturnCode.Data, jsonText);

            // 服务端接收
            string revJsonText = dic[(byte)ReturnCode.Data];

            // 直接打印
            Console.WriteLine(revJsonText);

            if (string.IsNullOrEmpty(revJsonText) == false) {

                // 字符串转JObject
                JObject obj = JObject.Parse(revJsonText);

                string name = obj["Username"].ToString();
                string pass = obj["Password"].ToString();
                Console.WriteLine(name + " - + -- " + pass);
            }   
        }

        static void json4() {
            Person tom = new Person("Tom", 18);

            // 从 Entity 创建 JObject
            JObject obj = JObject.FromObject(tom);

            string name = obj["name"].ToString();
            // string age = obj["age"].ToString();

            int age = obj["age"].Value<int>();

            Console.WriteLine(name + " --- " + age);
        }

        static void json5()
        {
            Person tom = new Person("Tom", 18);

            // 服务端实例序列化 JSON 字符串
            string jsonData = JsonConvert.SerializeObject(tom, Formatting.Indented);

            // 客户端解析
            JObject obj = JObject.Parse(jsonData);

            string name = obj["name"].ToString();
            int age = obj["age"].Value<int>();

            Console.WriteLine(name + " --- " + age);
        }

        static void json6()
        {
            Person tom = new Person("Tom", 18);
            Person jerry = new Person("jerry", 18);

            Dictionary<int, List<int>> roomList = new Dictionary<int, List<int>>();

            List<int> listUser = new List<int>();

            listUser.Add(10001);
            listUser.Add(10002);
            listUser.Add(10003);
            listUser.Add(10004);

         
            // roomId userId
            roomList.Add(1, listUser);
            roomList.Add(2, listUser);


            string jsonData = JsonConvert.SerializeObject(roomList, Formatting.Indented);

            Console.WriteLine(jsonData);
        }
    }
}
