using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseController1
{
	/// <summary>
	/// A light
	/// </summary>
	class Light : Component, IToggleable, IStateable, IIndexable
	{
		bool status;

		/// <summary>
		/// Creates a light
		/// </summary>
		/// <param name="index">The index of this light</param>
		/// <param name="status">The status of this light</param>
		public Light(int index, bool status) : base(index)
		{
			this.status = status;
		}

		/// <summary>
		/// Toggles the state of this light
		/// </summary>
		public void Toggle()
		{
			status = !status;
		}

		/// <summary>
		/// Turns this light off
		/// </summary>
		public void ToggleOff()
		{
			status = false;
		}

		/// <summary>
		/// Turns this light on
		/// </summary>
		public void ToggleOn()
		{
			status = true;
		}

		/// <summary>
		/// Returns the status of this light as a string
		/// </summary>
		/// <returns>"On" or "Off"</returns>
		public string GetStatus()
		{
			if (status)
			{
				return "On";
			}
			else
			{
				return "Off";
			}
		}

		public string GetName()
		{
			throw new NotImplementedException();
		}
	}
}
