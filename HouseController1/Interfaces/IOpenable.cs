using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseController1
{
	/// <summary>
	/// An object that can be opened
	/// </summary>
	interface IOpenable
	{
		void ToggleOpenOrClose();
		void ToggleOpen();
		void ToggleClose();
	}
}
