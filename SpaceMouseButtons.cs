using System;

namespace HID.MultiAxisController
{
	/// <summary>
	/// Defines the buttons of a SpaceMouse/SpaceNavigator/SpaceExplorer/... device.
	/// </summary>
	[Flags]
	[CLSCompliant(false)]
	public enum SpaceMouseButtons : ulong
	{
		/// <summary>
		/// No button pressed.
		/// </summary>
		NONE=0x0000000000000000,

		/// <summary>
		/// PANEL/MENU button pressed.
		/// </summary>
		PANEL=0x0000000000000001,

		/// <summary>
		/// FIT button pressed.
		/// </summary>
		FIT=0x0000000000000002,

		/// <summary>
		/// T/TOP button pressed.
		/// </summary>
		TOP=0x0000000000000004,

		/// <summary>
		/// L/LEFT button pressed.
		/// </summary>
		LEFT=0x0000000000000008,

		/// <summary>
		/// R/RIGHT button pressed.
		/// </summary>
		RIGHT=0x0000000000000010,

		/// <summary>
		/// F/FRONT button pressed.
		/// </summary>
		FRONT=0x0000000000000020,

		/// <summary>
		/// BOTTOM button pressed.
		/// </summary>
		BOTTOM=0x0000000000000040,

		/// <summary>
		/// BACK button pressed.
		/// </summary>
		BACK=0x0000000000000080,

		/// <summary>
		/// ROLL-CW button pressed.
		/// </summary>
		ROLL_CW=0x0000000000000100,

		/// <summary>
		/// ROLL-CCW button pressed.
		/// </summary>
		ROLL_CCW=0x0000000000000200,

		/// <summary>
		/// ISO1 button pressed.
		/// </summary>
		ISO1=0x0000000000000400,

		/// <summary>
		/// ISO2 button pressed.
		/// </summary>
		ISO2=0x0000000000000800,

		/// <summary>
		/// Button 1 pressed.
		/// </summary>
		BUTTON1=0x0000000000001000,

		/// <summary>
		/// Button 2 pressed.
		/// </summary>
		BUTTON2=0x0000000000002000,

		/// <summary>
		/// Button 3 pressed.
		/// </summary>
		BUTTON3=0x0000000000004000,

		/// <summary>
		/// Button 4 pressed.
		/// </summary>
		BUTTON4=0x0000000000008000,

		/// <summary>
		/// Button 5 pressed.
		/// </summary>
		BUTTON5=0x0000000000010000,

		/// <summary>
		/// Button 6 pressed.
		/// </summary>
		BUTTON6=0x0000000000020000,

		/// <summary>
		/// Button 7 pressed.
		/// </summary>
		BUTTON7=0x0000000000040000,

		/// <summary>
		/// Button 8 pressed.
		/// </summary>
		BUTTON8=0x0000000000080000,

		/// <summary>
		/// Button 9 pressed.
		/// </summary>
		BUTTON9=0x0000000000100000,

		/// <summary>
		/// Button 10 pressed.
		/// </summary>
		BUTTON10=0x0000000000200000,

		/// <summary>
		/// ESC button pressed.
		/// </summary>
		ESCAPE=0x0000000000400000,

		/// <summary>
		/// ALT button pressed.
		/// </summary>
		ALT=0x0000000000800000,

		/// <summary>
		/// SHIFT button pressed.
		/// </summary>
		SHIFT=0x0000000001000000,

		/// <summary>
		/// CTRL button pressed.
		/// </summary>
		CTRL=0x0000000002000000,

		/// <summary>
		/// ROTATE/2D button pressed.
		/// </summary>
		ROTATE=0x0000000004000000,

		/// <summary>
		/// PANZOOM button pressed.
		/// </summary>
		PANZOOM=0x0000000008000000,

		/// <summary>
		/// DOMINANT button pressed.
		/// </summary>
		DOMINANT=0x0000000010000000,

		/// <summary>
		/// + button pressed.
		/// </summary>
		PLUS=0x0000000020000000,

		/// <summary>
		/// - button pressed.
		/// </summary>
		MINUS=0x0000000040000000,

		/// <summary>
		/// SPIN-CW button pressed.
		/// </summary>
		SPIN_CW=0x0000000080000000,

		/// <summary>
		/// SPIN-CCW button pressed.
		/// </summary>
		SPIN_CCW=0x0000000100000000,

		/// <summary>
		/// TILT-CW button pressed.
		/// </summary>
		TILT_CW=0x0000000200000000,

		/// <summary>
		/// TILT-CCW button pressed.
		/// </summary>
		TILT_CCW=0x0000000400000000,

		/// <summary>
		/// UI button pressed.
		/// </summary>
		UI=0x0000000800000000,

		///// <summary>
		///// USER button pressed.
		///// </summary>
		//USER=0x0000001000000000,
	}
}
