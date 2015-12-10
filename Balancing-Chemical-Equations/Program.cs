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

			Term[] leftSideTerms = FindTerms(leftSide);
			Term[] rightSideTerms = FindTerms(rightSide);

			ElementTerm[] leftSideElements = FindElements(leftSideTerms);
            ElementTerm[] rightSideElements = FindElements(rightSideTerms);

            //string[] uniqueElements = FindUniqueElements(leftSide, rightSide);


			/*double[,] equationMatrix = new double[leftSideElements.Count() + rightSideElements.Count() + 1, uniqueElements.Length];

			for (int x = 0; x < equationMatrix.GetLength(0); x++)
			{
				for (int y = 0; y < equationMatrix.GetLength(1); y++)
				{
					if (x < leftSideElements.Count())
                    {
                        equationMatrix[x, y] = leftSideElements[x].Coefficient;
                    }
                    else
                    {
                        equationMatrix[x, y] = -rightSideElements[x - leftSideElements.Count()].Coefficient;
                    }
				}
			}

            ReducedRowEchelonForm(equationMatrix);

            return ToString(equationMatrix);*/
            return leftSideElements[1].ToString();
        }

        static string[] FindUniqueElements(string leftSide, string rightSide)
        {
            List<string> leftSideElements = new List<string>();
            for (int counter = 0; counter < leftSide.Length; counter++)
            {
                if (char.IsUpper(leftSide, counter))
                {
                    if (char.IsLower(leftSide, counter + 1))
                        leftSideElements.Add(leftSide.Substring(counter, 2));
                    else
                        leftSideElements.Add(leftSide.Substring(counter, 1));
                }
            }
            leftSideElements = leftSideElements.Distinct().ToList();

            List<string> rightSideElements = new List<string>();
            for (int counter = 0; counter < rightSide.Length; counter++)
            {
                if (char.IsUpper(rightSide, counter))
                {
                    if (char.IsLower(rightSide, counter + 1))
                        rightSideElements.Add(rightSide.Substring(counter, 2));
                    else
                        rightSideElements.Add(rightSide.Substring(counter, 1));
                }
            }
            rightSideElements = rightSideElements.Distinct().ToList();

            if (rightSideElements.OrderBy(i => i).SequenceEqual(leftSideElements.OrderBy(i => i)))
                return leftSideElements.ToArray();
            else
                return null;
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
            // I actually do not know how this works or how I wrote it, but it works so
            // Let's figure out how this works

            // Create a list of elements that will have the elements added to it as we pass through the terms
			List<ElementTerm> elements = new List<ElementTerm>();

            // Loop through each term
			for (int termPosition = 0; termPosition < terms.Length; termPosition++)
			{
				string term = terms[termPosition].term;

                // Loop through each character of the string of the term
				for (int counter = 0; counter < term.Length; counter++)
				{
                    // If the character is uppercase, marks start of a new element
					if (char.IsUpper(term, counter))
					{
                        // Check if next character is also a letter, then it is a 2 letter element
                        // Ensure that the next letter is still within the limits of the string
                        if (counter + 1 < term.Length && char.IsLower(term, counter + 1))
						{
                            // Calculate the coefficient of the element by starting with a 0
							string coefficient = "0";
							int position = counter + 2;
                            // Continue adding on numbers
							while (position < term.Length && char.IsNumber(term.ElementAt(position)))
							{
                                // Add each digit onto the coefficient string
								coefficient += term.ElementAt(position);

                                // Move onto the next character
								position++;
							}

                            // Add a new element with the calculated coefficient, element symbol and use the position of the term as the position for the element
							elements.Add(new ElementTerm(int.Parse(coefficient), term.Substring(counter, 2), termPosition));


                            counter = position - 1;
						}
                        // else the element is only one letter long
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
                            counter = position;
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
