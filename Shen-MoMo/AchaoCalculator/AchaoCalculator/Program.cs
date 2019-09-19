using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchaoCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Formula f;

            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n;)
            {
                string formula = Formula.makeFormula();
                if (formula != "")
                {
                    Console.WriteLine(formula);
                    FormulaFile.printFile(formula);
                    i++;
                }
            }
            Console.ReadLine();
        }
    }
}
