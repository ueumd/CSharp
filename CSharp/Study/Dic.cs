using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Common;

/// <summary>
/// Dictionary的用法总结
///  https://www.cnblogs.com/hejianchun/articles/3498204.html
///  常用属性
///       Comparer     获取用于确定字典中的键是否相等的 IEqualityComparer<T>。
///       Count        获取包含在 Dictionary<TKey, TValue> 中的键/值对的数目。
///       Item         获取或设置与指定的键相关联的值。
///       Keys         获取包含 Dictionary<TKey, TValue> 中的键的集合。
///       Values       获取包含 Dictionary<TKey, TValue> 中的值的集合。
///   
///   常用方法
///       Add                  将指定的键和值添加到字典中。
///       Clear                从 Dictionary<TKey, TValue> 中移除所有的键和值。
///       ContainsKey          确定 Dictionary<TKey, TValue> 是否包含指定的键。
///       ContainsValue        确定 Dictionary<TKey, TValue> 是否包含特定值。
///       Equals(Object)       确定指定的 Object 是否等于当前的 Object。 （继承自 Object。）
///       Finalize             允许对象在“垃圾回收”回收之前尝试释放资源并执行其他清理操作。 （继承自 Object。）
///       GetEnumerator        返回循环访问 Dictionary<TKey, TValue> 的枚举器。
///       GetHashCode          用作特定类型的哈希函数。 （继承自 Object。）
///       GetObjectData        实现 System.Runtime.Serialization.ISerializable 接口，并返回序列化 Dictionary<TKey, TValue> 实例所需的数据。
///       GetType              获取当前实例的 Type。 （继承自 Object。）
///       MemberwiseClone     创建当前 Object 的浅表副本。 （继承自 Object。）
///       OnDeserialization   实现 System.Runtime.Serialization.ISerializable 接口，并在完成反序列化之后引发反序列化事件。
///       Remove               从 Dictionary<TKey, TValue> 中移除所指定的键的值。
///       ToString             返回表示当前对象的字符串。 （继承自 Object。）
///       TryGetValue          获取与指定的键相关联的值。
/// </summary>
namespace CSharp
{
    class Dic
    {
        static Dictionary<int, Person> dicPerson = new Dictionary<int, Person>();

        public static void Init() {
            // LearnDictionaryInfo();
            EnumAndDic();
        }
       
        public static void LearnDictionaryInfo() {
            //添加键值 
            Person p1 = new Person("hjc", 18);
            Person p2 = new Person("tf", 19);

            dicPerson.Add(0, p1);
            dicPerson[1] = p2;

            //取值
            Console.WriteLine("\n");
            Console.WriteLine("取值  name:" + dicPerson[0].name + "—" + "age:" + dicPerson[0].age);

            //改值
            Console.WriteLine("\n");
            dicPerson[1].age = 20;
            Console.WriteLine("改值  name:" + dicPerson[1].name + "—" + "age:" + dicPerson[1].age);


            // 便利Key
            Console.WriteLine("\n");
            Console.WriteLine("遍历 key:");
            foreach (int key in dicPerson.Keys) {
                string id = "用户Id:" + key;
                string str = string.Format("name:{0} age:{1}", dicPerson[key].name, dicPerson[key].age);
                Console.WriteLine(id + "\t" + str);
            }

            //遍历value
            Console.WriteLine("\n");
            Console.WriteLine("遍历 value:");

            foreach (Person value in dicPerson.Values) {
                Console.WriteLine(value.name +" -- " + value.age);
            }


            //遍历字典
            Console.WriteLine("\n");
            Console.WriteLine("遍历字典:");
            foreach (KeyValuePair<int, Person> kvp in dicPerson) {
                Console.WriteLine(kvp.Key + "--" + kvp.Value.name + "--" + kvp.Value.age);
            }
     

             //  删除元素
            Console.WriteLine("\n");
            Console.WriteLine("删除元素");
            if (dicPerson.ContainsKey(1)) {
                //如果存在
               // dicPerson.Remove(1);
            }
            
            foreach (Person value in dicPerson.Values)
            {
                string str = string.Format("name:{0} age:{1}", value.name, value.age);
                Console.WriteLine(str);
            }
            //清除所有的元素
           // dicPerson.Clear();

            Console.Read();

        }

        public static void EnumAndDic() {
            Person p1 = new Person("hjc", 18);
            Person p2 = new Person("tf", 19);

            List<Person> list = new List<Person>();
            list.Add(p1);
            list.Add(p2);

            Dictionary<byte, Object> dic = new Dictionary<byte, object>();
            dic.Add((byte)ReturnCode.Data, list);



            List<Person> per = new List<Person>();

            foreach (byte key in dic.Keys)
            {
                string id = "用户Id:" + key;

                per = (List<Person>)dic[key];

               string jsonData = JsonConvert.SerializeObject(dic[key], Formatting.Indented);


                Console.WriteLine(id);
                Console.WriteLine(jsonData);
                Console.WriteLine(per[0].name + " -- " + per[0].age);
                Console.WriteLine(dic[key]);
            }
        }
    }
}
