using System.Runtime.InteropServices;

namespace HID.MultiAxisController
{
	/// <summary>
	/// Contains a rotation event record of a SpaceMouse/SpaceNavigator/SpaceExplorer/... raw input event.
	/// </summary>
	/// <remarks>This structure follows <see cref="Win32.RawInput.RAWINPUTHEADER"/> in a
	/// <see cref="Win32.WM.INPUT">WM_INPUT</see> raw input dataset.</remarks>
	[StructLayout(LayoutKind.Sequential, Pack=1)]
	public struct SpaceMouseRotationEvent
	{
		/// <summary>
		/// The raw input HID with SpaceMouseEventType value.
		/// </summary>
		public SpaceMouseEventHeader Header;

		/// <summary>
		/// The actual SpaceMouse rotation event data. Multiple more of this dataset may follow,
		/// depending on <see cref="SpaceMouseEventHeader.dwCount">SpaceMouseButtonsEvent.Header.dwCount</see>.
		/// </summary>
		public SpaceMouseRotationEventData Data;
	}
}
