using System;

namespace HID.MultiAxisController
{
	/// <summary>
	/// Contains Vendor IDs for makers of supported devices.
	/// </summary>
	[CLSCompliant(false)]
	public static class VendorID
	{
		/// <summary>
		/// Aerion/GlobeFish/GlobeMouse? <b>NOTE:</b> Not supported?
		/// </summary>
		public const uint Aerion=0x3eb;

		/// <summary>
		/// 3Dconnexion (for newer SpaceMouse devices)
		/// </summary>
		public const uint D3connexion=0x256f;

		/// <summary>
		/// Logitech (for older SpaceMouse, SpaceNavigator, etc. devices)
		/// </summary>
		public const uint Logitech=0x046d;
	}
}
