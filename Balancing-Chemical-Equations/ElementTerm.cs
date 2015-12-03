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

        public override string ToString()
        {
			string coefficient = "";
			if (Coefficient != 0)
			{
				coefficient = Coefficient.ToString();
			}

			return Element + coefficient;
        }
	}
}
