﻿using System;
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

			Term[] leftSideTerms = FindTerms(leftSide);
			Term[] rightSideTerms = FindTerms(rightSide);

			ElementTerm[] leftSideElements = FindElements(leftSideTerms);
            ElementTerm[] rightSideElements = FindElements(rightSideTerms);

			List<string> elements = new List<string>();


			double[,] equationMatrix = new double[leftSideElements.Count() + rightSideElements.Count() + 1, elements.Count];

			//for (int x = 0; x < equationMatrix.GetLength(0); x++)
			//{
			//	for (int y = 0; y < equationMatrix.GetLength(1); y++)
			//	{
			//		
			//	}
			//}

            return leftSideElements[0].ToString();
        }

		static Term[] FindTerms(string equation)
		{
			string[] terms = equation.Split('+');
			List<Term> termList = new List<Term>();
			for (int counter = 0; counter < terms.Length; counter++)
			{
				termList.Add(new Term(terms[counter].Trim(), counter));
			}
			return termList.ToArray();
		}

		static ElementTerm[] FindElements(Term[] terms)
		{
			List<ElementTerm> elements = new List<ElementTerm>();
			for (int termPosition = 0; termPosition < terms.Length; termPosition++)
			{
				string term = terms[termPosition].term;
				for (int counter = 0; counter < term.Length; counter++)
				{
					if (char.IsLetter(term, counter))
					{
						if (counter + 1 < term.Length && char.IsLower(term, counter + 1))
						{
							string coefficient = "0";
							int position = counter + 2;
							while (position < term.Length && char.IsNumber(term.ElementAt(position)))
							{
								coefficient += term.ElementAt(position);
								position++;
							}
							elements.Add(new ElementTerm(int.Parse(coefficient), term.Substring(counter, 2), termPosition));
							counter = position - 1;
						}
						else
						{
							string coefficient = "0";
							int position = counter + 1;
							while (position < term.Length && char.IsNumber(term.ElementAt(position)))
							{
								coefficient += term.ElementAt(position);
								position++;
							}
							elements.Add(new ElementTerm(int.Parse(coefficient), term.Substring(counter, 1), termPosition));
							counter = position - 1;
						}
					}
				}
			}
			return elements.ToArray();
		}

		static List<string> SplitIntoTerms(string equation)
		{
			List<string> terms = new List<string>();
			string nextTerm = "";
			for (int counter = 0; counter < equation.Length; counter++)
			{
				if (equation.ElementAt(counter) == '+')
				{
					terms.Add(nextTerm.Trim());
					nextTerm= "";
				}
				else
					nextTerm += equation.ElementAt(counter);
			}
			terms.Add(nextTerm.Trim());
			return terms;
		}

		static double[,] ReducedRowEchelonForm(double[,] matrix)
		{
			int lead = 0, rowCount = matrix.GetLength(0), columnCount = matrix.GetLength(1);
			for (int r = 0; r < rowCount; r++)
			{
				if (columnCount <= lead)
					break;
				int i = r;
				while (matrix[i, lead] == 0)
				{
					i++;
					if (i == rowCount)
					{
						i = r;
						lead++;
						if (columnCount == lead)
						{
							lead--;
							break;
						}
					}
				}
				for (int j = 0; j < columnCount; j++)
				{
					double temp = matrix[r, j];
					matrix[r, j] = matrix[i, j];
					matrix[i, j] = temp;
				}
				double div = matrix[r, lead];
				if (div != 0)
				{
					for (int j = 0; j < columnCount; j++) 
					{
						matrix[r, j] /= div;
					}
				}
				for (int j = 0; j < rowCount; j++)
				{
					if (j != r)
					{
						double sub = matrix[j, lead];
						for (int k = 0; k < columnCount; k++)
						{
							matrix[j, k] -= (sub * matrix[r, k]);
						}
					}
				}
				lead++;
			}
			return matrix;
		}

		static string ToString(double[,] grid)
		{
			string result = "";
			for (int x = 0; x < grid.GetLength(0); x++)
			{
				for (int y = 0; y < grid.GetLength(1); y++)
				{
					result += grid[x, y].ToString();
					if (y != grid.GetLength(1) - 1)
						result += ",";
				}
				result += "\n";
			}
			return result;
		}
    }
}
