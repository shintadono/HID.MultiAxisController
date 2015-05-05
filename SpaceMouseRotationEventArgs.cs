using System;

namespace HID.MultiAxisController
{
	/// <summary>
	/// Arguments provided by the handler for a rotation event.
	/// </summary>
	public class SpaceMouseRotationEventArgs : EventArgs
	{
		/// <summary>
		/// The handle of the device.
		/// </summary>
		public IntPtr hDevice;

		/// <summary>
		/// The rotation around the x-axis.
		/// </summary>
		public short RX;

		/// <summary>
		/// The rotation around the y-axis.
		/// </summary>
		public short RY;

		/// <summary>
		/// The rotation around the z-axis.
		/// </summary>
		public short RZ;

		/// <summary>
		/// Constructs an empty instance.
		/// </summary>
		public SpaceMouseRotationEventArgs() { }

		/// <summary>
		/// Constructs an instance with parameters set.
		/// </summary>
		/// <param name="hDevice">The handle of the device.</param>
		/// <param name="RX">The rotation around the x-axis.</param>
		/// <param name="RY">The rotation around the y-axis.</param>
		/// <param name="RZ">The rotation around the z-axis.</param>
		public SpaceMouseRotationEventArgs(IntPtr hDevice, short RX, short RY, short RZ)
		{
			this.hDevice=hDevice;
			this.RX=RX;
			this.RY=RY;
			this.RZ=RZ;
		}
	}
}
