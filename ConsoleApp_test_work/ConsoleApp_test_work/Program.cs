using System.Text.RegularExpressions;
using System.Text;
using System.Reflection;
using System;
using Microsoft.Win32;
using ClassLibrary_get_dictionary;


namespace ConsoleApp_test_work
{
    internal class Program
    {
        static void Main()
        {
            ReflectionExample();
        }
        static void ReflectionExample()
        {
            try
            {
                Console.WriteLine("Напишите полный путь к текстовому файлу:");
                string check_path = Console.ReadLine();

                string path = check_path;
                string text = File.ReadAllText(path);

                var myClass = new ClassLibrary();
                var type = myClass.GetType();
                var methodinfo = type.GetMethod("get_dictionary",BindingFlags.Static | BindingFlags.NonPublic);

                var WordCounts = methodinfo.Invoke(myClass, new object[] { text } ) as Dictionary<string, int>;

                // get_fail(path);
                List<Tuple<int, string>> WordStats = WordCounts.Select(x => new Tuple<int, string>(x.Value, x.Key)).ToList();
                
                foreach (Tuple<int, string> t in WordStats)
                    File.AppendAllText(path + ".stats.txt", t.Item2 + " " + t.Item1 + Environment.NewLine);
                Console.WriteLine("Обработка прошла успешно");
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Ошибка подключения введите путь заново.");
                Main();
            }
        }

       
    }
}