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
		/// SpaceMouse
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpaceMouse=0xC603;

		/// <summary>
		/// CAD Man
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint CADMan=0xC605;

		/// <summary>
		/// SpaceMouse Classic
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpaceMouseClassic=0xC606;

		/// <summary>
		/// SpaceBall 5000
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpaceBall5000=0xC621;

		/// <summary>
		/// SpaceTraveler
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpaceTraveler=0xC623;

		/// <summary>
		/// SpacePilot
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpacePilot=0xC625;

		/// <summary>
		/// SpaceNavigator
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpaceNavigator=0xC626;

		/// <summary>
		/// SpaceExplorer
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpaceExplorer=0xC627;

		/// <summary>
		/// SpaceNavigator for Notebooks
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.Logitech"/>.</remarks>
		public const uint SpaceNavigatorforNotebooks=0xC628;

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
		/// SpaceMouse Wireless 1
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.D3connexion"/>.</remarks>
		public const uint SpaceMouseWireless1=0xc62e;

		/// <summary>
		/// SpaceMouse Wireless 2
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.D3connexion"/>.</remarks>
		public const uint SpaceMouseWireless2=0xc62f;

		/// <summary>
		/// SpaceMouse Wireless 3
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.D3connexion"/>.</remarks>
		public const uint SpaceMouseWireless3=0xc631;

		/// <summary>
		/// SpaceMouse Pro Wireless
		/// </summary>
		/// <remarks>Use with <see cref="VendorID.D3connexion"/>.</remarks>
		public const uint SpaceMouseProWireless=0xc632;
	}
}
