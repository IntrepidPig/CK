using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseController1
{
	class Light : IToggleable
	{
		bool status;

		public Light(bool status)
		{
			this.status = status;
		}

		public void Toggle()
		{
			status = !status;
		}

		public void ToggleOff()
		{
			status = false;
		}

		public void ToggleOn()
		{
			status = true;
		}
	}
}
