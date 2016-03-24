using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseController1
{
	abstract class Component : IIndexable
	{
		int index;

		public Component(int index)
		{
			this.index = index;
		}

		public int GetIndex()
		{
			return index;
		}
	}
}
