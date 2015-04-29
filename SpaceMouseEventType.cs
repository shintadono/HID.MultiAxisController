namespace HID.MultiAxisController
{
	/// <summary>
	/// Defines the types of event records of SpaceMouse/SpaceNavigator/SpaceExplorer/... raw input events.
	/// </summary>
	public enum SpaceMouseEventType : byte
	{
		/// <summary>
		/// Translation or combined translation and rotation.
		/// </summary>
		Translation=1,

		/// <summary>
		/// Rotation.
		/// </summary>
		Rotation=2,

		/// <summary>
		/// Buttons.
		/// </summary>
		Buttons=3,
	}
}
