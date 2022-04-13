using System;
using System.IO;

namespace 禁言关键字处理
{
    class Program
    {
        static void Main(string[] args)
        {
            var filepath = @"C:\Users\linji\Desktop\禁言关键词.txt";
            StreamReader sr = File.OpenText(filepath);
            string line;
            int i = 1;

            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine($"{line}|-|加禁言");

                //i++;
                //if (i>=200)
                //{
                //    Console.WriteLine();
                //    i = 1;
                //}
            }

            Console.ReadKey();
        }
    }
}
