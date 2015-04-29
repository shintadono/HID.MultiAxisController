using System.Runtime.InteropServices;

namespace HID.MultiAxisController
{
	/// <summary>
	/// Contains a dataset of a translation event record of a SpaceMouse/SpaceNavigator/SpaceExplorer/... raw input event.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct SpaceMouseTranslationEventData
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
	}
}
