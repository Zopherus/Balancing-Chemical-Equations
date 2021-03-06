﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balancing_Chemical_Equations
{
	class Compound
	{
        public int Coefficient { get; set; }
		public string term { get; private set; }
		public int Position { get; private set; }
        public List<ElementTerm> Elements { get; private set; }

		public Compound(string term, int Position)
		{
            Elements = new List<ElementTerm>();
			this.term = term;
			this.Position = Position;
		}

		public override string ToString()
		{
            string coefficient = "";
            if (Coefficient != 1)
            {
                coefficient = Coefficient.ToString();
            }
			return coefficient + term;
		}
	}
}
