using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseController1
{
	class Sector : Area
	{
		protected Window[] windows;

		public Sector(Window[] windows) : base(new Light[] { new Light(false) })
		{
			Initialize();
			this.windows = windows;			
		}

		private void Initialize()
		{

		}
	}
}
