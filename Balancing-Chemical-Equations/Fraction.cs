using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balancing_Chemical_Equations
{
	class Fraction
	{
		public int Numerator { get; private set; }
		public int Denominator { get; private set; }

		public Fraction(double Decimal)
		{
			Fraction fraction = DecimalToFraction(Decimal);
			this.Numerator = fraction.Numerator;
			this.Denominator = fraction.Denominator;
		}

		public Fraction DecimalToFraction(double Decimal)
		{
			double error = Double.Epsilon;
			int WholePart = (int)Math.Floor(Decimal);
			double FractionalPart = Decimal - WholePart;

			int lowNum = 0;
			int lowDen = 1;

			int topNum = 1;
			int topDen = 1;


			while (true)
			{
				int middleNum = (lowNum + topNum) / 2;
				int middleDen = (lowDen + topDen) / 2;
				if (middleDen * (FractionalPart + error) < middleNum)
				{

				}
				else if (middleNum < (FractionalPart - error) * middleDen)
				{
				}
				else
				{
					return 
				}
			}
		}

		public static Fraction operator + (Fraction fraction1, Fraction Fraction2)
		{
			return ur_mum;
		}
	}
}
