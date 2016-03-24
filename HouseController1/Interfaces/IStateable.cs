using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseController1
{
	/// <summary>
	/// An object with a name and printable status
	/// </summary>
	interface IStateable
	{
		string GetName();
		string GetStatus();
	}
}
