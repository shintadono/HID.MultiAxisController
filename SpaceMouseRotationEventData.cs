using System.Runtime.InteropServices;

namespace HID.MultiAxisController
{
	/// <summary>
	/// Contains a dataset of a rotation event record of a SpaceMouse/SpaceNavigator/SpaceExplorer/... raw input event.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct SpaceMouseRotationEventData
	{
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
	}
}
