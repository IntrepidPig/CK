using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseController1
{
	/// <summary>
	/// An area with only lights
	/// </summary>
	class Area : IStateable, IIndexable
	{
		int index;
		public string name;
		public Light[] lights;

		/// <summary>
		/// Creates an area
		/// </summary>
		/// <param name="index">The index of this area</param>
		/// <param name="name">The name of this area</param>
		/// <param name="lights">The lights in this area</param>
		public Area(int index, string name, Light[] lights)
		{
			this.name = name;
			this.lights = lights;
			this.index = index;
		}

		/// <summary>
		/// Gets the name of this area
		/// </summary>
		/// <returns>The name of this area</returns>
		public string GetName()
		{
			return name;
		}

		/// <summary>
		/// The status of the area, including all components
		/// </summary>
		/// <returns>The status of the area</returns>
		public string GetStatus()
		{
			string status = name + ":\n";

			for (int i = 0; i < lights.Length; i++)
			{
				status += "\t[" + lights[i].GetIndex() + "] Light: " + lights[i].GetStatus() + "\n";
			}

			return status;
		}

		/// <summary>
		/// Gets the component with the specified index
		/// </summary>
		/// <param name="index">The target index</param>
		/// <returns>The component with the specified index</returns>
		public Component FindComponentByIndex(int index)
		{
			foreach (Light light in lights)
			{
				if (light.GetIndex() == index)
				{
					return light;
				}
			}
			return null;
		}

		/// <summary>
		/// Gets the index of this area
		/// </summary>
		/// <returns>The index of this area</returns>
		public int GetIndex()
		{
			return index;
		}
	}
}
