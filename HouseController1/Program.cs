using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HouseController1
{
	/// <summary>
	/// This program simulates a house with rooms and each room has components.
	/// There are areas with just lights, sector's with windows and lights, and
	/// rooms with doors windows and lights. The state of everything is shown on
	/// a console window. Commands can be typed, and upon pressing enter, the screen
	/// will refresh with the new state of every object.
	/// </summary>
	class Program
	{
		static House house;
		static Area[] areas;
		static string lastMessage = "";

		static void Main(string[] args)
		{
			// Make the console the perfect size for everything
			Console.SetWindowSize(Console.WindowWidth, 63);

			// Initialize the house
			house = new House();
			areas = house.areas.ToArray();

			// The loop. Runs every time you press enter
			while (true)
			{
				// Clears the window
				Console.Clear();

				// Write the status of each area (including it's components)
				foreach (Area area in areas)
				{
					WriteStatus(area);
				}

				// Write the last [error] message (if it exists)
				Console.WriteLine(lastMessage);

				// Handle the commmand typed in
				HandleCommand(Console.ReadLine());
			}
		}

		/// <summary>
		/// Handles the command typed
		/// </summary>
		/// <param name="fullCommand">The command typed</param>
		static void HandleCommand(string fullCommand)
		{
			// The possible next error message
			lastMessage = "";

			// The command typed
			string command = "";

			// The arguments for the command (the string version of the target)
			string fullTarget = "";
			
			// The target area of the command
			Area targetArea = null;

			// The target component of the command
			Component targetComp = null;

			// Try to parse the command and it's arguments
			try
			{
				command = fullCommand.Split(' ')[0];
				fullTarget = fullCommand.Split(' ')[1];

				// Gets the target area based on the selected index (- 1 because each index is nonzero)
				targetArea = areas[int.Parse(fullTarget.Split('.')[0]) - 1];

				// Gets the targeted component
				targetComp = targetArea.FindComponentByIndex(int.Parse(fullTarget.Split('.')[1]));
			}
			catch // The command entered was invalid
			{
				lastMessage = "Invalid command format";
				return;
			}
			
			try
			{
				switch (command)
				{
					case "lighton": // Turn on the light
						((Light)targetComp).ToggleOn();
						break;
					case "lightoff": // Turn off the light
						((Light)targetComp).ToggleOff();
						break;
					case "lighttoggle": // Toggle the light state
						((Light)targetComp).Toggle();
						break;
					case "doorlock": // Lock the door
						try
						{
							((Door)((Room)targetArea).FindComponentByIndex(int.Parse(fullTarget.Split('.')[1]))).Lock();
						}
						catch (InvalidOperationException ioe) // The door isn't lockable
						{
							lastMessage = ioe.Message;
						}
						break;
					case "doorunlock": // Unlock the door
						try
						{
							((Door)((Room)targetArea).FindComponentByIndex(int.Parse(fullTarget.Split('.')[1]))).Unlock();
						}
						catch (InvalidOperationException ioe) // The door isn't unlockable
						{
							lastMessage = ioe.Message;
						}
						break;
					case "doortoggle": // Toggle the state of the door
						try
						{
							((Door)((Room)targetArea).FindComponentByIndex(int.Parse(fullTarget.Split('.')[1]))).ToggleOpenOrClose();
						}
						catch (InvalidOperationException ioe) // The door was locked
						{
							lastMessage = ioe.Message;
						}
						break;
					case "dooropen": // Open the door
						try
						{
							((Door)((Room)targetArea).FindComponentByIndex(int.Parse(fullTarget.Split('.')[1]))).ToggleOpen();
						}
						catch (InvalidOperationException ioe) // The door was locked
						{
							lastMessage = ioe.Message;
						}
						break;
					case "doorclose": // Close the door
						try
						{
							((Door)((Room)targetArea).FindComponentByIndex(int.Parse(fullTarget.Split('.')[1]))).ToggleClose();
						}
						catch (InvalidOperationException ioe) // The door was locked
						{
							lastMessage = ioe.Message;
						}
						break;
					case "windowtoggle": // Toggle the state of the window
						((Window)((Sector)targetArea).FindComponentByIndex(int.Parse(fullTarget.Split('.')[1]))).ToggleOpenOrClose();
						break;
					case "windowopen": // Open the window
						((Window)((Sector)targetArea).FindComponentByIndex(int.Parse(fullTarget.Split('.')[1]))).ToggleOpen();
						break;
					case "windowclose": // Close the window
						((Window)((Sector)targetArea).FindComponentByIndex(int.Parse(fullTarget.Split('.')[1]))).ToggleClose();
						break;
					default: // The command was not recognized
						lastMessage = "Unknown command";
						break;
				}
			}
			catch (Exception e) // Probably, there was no object with that index
			{
				lastMessage = e.Message;
			}
		}

		/// <summary>
		/// Write the status of an IStateable and IIndexable to the console
		/// </summary>
		/// <typeparam name="T">The type of the IStateable and IIndexable</typeparam>
		/// <param name="area">The IStateable and IIndexable</param>
		static void WriteStatus<T>(T area)
			where T : IStateable, IIndexable
		{
			Console.WriteLine("[" + area.GetIndex() + "] " + area.GetStatus());
		}
	}
}
