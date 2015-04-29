using System;

namespace HID.MultiAxisController
{
	/// <summary>
	/// Defines the buttons of a SpaceMouse/SpaceNavigator/SpaceExplorer/...
	/// </summary>
	[Flags]
	[CLSCompliant(false)]
	public enum SpaceMouseButtons : uint
	{
		/// <summary>
		/// No button pressed.
		/// </summary>
		NONE=0x0000,

		/// <summary>
		/// Button 1 pressed.
		/// </summary>
		ONE=0x0001,

		/// <summary>
		/// Button 2 pressed.
		/// </summary>
		TWO=0x0002,

		/// <summary>
		/// T button pressed.
		/// </summary>
		T=0x0004,
		/// <summary>
		/// L button pressed.
		/// </summary>
		L=0x0008,

		/// <summary>
		/// R button pressed.
		/// </summary>
		R=0x0010,

		/// <summary>
		/// F button pressed.
		/// </summary>
		F=0x0020,

		/// <summary>
		/// ESC button pressed.
		/// </summary>
		ESCAPE=0x0040,

		/// <summary>
		/// ALT button pressed.
		/// </summary>
		ALT=0x0080,

		/// <summary>
		/// SHIFT button pressed.
		/// </summary>
		SHIFT=0x0100,

		/// <summary>
		/// CTRL button pressed.
		/// </summary>
		CTRL=0x0200,

		/// <summary>
		/// FIT button pressed.
		/// </summary>
		FIT=0x0400,

		/// <summary>
		/// PANEL button pressed.
		/// </summary>
		PANEL=0x0800,

		/// <summary>
		/// + button pressed.
		/// </summary>
		PLUS=0x1000,

		/// <summary>
		/// - button pressed.
		/// </summary>
		MINUS=0x2000,

		/// <summary>
		/// 2D button pressed.
		/// </summary>
		D2=0x4000,
	}
}
