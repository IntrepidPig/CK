using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseController1
{
	/// <summary>
	/// An area with windows and lights
	/// </summary>
	class Sector : Area, IStateable, IIndexable
	{
		public Window[] windows;

		/// <summary>
		/// Creates a sector
		/// </summary>
		/// <param name="index">The index of the sector</param>
		/// <param name="name">The name of the sector</param>
		/// <param name="windows">The windows in this sector</param>
		/// <param name="lights">The lights in this sector</param>
		public Sector(int index, string name, Window[] windows, Light[] lights) : base(index, name, lights)
		{
			this.windows = windows;
		}

		/// <summary>
		/// Gets the component with the specified index in this sector
		/// </summary>
		/// <param name="index">The target index</param>
		/// <returns>The component with the specified index</returns>
		public new Component FindComponentByIndex(int index)
		{
			foreach (Light light in lights)
			{
				if (light.GetIndex() == index)
				{
					return light;
				}
			}

			foreach (Window window in windows)
			{
				if (window.GetIndex() == index)
				{
					return window;
				}
			}
			return null;
		}

		/// <summary>
		/// The status of the sector, including all components
		/// </summary>
		/// <returns>The status of the sector</returns>
		public new string GetStatus()
		{
			string status = name + ":\n";

			for (int i = 0; i < lights.Length; i++)
			{
				status += "\t[" + lights[i].GetIndex() + "] Light: " + lights[i].GetStatus() + "\n";
			}

			for (int i = 0; i < windows.Length; i++)
			{
				status += "\t[" + windows[i].GetIndex() + "] Window: " + windows[i].GetStatus() + "\n";
			}

			return status;
		}
	}
}
