using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseController1
{
	/// <summary>
	/// An object that can be toggled
	/// </summary>
	interface IToggleable
	{
		void Toggle();
		void ToggleOn();
		void ToggleOff();
	}
}
