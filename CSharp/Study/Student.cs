using Newtonsoft.Json;
using System.Collections.Generic;
using System;

/// <summary>
/// Newtonsoft
/// </summary>
public class Student
{
    public int ID { get; set; }

    public string Name { get; set; }

    [JsonIgnore]
    public int Age { get; set; }

    public string Sex { get; set; }


    public static void Init() {
        SerializeObject();
        dic();
    }

    public static void SerializeObject()
    {
        //序列化对象集合
        List<Student> oneList = new List<Student>() {
                new Student{ ID = 1, Name = "武大", Age = 260, Sex = "男" },
                new Student{ ID = 2, Name = "武二", Age = 250, Sex = "男" },
                new Student{ ID = 3, Name = "武三", Age = 240, Sex = "女" }
            };

        //定义对象
        string jsonData = JsonConvert.SerializeObject(oneList, Formatting.Indented); //序列化
        Console.WriteLine(jsonData);

        List<Student> twoList = JsonConvert.DeserializeObject<List<Student>>(jsonData);

        foreach (Student stu in twoList)
        {
            //显示结果 
            Console.WriteLine(string.Format("学生信息  ID:{0},姓名:{1},年龄:{2},性别:{3}", stu.ID, stu.Name, stu.Age, stu.Sex));
        }
    }

    static void DeserializeObject()
    {

        Console.ReadLine();

    }

    static void dic() {

        //序列化对象集合
        List<Student> oneList = new List<Student>() {
                new Student{ ID = 1, Name = "武大", Age = 260, Sex = "男" },
                new Student{ ID = 2, Name = "武二", Age = 250, Sex = "男" },
                new Student{ ID = 3, Name = "武三", Age = 240, Sex = "女" }
            };

        //定义对象
        string jsonData = JsonConvert.SerializeObject(oneList, Formatting.Indented); //序列化

        Dictionary<int, string> data = new Dictionary<int, string>();

        data.Add(1, jsonData);
        Console.WriteLine(data[1]);

        Console.WriteLine(jsonData);  //显示结果

        string str = jsonData.ToString();

        //  Console.WriteLine(str);
    }
}
