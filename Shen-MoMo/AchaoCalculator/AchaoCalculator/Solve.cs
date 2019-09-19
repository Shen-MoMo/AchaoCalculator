using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchaoCalculator
{
    class Solve
    {
        public static int solve(int[] num, int[] operation, int count)//计算算式
        {
            int result = num[0];
            //先算乘除
            for (int i = 0; i < count; i++)
            {
                switch (operation[i])
                {
                    case 0: break;//"+"
                    case 1: break;//"-"
                    case 2: num[i + 1] = num[i] * num[i + 1]; num[i] = 0; break;//"*"
                    case 3: num[i + 1] = num[i] / num[i + 1]; num[i] = 0; break;//"/"
                }
            }
            //再算加减
            for (int i = 0; i < count; i++)
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
            return result;
        }
    }
}
