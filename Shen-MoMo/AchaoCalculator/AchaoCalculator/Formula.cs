using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchaoCalculator
{
    public class Formula
    {
        public static string makeFormula()//随机生成算式
        {
            string formula = "";
            byte[] buffer = Guid.NewGuid().ToByteArray();//生成字节数组
            int iRoot = BitConverter.ToInt32(buffer, 0);//利用BitConvert方法把字节数组转换为整数
            Random rdmNum = new Random(iRoot);//以这个生成的整数为种子
            Random rd = new Random(iRoot);
            int[] num = new int[4] { rd.Next(1, 100),
                                     rd.Next(1, 100),
                                     rd.Next(1, 100),
                                     rd.Next(1, 100) }; //初始化四个随机数
            int[] operation = new int[3] { rd.Next(0, 3),
                                           rd.Next(0, 3),
                                           rd.Next(0, 3) };//初始化三个运算符
            int count = rd.Next(1, 3); //初始化运算符个数

            formula = doFormula(num, operation, count);//生成算式
            int result = Solve.solve(num, operation, count);//计算结果
            if (result < 0) return "";
            return formula + "=" + result.ToString();//返回结果
        }
        static string doFormula(int[] num, int[] operation, int count)//生成算式，返回算式字符串
        {
            string formula = "";
            string[] op = new string[4] { "+", "-", "*", "/" };
            //运算符号的字符串数组，通过operation来匹配
            formula += num[0].ToString();
            for (int i = 0; i < count; i++)
            {
                formula += op[operation[i]] + num[i + 1];
            }
            return formula;
        }
    }
}
