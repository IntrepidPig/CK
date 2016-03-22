using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseController1
{
	class Door : IToggleable, ILockable
	{
		bool openStatus
		{
			get { return openStatus; }
			set
			{
				if (value != openStatus)
				{
					if (!lockStatus)
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
		bool lockStatus
		{
			get { return lockStatus; }
			set
			{
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
		readonly bool lockable;

		public Door(bool lockable)
		{
			this.lockable = lockable;
			this.openStatus = false;
			if (lockable)
			{
				lockStatus = false;
			}
		}

		public void Toggle()
		{
			openStatus = !openStatus;
		}

		public void ToggleOn()
		{
			lockStatus = true;
		}

		public void ToggleOff()
		{
			lockStatus = false;
		}

		public void Lock()
		{
			lockStatus = true;
		}

		public void Unlock()
		{
			lockStatus = false;
		}
	}
}
