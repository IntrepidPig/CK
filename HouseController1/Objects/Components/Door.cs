using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseController1
{
	/// <summary>
	/// A door that can be locked and unlocked, and be lockable
	/// </summary>
	class Door : Component, IOpenable, IStateable, ILockable, IIndexable
	{
		bool openStatus;
		bool lockStatus;
		readonly bool lockable;

		/// <summary>
		/// Whether this door is open or not
		/// </summary>
		bool OpenStatus
		{
			get { return openStatus; }
			set
			{
				// Check if the target state is different from the current state
				if (value != openStatus)
				{
					// Make sure it's not locked
					if (!LockStatus)
					{
						openStatus = value;
					}
					else
					{
						throw new InvalidOperationException("This door is locked!");
					}
				}
			}
		}
		/// <summary>
		/// Whether this door is locked or not
		/// </summary>
		bool LockStatus
		{
			get { return lockStatus; }
			set
			{
				// Make sure this door has a lock
				if (lockable)
				{
					lockStatus = value;
				}
				else
				{
					lockStatus = false;
					throw new InvalidOperationException("This door has no lock!");
				}
			}
		}

		/// <summary>
		/// Creates a simple door with default values
		/// </summary>
		/// <param name="index">The index of this door</param>
		/// <param name="lockable">Whether this door is lockable</param>
		public Door(int index, bool lockable) : base(index)
		{
			this.lockable = lockable;
			this.OpenStatus = false;
			if (lockable)
			{
				LockStatus = false;
			}
		}

		/// <summary>
		/// The full door constructor
		/// </summary>
		/// <param name="index">The index of this door</param>
		/// <param name="openStatus">Whether this door is open or not</param>
		/// <param name="lockStatus">Whether this door is locked or not</param>
		/// <param name="lockable">Whether this door is lockable or not</param>
		public Door(int index, bool openStatus, bool lockStatus, bool lockable) : base(index)
		{
			this.openStatus = openStatus;
			this.lockStatus = lockStatus;
			this.lockable = lockable;
		}

		/// <summary>
		/// Gets the open state and lock state as a string
		/// </summary>
		/// <returns>Open or closed and locked or unlocked</returns>
		public string GetStatus()
		{
			string value = "";
			if (OpenStatus)
			{
				value += "Open";
			}
			else
			{
				value += "Closed";
			}
			value += ", ";
			if (LockStatus)
			{
				value += "Locked";
			}
			else
			{
				value += "Unlocked";
			}
			return value;
		}

		/// <summary>
		/// Locks the door
		/// </summary>
		public void Lock()
		{
			LockStatus = true;
		}

		/// <summary>
		/// Unlocks the door
		/// </summary>
		public void Unlock()
		{
			LockStatus = false;
		}

		/// <summary>
		/// Toggles the door state
		/// </summary>
		public void ToggleOpenOrClose()
		{
			OpenStatus = !OpenStatus;
		}

		/// <summary>
		/// Open the door
		/// </summary>
		public void ToggleOpen()
		{
			OpenStatus = true;
		}

		/// <summary>
		/// Close the door
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
