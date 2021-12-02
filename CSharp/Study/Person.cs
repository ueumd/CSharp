using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    public class Person
    {
        public string name;
        public int age;

        public Person()
        {
        }

        //构造函数
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}
