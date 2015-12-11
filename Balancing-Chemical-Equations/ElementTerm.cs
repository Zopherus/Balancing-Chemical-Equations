using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balancing_Chemical_Equations
{
	class ElementTerm
	{
		public int Coefficient { get; private set; }
		public string Element { get; private set; }
		public int Position { get; private set; }

		public ElementTerm(int Coefficient, string Element, int Position)
		{
			this.Coefficient = Coefficient;
			this.Element = Element;
			this.Position = Position;
		}

        public ElementTerm(string Element)
        {
            this.Element = Element;
        }

        public override string ToString()
        {
			string coefficient = "";
			if (Coefficient != 0)
			{
				coefficient = Coefficient.ToString();
			}

			return Element + coefficient;
        }

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			//If parameter cannot be cast to Rectangle return false
			ElementTerm elementTerm = (ElementTerm)obj;
			if ((Object)elementTerm == null)
				return false;

			//Return true if the two rectangles match
			return Element == elementTerm.Element;
		}


        public bool Equals(ElementTerm elementTerm)
        {
            return Element == elementTerm.Element;
        }
	}
}
