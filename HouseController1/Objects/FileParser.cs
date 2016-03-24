using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace HouseController1.Objects
{
	/// <summary>
	/// Reads a house file and gets all the rooms and components from it
	/// </summary>
	class FileParser
	{
		string path;
				
		/// <summary>
		/// Creates a new file parser to parse a certain file
		/// </summary>
		/// <param name="path">The path of the file to be parsed</param>
		public FileParser(string path)
		{
			this.path = path;
		}

		/// <summary>
		/// The main method that gets all of the areas and each of their components from the file
		/// </summary>
		/// <returns>An array with every area in the file</returns>
		public Area[] GetAllAreas()
		{
			// A list of the areas found so far
			List<Area> areaList = new List<Area>();

			// The lines read from the file
			string[] lines = File.ReadAllLines(path);

			// Goes through each line
			for (int i = 0; i < lines.Length; i++)
			{
				// Gets the index for the area on the current line
				int index = int.Parse(lines[i].Split(':')[0].Split('.')[0]);
				// Gets the name for the area on the current line
				string name = lines[i].Split(':')[0].Split('.')[1];
				// Gets the data for the area on this line
				char[] data = lines[i].Split(':')[1].ToCharArray();

				// Check what type of area this is and use the respective method
				if (data.Contains('D')) // If it has a door it's a room
				{
					areaList.Add(GetRoom(index, name, data));
				}
				else if (data.Contains('W')) // If it has a window it's a sector
				{
					areaList.Add(GetSector(index, name, data));
				}
				else // Otherwise it's an area
				{
					areaList.Add(GetArea(index, name, data));
				}
			}

			return areaList.ToArray();
		}

		/// <summary>
		/// Gets only the areas in the entire collection of areas
		/// </summary>
		/// <returns>All the areas</returns>
		public Area[] GetAreas()
		{
			// The list of areas found so far
			List<Area> areaList = new List<Area>();

			// Go through every area
			foreach (Area area in GetAllAreas())
			{
				// If it's not a sector and it's not a room it's an area
				if (!(area is Sector || area is Room))
				{
					areaList.Add(area);
				}
			}

			return areaList.ToArray();
		}

		/// <summary>
		/// Get's only the sectors in the entire collection of areas
		/// </summary>
		/// <returns>All the sectors</returns>
		public Sector[] GetSectors()
		{
			// The list of sectors found so far
			List<Sector> sectorList = new List<Sector>();

			// Go through every area
			foreach (Area area in GetAllAreas())
			{
				// If it's not an area and it's not a room, it's a sector
				if (!(area is Area || area is Room))
				{
					sectorList.Add((Sector)area);
				}
			}

			return sectorList.ToArray();
		}

		/// <summary>
		/// Get's only the rooms in the entire collection of areas
		/// </summary>
		/// <returns>All the rooms</returns>
		public Area[] GetRooms()
		{
			// The list of rooms found so far
			List<Room> roomList = new List<Room>();

			// Go through every area
			foreach (Area area in GetAllAreas())
			{
				// If it's not an area and it's not a sector, it's a room
				if (!(area is Area || area is Sector))
				{
					roomList.Add((Room)area);
				}
			}

			return roomList.ToArray();
		}

		/// <summary>
		/// Get's the room from data
		/// </summary>
		/// <param name="index">The index of the new room</param>
		/// <param name="name">The name of the new room</param>
		/// <param name="data">The data of the components to parse to get this new room</param>
		/// <returns>The new room</returns>
		public Room GetRoom(int index, string name, char[] data)
		{
			// The door
			Door door = null;
			// List of windows
			List<Window> windowList = new List<Window>();
			// List of lights
			List<Light> lightList = new List<Light>();

			// For each component found in the data of this room
			foreach (Component comp in GetComponents(data))
			{
				// Parse the data for it's components, check each type and add it to the respective list
				if (comp is Door)
				{
					door = (Door)comp;
				}
				else if (comp is Window)
				{
					windowList.Add((Window)comp);
				}
				else if (comp is Light)
				{
					lightList.Add((Light)comp);
				}
			}

			return new Room(index, name, door, windowList.ToArray(), lightList.ToArray()); // Return the new room
		}

		/// <summary>
		/// Get's the sector from data
		/// </summary>
		/// <param name="index">The index of the new sector</param>
		/// <param name="name">The name of the new sector</param>
		/// <param name="data">The data of the components to parse to get this new sector</param>
		/// <returns>The new sector</returns>
		public Sector GetSector(int index, string name, char[] data)
		{
			// The windows
			List<Window> windowList = new List<Window>();
			// The lights
			List<Light> lightList = new List<Light>();

			// Parse the data for it's components, check each type and add it to the respective list
			foreach (Component comp in GetComponents(data))
			{
				if (comp is Window)
				{
					windowList.Add((Window)comp);
				}
				else if (comp is Light)
				{
					lightList.Add((Light)comp);
				}
			}

			return new Sector(index, name, windowList.ToArray(), lightList.ToArray()); // Return the new sector
		}

		/// <summary>
		/// Get's the area from data
		/// </summary>
		/// <param name="index">The index of the new area</param>
		/// <param name="name">The name of the new area</param>
		/// <param name="data">The data of the components to parse to get this new area</param>
		/// <returns>The new area</returns>
		public Area GetArea(int index, string name, char[] data)
		{
			// The lights
			List<Light> lightList = new List<Light>();

			// Parse the data for it's components, check each type and add it to the respective list
			foreach (Component comp in GetComponents(data))
			{
				if (comp is Light)
				{
					lightList.Add((Light)comp);
				}
			}

			return new Area(index, name, lightList.ToArray()); // The new room
		}

		/// <summary>
		/// Get's the components from data
		/// </summary>
		/// <param name="data">The data to parse for components</param>
		/// <returns>An array of components</returns>
		private Component[] GetComponents(char[] data)
		{
			// List of components found so far
			List<Component> componentsList = new List<Component>();

			// Go through each character in the data
			for (int i = 0; i < data.Length; i++)
			{
				// Keep going until we hit a component, then parse this component
				if (data[i] == 'L' || data[i] == 'W' || data[i] == 'D')
				{
					// Gets the data for this specific component
					char[] componentData = GetComponentData(data, i);

					// Get's the index of this component
					int index = GetComponentIndex(GetFullComponentData(data, i));
					
					// Check the type of this component and add it to it's respective list
					switch (data[i])
					{
						case 'L': // It's a light
							componentsList.Add(new Light(index, IsTrueValue(componentData[0])));
							break;
						case 'W': // It's  window
							componentsList.Add(new Window(index, IsTrueValue(componentData[0]), IsTrueValue(componentData[1])));
							break;
						case 'D': // It's a door
							componentsList.Add(new Door(index, IsTrueValue(componentData[0]), IsTrueValue(componentData[1]), IsTrueValue(componentData[2])));
							break;
					}
				}
			}

			return componentsList.ToArray();
		}

		/// <summary>
		/// Gets the index of a component based on it's data
		/// </summary>
		/// <param name="componentData">The data of the component</param>
		/// <returns>The index of the components</returns>
		private int GetComponentIndex(char[] componentData)
		{
			return int.Parse(new string(componentData).Split('.')[0]);
		}

		/// <summary>
		/// Gets the data of an individual component excluding the index
		/// </summary>
		/// <param name="fullData">The data for all of the components</param>
		/// <param name="componentStartIndex">The index in fullData where the component we want starts</param>
		/// <returns>Data of a component without the index</returns>
		private char[] GetComponentData(char[] fullData, int componentStartIndex)
		{
			// Get the full component data as a string
			string stringData = new string(GetFullComponentData(fullData, componentStartIndex));

			// Split the string by a dot (the end of index data) and return the second part as a char array
			return stringData.Split('.')[1].ToCharArray();
		}

		/// <summary>
		/// Get's the data of a component including the index data
		/// </summary>
		/// <param name="fullData">The data for all of the components</param>
		/// <param name="componentStartIndex">The index in fullData where the component we want starts</param>
		/// <returns></returns>
		private char[] GetFullComponentData(char[] fullData, int componentStartIndex)
		{
			// The data for the individual component
			List<char> compData = new List<char>();

			// Go through the data starting from the start of the data for the individual component until we hit the end of this component
			for (int i = componentStartIndex + 1; i < fullData.Length; i++)
			{
				// Check if we've hit the end of this component
				if (fullData[i] == 'L' || fullData[i] == 'W' || fullData[i] == 'D' || fullData[i] == 'E')
				{
					return compData.ToArray(); // Return the finished product
				}
				else // If we didn't reach the end of this component
				{
					// Add the data to the buffer for the component data
					compData.Add(fullData[i]);
				}
			}

			return null;
		}

		/// <summary>
		/// Checks if a char indicates true or false ('0' or '1')
		/// </summary>
		/// <param name="a">A char</param>
		/// <returns>true or false</returns>
		private bool IsTrueValue(char a)
		{
			if (a == '0')
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
