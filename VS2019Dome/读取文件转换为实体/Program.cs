using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace 读取文件转换为实体
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\linji\Desktop\TempJson.txt");
            if (text!=null&&text.Length>0)
            {
                appsetting data = JsonConvert.DeserializeObject<appsetting>(text);

                foreach (var item in data.appsettings.add)
                {
                    Console.WriteLine($"\"{item.key}\":\"{item.value}\",");
                }

                Console.ReadKey();
    }
        }
    }
    public class appsetting
    {
        public Data appsettings { get; set; }
    }
    public class Data
    {
       public  List<JsonModel> add = new List<JsonModel>();
    } 
    public class JsonModel
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}
