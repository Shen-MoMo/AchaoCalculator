using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchaoCalculator
{
    class FormulaFile
    {
        public static void printFile(string formula)
        {
            string path = @"F:\GIT项目\AchaoCalculator\formula.txt";//保存路径
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
            System.IO.StreamWriter streamWriter = fileInfo.AppendText();//字符输出流
            streamWriter.WriteLine(formula);
            streamWriter.Close();
        }
    }
}
