using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseController1
{
	/// <summary>
	/// A window. Can be openable
	/// </summary>
	class Window : Component, IOpenable, IStateable, IIndexable
	{
		int index;
		bool openStatus;
		readonly bool openable;

		/// <summary>
		/// Whether the window is open or not.
		/// </summary>
		bool OpenStatus
		{
			get { return openStatus; }
			set
			{
				// Check if the target status if different from the current status
				if (value != openStatus)
				{
					// Make sure the window is openable
					if (openable)
					{
						openStatus = value;
					}
					else
					{
						throw new InvalidOperationException("This window can't be opened");
					}
				}
			}
		}

		/// <summary>
		/// The simple constructor, creates a window painlessly
		/// </summary>
		/// <param name="index">The index of this window</param>
		/// <param name="openable">Whether this window can be opened</param>
		public Window(int index, bool openable) : base(index)
		{
			this.openable = openable;
			this.openStatus = false;
			this.index = index;
		}

		/// <summary>
		/// The full constructor for a window
		/// </summary>
		/// <param name="index">The index of this window</param>
		/// <param name="openStatus">Whether this window is open</param>
		/// <param name="openable">Whether this window can be opened</param>
		public Window(int index, bool openStatus, bool openable) : base(index)
		{
			this.openStatus = openStatus;
			this.openable = openable;
		}

		/// <summary>
		/// Gets this windows open state as a string
		/// </summary>
		/// <returns>"Open" or "Closed"</returns>
		public string GetStatus()
		{
			if (openStatus)
			{
				return "Open";
			}
			else
			{
				return "Closed";
			}
		}

		/// <summary>
		/// Toggles the open state of this window
		/// </summary>
		public void ToggleOpenOrClose()
		{
			OpenStatus = !OpenStatus;
		}

		/// <summary>
		/// Opens the window
		/// </summary>
		public void ToggleOpen()
		{
			OpenStatus = true;
		}

		/// <summary>
		/// Closes the window
		/// </summary>
		public void ToggleClose()
		{
			OpenStatus = false;
		}

		public string GetName()
		{
			throw new NotImplementedException();
		}
	}
}
