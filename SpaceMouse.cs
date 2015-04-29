using System;
using System.Runtime.InteropServices;
using Win32;
using Win32.HumanInterfaceDevices;
using Win32.RawInput;

namespace HID.MultiAxisController
{
	/// <summary>
	/// [TODO]Class for handling <see cref="WM.INPUT">WM_INPUT</see> messages for SpaceMouse/SpaceNavigator/SpaceExplorer/... devices.
	/// </summary>
	public class SpaceMouse
	{
		/// <summary>
		/// Returns wether a device is a compatible devices, or not.
		/// </summary>
		/// <param name="info">The <see cref="RID_DEVICE_INFO"/> describing the device.</param>
		/// <returns><b>true</b> if the device is compatible with the class; otherwise, <b>false</b>.</returns>
		public static bool IsSpaceMouse(RID_DEVICE_INFO info)
		{
			return info.dwType==RIM_TYPE.HID&&info.hid.usUsage==HID_USAGE_GENERIC_DESKTOP.MULTIAXIS_CONTROLLER&&
				info.hid.usUsagePage==HID_USAGE_PAGE.GENERIC_DESKTOP&&
				(info.hid.dwVendorId==VendorID.Logitech||info.hid.dwVendorId==VendorID.D3connexion);
		}

		/// <summary>
		/// Processes a <see cref="WM.INPUT">WM_INPUT</see> messages and raises the proper events.
		/// </summary>
		/// <param name="lParam">The handle to the raw input dataset.</param>
		/// <param name="size">The size, in bytes, of the raw input dataset.</param>
		public void ProcessInput(IntPtr lParam, uint size)
		{
			IntPtr buffer=Marshal.AllocHGlobal((int)size);
			uint dwSize=size;

			try
			{
				uint err=RawInput.GetRawInputData(lParam, RID.INPUT, buffer, ref dwSize, RAWINPUTHEADER.SIZE);
				if(err==uint.MaxValue) throw new Exception(string.Format("Error getting WM_INPUT data. (Error code: 0x{0:X8})", WinKernel.GetLastError()));

				SpaceMouseEventHeader eventHeader=(SpaceMouseEventHeader)Marshal.PtrToStructure(buffer+(int)RAWINPUTHEADER.SIZE, typeof(SpaceMouseEventHeader));

				int eventHeaderSize=SpaceMouseEventHeader.SIZE+(int)RAWINPUTHEADER.SIZE;

				switch(eventHeader.eventType)
				{
					case SpaceMouseEventType.Translation:
						{
							if(eventHeader.dwSizeHid==7)
							{
								for(int i=0; i<eventHeader.dwCount; i++)
								{
									SpaceMouseTranslationEventData translation=(SpaceMouseTranslationEventData)Marshal.PtrToStructure(buffer+eventHeaderSize+i*(int)eventHeader.dwSizeHid, typeof(SpaceMouseTranslationEventData));
									Console.WriteLine("T: {0,5}, {1,5}, {2,5}", translation.X, translation.Y, translation.Z);
								}
							}
							else if(eventHeader.dwSizeHid==13) // "High Speed" firmware version includes both T and R vector in the same report
							{
								for(int i=0; i<eventHeader.dwCount; i++)
								{
									SpaceMouseTranslationRotationEventData transRot=(SpaceMouseTranslationRotationEventData)Marshal.PtrToStructure(buffer+eventHeaderSize+i*(int)eventHeader.dwSizeHid, typeof(SpaceMouseTranslationRotationEventData));
									Console.WriteLine("T/R: {0,5}, {1,5}, {2,5}, {3,5}, {4,5}, {5,5}", transRot.X, transRot.Y, transRot.Z, transRot.RX, transRot.RY, transRot.RZ);
								}
							}

							break;
						}
					case SpaceMouseEventType.Rotation:
						{
							for(int i=0; i<eventHeader.dwCount; i++)
							{
								SpaceMouseRotationEventData rotation=(SpaceMouseRotationEventData)Marshal.PtrToStructure(buffer+eventHeaderSize+i*(int)eventHeader.dwSizeHid, typeof(SpaceMouseRotationEventData));
								Console.WriteLine("R: {0,5}, {1,5}, {2,5}", rotation.RX, rotation.RY, rotation.RZ);
							}

							break;
						}
					case SpaceMouseEventType.Buttons:
						{
							for(int i=0; i<eventHeader.dwCount; i++)
							{
								SpaceMouseButtonsEventData b=(SpaceMouseButtonsEventData)Marshal.PtrToStructure(buffer+eventHeaderSize+i*(int)eventHeader.dwSizeHid, typeof(SpaceMouseButtonsEventData));
								Console.WriteLine("B:"+b.ButtonState);
							}
							break;
						}
				}
			}
			finally
			{
				Marshal.FreeHGlobal(buffer);
			}
		}

	}
}
