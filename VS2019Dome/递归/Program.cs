using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace 递归
{
    class Program
    {
        static void Main(string[] args)
        {

            string str = "1+(1+2)*(2*3)+(1+(2+(4+3)*2+6)*2)+5";
            //将字符串转换为字符数组
            var chars = str.ToCharArray();

            //分层的数据
            List<String> result = new List<string>();
            result.Add("");//默认的第一层
            //权重, 层级
            int quan = 0;//遇到( 层级加1,  遇到) 层级减1
            for (int i = 0; i < chars.Length; i++)//便利每一个字符
            {
                if (chars[i] == '(')//遇到( 层级加1
                {
                    result[quan] += chars[i];  //将当前字符添加到当前层级的字符串
                    if (result.Count == ++quan) // 新建一层, 同时避免新建过多的层次
                    {
                        result.Add("");//新建一层
                    }

                }
                else if (chars[i] == ')')//  遇到) 层级减1
                {
                    quan -= 1;//层级-1
                    result[quan] += chars[i];//将当前字符添加到当前层级的字符串

                    result[quan + 1] += $" ";// 加个空格, 好区分当前层级的多个括号
                }
                else
                {
                    result[quan] += chars[i];//将当前字符添加到当前层级的字符串
                }

            }
            Console.WriteLine("原算术为:");
            Console.WriteLine(str);

            Console.WriteLine();
            Console.WriteLine("结果:");
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine($"第{i}层:{result[i]}");
            }
            Console.ReadKey();
        }

    }
    public class StrTest
    {
        public int Quan { get; set; }
        public int Index { get; set; }
    }
}
