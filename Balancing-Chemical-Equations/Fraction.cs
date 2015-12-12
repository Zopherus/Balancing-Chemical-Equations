﻿using System;
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

        public Fraction(int Numerator, int Denominator)
        {
            this.Numerator = Numerator;
            this.Denominator = Denominator;
        }

		public Fraction(double Decimal)
		{
			Fraction fraction = DecimalToFraction(Decimal);
			this.Numerator = fraction.Numerator;
			this.Denominator = fraction.Denominator;
		}

		public static Fraction DecimalToFraction(double number)
		{
            double error = 0.01;
            int sign = Math.Sign(number);
            number *= sign;
			int wholePart = (int)Math.Floor(number);
			double fractionalPart = number - wholePart;

			int lowerNum = 0;
			int lowerDen = 1;

			int upperNum = 1;
			int upperDen = 1;


		    while (true)
			{
                int middleNum = (lowerNum + upperNum);
				int middleDen = (lowerDen + upperDen);
                if (middleDen * (fractionalPart + error) < middleNum)
                {
                    upperNum = middleNum;
                    upperDen = middleDen;
                }
                else if (middleNum < (fractionalPart - error) * middleDen)
                {
                    lowerNum = middleNum;
                    lowerDen = middleDen;
                }
                else
                    return new Fraction((wholePart * middleDen + middleNum) * sign, middleDen);
			}
		}

        public override string ToString()
        {
            return Numerator.ToString() + "/" + Denominator.ToString();
        }
	}
}
