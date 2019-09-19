using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchaoCalculator
{
    class Program
    {
        static string Formula(int[] num,int[] operation,int count)
        {
            string formula = "";
            string[] op = new string[4] { "+", "-", "*", "/" };
            int start = 0;
            formula += num[0].ToString();
            for (int i = 0; i < count; i++)
            {
                formula += op[operation[i]] + num[i+1];
            }
            return formula;
        }
        static string MakeFormula()//随机生成算式
        {
            string formula = "";
            byte[] buffer = Guid.NewGuid().ToByteArray();//生成字节数组
            int iRoot = BitConverter.ToInt32(buffer, 0);//利用BitConvert方法把字节数组转换为整数
            Random rdmNum = new Random(iRoot);//以这个生成的整数为种子
            Random rd = new Random(iRoot);
            int[] num = new int[4] { rd.Next(1, 100),
                                     rd.Next(1, 100),
                                     rd.Next(1, 100),
                                     rd.Next(1, 100) };
            //初始化四个随机数
            int[] operation = new int[3] { 3, 3, 3 };/*{ rd.Next(0, 3),
                                           rd.Next(0, 3),
                                           rd.Next(0, 3) };*/
            //初始化三个运算符
            int count = rd.Next(1, 3);
            //初始化运算符个数
            formula = Formula(num, operation,count);
            //生成算式
            for (int i = 0; i < count; i++) //先算乘除
            {
                switch(operation[i])
                {
                    case 0: break;//"+"
                    case 1: break;//"-"
                    case 2: num[i+1] = num[i] * num[i + 1]; num[i] = 0; break;//"*"
                    case 3: num[i + 1] = num[i] / num[i + 1]; num[i] = 0; break;//"/"
                }
            }
            int result = num[0];
            for (int i = 0; i < count; i++)//再算加减
            {
                if (operation[i] == 1)
                {
                    if (num[i] == 0)
                        num[i + 2] = -num[i + 2];
                    else
                        num[i + 1] = -num[i + 1];
                }
                result += num[i + 1];
            }
            
            return formula + "=" + result.ToString();
        }
        static void Main(string[] args)
        {
            int n;
            n = int.Parse(Console.ReadLine());
            for(int i=0;i<n;i++)
            Console.WriteLine(MakeFormula());
            Console.ReadLine();
        }
    }
}
