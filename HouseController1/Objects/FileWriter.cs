using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseController1.Objects
{
	/// <summary>
	/// To save the data to the house file
	/// </summary>
	class FileWriter
	{
		string path;

		public FileWriter(string path)
		{
			this.path = path;
		}

		public void WriteData(Area[] areas, Sector[] sectors, Room[] rooms)
		{

		}
	}
}
