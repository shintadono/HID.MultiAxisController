using System;

namespace HID.MultiAxisController
{
	/// <summary>
	/// Arguments provided by the handler for a translation event.
	/// </summary>
	public class SpaceMouseTranslationEventArgs : EventArgs
	{
		/// <summary>
		/// The handle of the device.
		/// </summary>
		public IntPtr hDevice;

		/// <summary>
		/// The translation x value.
		/// </summary>
		public short X;

		/// <summary>
		/// The translation y value.
		/// </summary>
		public short Y;

		/// <summary>
		/// The translation z value.
		/// </summary>
		public short Z;

		/// <summary>
		/// Constructs an empty instance.
		/// </summary>
		public SpaceMouseTranslationEventArgs() { }

		/// <summary>
		/// Constructs an instance with parameters set.
		/// </summary>
		/// <param name="hDevice">The handle of the device.</param>
		/// <param name="X">The translation x value.</param>
		/// <param name="Y">The translation y value.</param>
		/// <param name="Z">The translation z value.</param>
		public SpaceMouseTranslationEventArgs(IntPtr hDevice, short X, short Y, short Z)
		{
			this.hDevice=hDevice;
			this.X=X;
			this.Y=Y;
			this.Z=Z;
		}
	}
}
