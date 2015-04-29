using System.Runtime.InteropServices;

namespace HID.MultiAxisController
{
	/// <summary>
	/// Contains a dataset of a combined translation and rotation event record of a SpaceMouse/SpaceNavigator/SpaceExplorer/... raw input event.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct SpaceMouseTranslationRotationEventData
	{
		/// <summary>
		/// The shift in x-direction.
		/// </summary>
		public short X;

		/// <summary>
		/// The shift in y-direction.
		/// </summary>
		public short Y;

		/// <summary>
		/// The shift in z-direction.
		/// </summary>
		public short Z;

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
