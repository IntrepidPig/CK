using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseController1
{
	class Room : Sector
	{
		Door door;
		new Window[] windows;

		public Room(Door door, Window[] windows)
		{
			
			Initialize();
			this.door = door;
			base.windows = windows;
		}

		public void Initialize()
		{
			
		}
	}
}
