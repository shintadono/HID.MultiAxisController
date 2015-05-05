using System;

namespace HID.MultiAxisController
{
	/// <summary>
	/// Product IDs for supported devices.
	/// </summary>
	[CLSCompliant(false)]
	public static class ProductID
	{
		/// <summary>
		/// Aerion/GlobeFish/GlobeMouse device? <b>NOTE:</b> Not supported?
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Aerion"/>.</remarks>
		public const uint Aerion=0x2013;

		/// <summary>
		/// SpaceMouse Plus
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpaceMousePlus=0xc603;

		/// <summary>
		/// CAD Man
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint CADMan=0xc605;

		/// <summary>
		/// SpaceMouse Classic
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpaceMouseClassic=0xc606;

		/// <summary>
		/// SpaceBall 5000
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpaceBall5000=0xc621;

		/// <summary>
		/// SpaceTraveler
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpaceTraveler=0xc623;

		/// <summary>
		/// SpacePilot
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpacePilot=0xc625;

		/// <summary>
		/// SpaceNavigator
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpaceNavigator=0xc626;

		/// <summary>
		/// SpaceExplorer
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpaceExplorer=0xc627;

		/// <summary>
		/// SpaceNavigator for Notebooks
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpaceNavigatorforNotebooks=0xc628;

		/// <summary>
		/// SpacePilot Pro
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpacePilotPro=0xc629;

		/// <summary>
		/// SpaceMouse Pro
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpaceMousePro=0xc62b;

		/// <summary>
		/// SpaceMouse Touch
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.D3connexion"/>.</remarks>
		public const uint SpaceMouseTouch=0xc62c;

		/// <summary>
		/// SpaceMouse
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.D3connexion"/>.</remarks>
		public const uint SpaceMouse=0xc62d;

		/// <summary>
		/// SpaceMouse Wireless
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.D3connexion"/>.</remarks>
		public const uint SpaceMouseWireless=0xc62e;

		/// <summary>
		/// SpaceMouse Wireless Receiver
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.D3connexion"/>.</remarks>
		public const uint SpaceMouseWirelessReceiver=0xc62f;

		/// <summary>
		/// SpaceMouse Pro Wireless
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.D3connexion"/>.</remarks>
		public const uint SpaceMouseProWireless=0xc631;

		/// <summary>
		/// SpaceMouse Pro Wireless Receiver
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.D3connexion"/>.</remarks>
		public const uint SpaceMouseProWirelessReceiver=0xc632;

		/// <summary>
		/// Scout
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.D3connexion"/>.</remarks>
		public const uint Scout=0xc641;

		/// <summary>
		/// Euclid
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.D3connexion"/>.</remarks>
		public const uint Euclid=0xc650;
	}
}
