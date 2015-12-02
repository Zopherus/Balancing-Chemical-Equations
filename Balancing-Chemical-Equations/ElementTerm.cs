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

		public ElementTerm(int Coefficient, string Element)
		{
			this.Coefficient = Coefficient;
			this.Element = Element;
		}
	}
}
