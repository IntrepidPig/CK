using System.Diagnostics;
namespace HouseController1
{
	/// <summary>
	/// An area with a door, windows and lights
	/// </summary>
	class Room : Sector, IStateable, IIndexable
	{
		public Door door;

		/// <summary>
		/// Constructor for a room
		/// </summary>
		/// <param name="index">Index of the room</param>
		/// <param name="name">Name of the room</param>
		/// <param name="door">The door for this room</param>
		/// <param name="windows">The windows for this room</param>
		/// <param name="lights">The lights for this room</param>
		public Room(int index, string name, Door door, Window[] windows, Light[] lights) : base(index, name, windows, lights)
		{
			this.door = door;
		}

		/// <summary>
		/// Gets the component with the specified index
		/// </summary>
		/// <param name="index">The index of the target component</param>
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
			
			if (door.GetIndex() == index)
			{
				
				return door;
			}
						
			return null;
		}

		/// <summary>
		/// The status of the room, including all components
		/// </summary>
		/// <returns>The status of the room</returns>
		public new string GetStatus()
		{
			// The name of the room
			string status = name + ":\n";

			// Each component will have its status indented
			for (int i = 0; i < lights.Length; i++)
			{
				status += "\t[" + lights[i].GetIndex() + "] Light: " + lights[i].GetStatus() + "\n";
			}

			for (int i = 0; i < windows.Length; i++)
			{
				status += "\t[" + windows[i].GetIndex() + "] Window: " + windows[i].GetStatus() + "\n";
			}

			status += "\t[" + door.GetIndex() + "] Door: " + door.GetStatus() + "\n";

			return status;
		}
	}
}
