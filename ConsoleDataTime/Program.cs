using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

//С помощью рефлексии выведите все свойства структуры DateTime

namespace ConsoleDataTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = Type.GetType("System.DateTime");
            Console.WriteLine(type.FullName);
            Console.WriteLine("--------");
            foreach (var prop in type.GetProperties()) 
            {
                Console.WriteLine($"{prop.Name}");
            }
            Console.WriteLine("--------");
            foreach (var field in type.GetFields())
            {
                Console.WriteLine($"{field.Name}");
            }
            
            Console.ReadKey();
        }
    }
}
