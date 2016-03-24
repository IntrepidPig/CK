using System.Collections.Generic;
using HouseController1.Objects;

namespace HouseController1
{
	/// <summary>
	/// A house
	/// </summary>
	class House
	{
		public List<Area> areas;

		/// <summary>
		/// Creates a house
		/// </summary>
		public House()
		{
			Initialize();
		}

		/// <summary>
		/// Initializes the house from a file
		/// </summary>
		private void Initialize()
		{
			// A FileParser to parse the file
			FileParser fp = new FileParser(@"C:\Users\virus\Documents\Visual Studio 2015\Projects\HouseController1\HouseController1\Objects\house.txt");

			// Parse the file and save the areas to the house
			areas = new List<Area>(fp.GetAllAreas());
		}
	}
}
