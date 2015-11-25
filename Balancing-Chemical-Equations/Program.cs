using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balancing_Chemical_Equations
//https://www.reddit.com/r/dailyprogrammer/comments/3oz82g/20151016_challenge_236_hard_balancing_chemical/
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BalanceChemicalEquation("C5H12 + O2 -> CO2 + H2O"));
            Console.ReadLine();
        }

        static string BalanceChemicalEquation(string equation)
        {
            int middle = equation.IndexOf('-');
            string leftSide = equation.Substring(0, middle - 1);
            string rightSide = equation.Substring(middle + 3, equation.Length - middle - 3);
            return leftSide + " -> " + rightSide;
        }
    }
}
