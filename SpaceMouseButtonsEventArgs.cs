using System;

namespace HID.MultiAxisController
{
	/// <summary>
	/// Arguments provided by the handler for a translation event.
	/// </summary>
	public class SpaceMouseButtonsEventArgs : EventArgs
	{
		/// <summary>
		/// The handle of the device.
		/// </summary>
		public IntPtr hDevice;

		/// <summary>
		/// The buttons.
		/// </summary>
		public SpaceMouseButtons Buttons;

		/// <summary>
		/// Constructs an empty instance.
		/// </summary>
		public SpaceMouseButtonsEventArgs() { }

		/// <summary>
		/// Constructs an instance with parameters set.
		/// </summary>
		/// <param name="hDevice">The handle of the device.</param>
		/// <param name="buttons">The button states.</param>
		public SpaceMouseButtonsEventArgs(IntPtr hDevice, SpaceMouseButtons buttons)
		{
			this.hDevice=hDevice;
			Buttons=buttons;
		}
	}
}
