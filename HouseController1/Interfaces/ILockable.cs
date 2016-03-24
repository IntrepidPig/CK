using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseController1
{
	/// <summary>
	/// An object that can be locked
	/// </summary>
	interface ILockable
	{
		void Lock();
		void Unlock();
	}
}
