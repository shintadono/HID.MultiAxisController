using System.Runtime.InteropServices;

namespace HID.MultiAxisController
{
	/// <summary>
	/// Contains the header of a event record of a SpaceMouse/SpaceNavigator/SpaceExplorer/... raw input event.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack=1)]
	public struct SpaceMouseEventHeader
	{
		/// <summary>
		/// The size, in bytes, of each HID input in the raw data array that follows this structure.
		/// </summary>
		public uint dwSizeHid;

		/// <summary>
		/// The number of HID inputs in the raw data array that follows this structure.
		/// </summary>
		public uint dwCount;

		/// <summary>
		/// Type of the following data structure(s).
		/// </summary>
		public SpaceMouseEventType eventType;

		/// <summary>
		/// Size, in bytes, of this structure.
		/// </summary>
		public static readonly int SIZE=Marshal.SizeOf(typeof(SpaceMouseEventHeader));
	}
}
