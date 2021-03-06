﻿using System.Runtime.InteropServices;

namespace HID.MultiAxisController
{
	/// <summary>
	/// Contains a dataset of a buttons event record of a SpaceMouse/SpaceNavigator/SpaceExplorer/... raw input event.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct SpaceMouseButtonsEventData
	{
		/// <summary>
		/// Bitfield containing the buttons state. This has to be translated into the actual buttons.
		/// </summary>
		public uint ButtonState;
	}
}
