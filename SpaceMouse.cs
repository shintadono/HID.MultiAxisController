using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Win32;
using Win32.HumanInterfaceDevices;
using Win32.RawInput;

namespace HID.MultiAxisController
{
	/// <summary>
	/// Class for handling <see cref="WM.INPUT">WM_INPUT</see> messages for SpaceMouse/SpaceNavigator/SpaceExplorer/... devices.
	/// </summary>
	public class SpaceMouse
	{
		/// <summary>
		/// Returns whether a device is a compatible devices, or not.
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
		/// Set the state of the LED of a SpaceMouse/SpaceNavigator/SpaceExplorer/... devices.
		/// </summary>
		/// <param name="hDevice">The handle of the device.</param>
		/// <param name="enable">Defines the new state of the LED.</param>
		public static void SetLED(IntPtr hDevice, bool enable=true)
		{
			string name=RawInput.GetRawInputDeviceName(hDevice);

			IntPtr hFile=FileOperations.CreateFile(name, GENERIC.READ|GENERIC.WRITE, FILE_SHARE.READ|FILE_SHARE.WRITE, IntPtr.Zero,
				Win32.FileMode.OPEN_EXISTING, FILE_ATTRIBUTE.NORMAL, IntPtr.Zero);

			if(hFile!=FileOperations.INVALID_HANDLE_VALUE)
			{
				uint written;
				FileOperations.WriteFile(hFile, new byte[] { 4, (byte)(enable?1:0) }, 2, out written, IntPtr.Zero);
				FileOperations.CloseHandle(hFile);
			}

			WinKernel.SetLastError(0);
		}

		/// <summary>
		/// Enables the LED of a SpaceMouse/SpaceNavigator/SpaceExplorer/... devices.
		/// </summary>
		/// <param name="hDevice">The handle of the device.</param>
		public static void EnableLED(IntPtr hDevice) { SetLED(hDevice, true); }

		/// <summary>
		/// Disables the LED of a SpaceMouse/SpaceNavigator/SpaceExplorer/... devices.
		/// </summary>
		/// <param name="hDevice">The handle of the device.</param>
		public static void DisableLED(IntPtr hDevice) { SetLED(hDevice, false); }

		/// <summary>
		/// Translation event.
		/// </summary>
		public event EventHandler<SpaceMouseTranslationEventArgs> Translation;

		/// <summary>
		/// Rotation event.
		/// </summary>
		public event EventHandler<SpaceMouseRotationEventArgs> Rotation;

		/// <summary>
		/// Buttons event.
		/// </summary>
		public event EventHandler<SpaceMouseButtonsEventArgs> Buttons;

		Dictionary<IntPtr, uint> DeviceToProduct=new Dictionary<IntPtr, uint>();

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

				RAWINPUTHEADER inputHeader=(RAWINPUTHEADER)Marshal.PtrToStructure(buffer, typeof(RAWINPUTHEADER));
				SpaceMouseEventHeader eventHeader=(SpaceMouseEventHeader)Marshal.PtrToStructure(buffer+(int)RAWINPUTHEADER.SIZE, typeof(SpaceMouseEventHeader));

				int eventHeaderSize=SpaceMouseEventHeader.SIZE+(int)RAWINPUTHEADER.SIZE;

				switch(eventHeader.eventType)
				{
					case SpaceMouseEventType.Translation:
						if(eventHeader.dwSizeHid==7) // check report size for safety
						{
							EventHandler<SpaceMouseTranslationEventArgs> tEvt=Translation;
							if(tEvt!=null) // no need to handle if nobody is listing
							{
								for(int i=0; i<eventHeader.dwCount; i++)
								{
									SpaceMouseTranslationEventData translation=(SpaceMouseTranslationEventData)Marshal.PtrToStructure(buffer+eventHeaderSize+i*(int)eventHeader.dwSizeHid, typeof(SpaceMouseTranslationEventData));
									tEvt(this, new SpaceMouseTranslationEventArgs(inputHeader.hDevice, translation.X, translation.Y, translation.Z));
								}
							}
						}
						else if(eventHeader.dwSizeHid==13) // "High Speed" firmware version includes both T and R vector in the same report
						{
							EventHandler<SpaceMouseTranslationEventArgs> tEvt=Translation;
							EventHandler<SpaceMouseRotationEventArgs> rEvt=Rotation;
							if(tEvt!=null||rEvt!=null) // no need to handle if nobody is listing
							{
								for(int i=0; i<eventHeader.dwCount; i++)
								{
									SpaceMouseTranslationRotationEventData transRot=(SpaceMouseTranslationRotationEventData)Marshal.PtrToStructure(buffer+eventHeaderSize+i*(int)eventHeader.dwSizeHid, typeof(SpaceMouseTranslationRotationEventData));
									if(tEvt!=null) tEvt(this, new SpaceMouseTranslationEventArgs(inputHeader.hDevice, transRot.X, transRot.Y, transRot.Z));
									if(rEvt!=null) rEvt(this, new SpaceMouseRotationEventArgs(inputHeader.hDevice, transRot.RX, transRot.RY, transRot.RZ));
								}
							}
						}
						break;
					case SpaceMouseEventType.Rotation:
						if(eventHeader.dwSizeHid==7) // check report size for safety
						{
							EventHandler<SpaceMouseRotationEventArgs> rEvt=Rotation;
							if(rEvt!=null) // no need to handle if nobody is listing
							{
								for(int i=0; i<eventHeader.dwCount; i++)
								{
									SpaceMouseRotationEventData rotation=(SpaceMouseRotationEventData)Marshal.PtrToStructure(buffer+eventHeaderSize+i*(int)eventHeader.dwSizeHid, typeof(SpaceMouseRotationEventData));
									rEvt(this, new SpaceMouseRotationEventArgs(inputHeader.hDevice, rotation.RX, rotation.RY, rotation.RZ));
								}
							}
						}
						break;
					case SpaceMouseEventType.Buttons:
						if(eventHeader.dwSizeHid>=5) // check report size for safety
						{
							EventHandler<SpaceMouseButtonsEventArgs> bEvt=Buttons;
							if(bEvt!=null) // no need to handle if nobody is listing
							{
								if(!DeviceToProduct.ContainsKey(inputHeader.hDevice))
								{
									var di=RawInput.GetRawInputDeviceInfo(inputHeader.hDevice);
									DeviceToProduct.Add(inputHeader.hDevice, di.hid.dwProductId);
								}

								uint product=DeviceToProduct[inputHeader.hDevice];

								for(int i=0; i<eventHeader.dwCount; i++)
								{
									SpaceMouseButtonsEventData tmpButtons=(SpaceMouseButtonsEventData)Marshal.PtrToStructure(buffer+eventHeaderSize+i*(int)eventHeader.dwSizeHid, typeof(SpaceMouseButtonsEventData));

									SpaceMouseButtons buttons=SpaceMouseButtons.NONE;
									switch(product)
									{
										case ProductID.SpacePilot: buttons=FromSpacePilot(tmpButtons.ButtonState); break;
										case ProductID.SpaceExplorer: buttons=FromSpaceExplorer(tmpButtons.ButtonState); break;
										case ProductID.SpaceNavigator:
										case ProductID.SpaceNavigatorforNotebooks:
										case ProductID.SpaceMouse:
										case ProductID.SpaceMouseWireless: buttons=FromSpaceMouse(tmpButtons.ButtonState); break;
										case ProductID.SpacePilotPro: buttons=FromSpacePilotPro(tmpButtons.ButtonState); break;
										case ProductID.SpaceMousePro:
										case ProductID.SpaceMouseProWireless: buttons=FromSpaceMousePro(tmpButtons.ButtonState); break;
										case ProductID.SpaceMouseTouch: buttons=FromSpaceMouseTouch(tmpButtons.ButtonState); break;
									}

									bEvt(this, new SpaceMouseButtonsEventArgs(inputHeader.hDevice, buttons));
								}
							}
						}
						break;
				}
			}
			finally
			{
				Marshal.FreeHGlobal(buffer);
			}
		}

		/// <summary>
		/// Converts the button event data for SpaceExplorer.
		/// </summary>
		/// <param name="buttons">The buttons event data.</param>
		/// <returns>A <see cref="SpaceMouseButtons"/> specifying the state of the device buttons.</returns>
		SpaceMouseButtons FromSpaceExplorer(uint buttons)
		{
			SpaceMouseButtons ret=SpaceMouseButtons.NONE;
			if((buttons&0x00000001)!=0) ret|=SpaceMouseButtons.BUTTON1;
			if((buttons&0x00000002)!=0) ret|=SpaceMouseButtons.BUTTON2;
			if((buttons&0x00000004)!=0) ret|=SpaceMouseButtons.TOP;
			if((buttons&0x00000008)!=0) ret|=SpaceMouseButtons.LEFT;
			if((buttons&0x00000010)!=0) ret|=SpaceMouseButtons.RIGHT;
			if((buttons&0x00000020)!=0) ret|=SpaceMouseButtons.FRONT;
			if((buttons&0x00000040)!=0) ret|=SpaceMouseButtons.ESCAPE;
			if((buttons&0x00000080)!=0) ret|=SpaceMouseButtons.ALT;
			if((buttons&0x00000100)!=0) ret|=SpaceMouseButtons.SHIFT;
			if((buttons&0x00000200)!=0) ret|=SpaceMouseButtons.CTRL;
			if((buttons&0x00000400)!=0) ret|=SpaceMouseButtons.FIT;
			if((buttons&0x00000800)!=0) ret|=SpaceMouseButtons.PANEL;
			if((buttons&0x00001000)!=0) ret|=SpaceMouseButtons.PLUS;
			if((buttons&0x00002000)!=0) ret|=SpaceMouseButtons.MINUS;
			if((buttons&0x00004000)!=0) ret|=SpaceMouseButtons.ROTATE;
			return ret;
		}

		/// <summary>
		/// Converts the button event data for SpacePilot.
		/// </summary>
		/// <param name="buttons">The buttons event data.</param>
		/// <returns>A <see cref="SpaceMouseButtons"/> specifying the state of the device buttons.</returns>
		SpaceMouseButtons FromSpacePilot(uint buttons)
		{
			SpaceMouseButtons ret=SpaceMouseButtons.NONE;
			if((buttons&0x00000001)!=0) ret|=SpaceMouseButtons.BUTTON1;
			if((buttons&0x00000002)!=0) ret|=SpaceMouseButtons.BUTTON2;
			if((buttons&0x00000004)!=0) ret|=SpaceMouseButtons.BUTTON3;
			if((buttons&0x00000008)!=0) ret|=SpaceMouseButtons.BUTTON4;
			if((buttons&0x00000010)!=0) ret|=SpaceMouseButtons.BUTTON5;
			if((buttons&0x00000020)!=0) ret|=SpaceMouseButtons.BUTTON6;
			if((buttons&0x00000040)!=0) ret|=SpaceMouseButtons.TOP;
			if((buttons&0x00000080)!=0) ret|=SpaceMouseButtons.LEFT;
			if((buttons&0x00000100)!=0) ret|=SpaceMouseButtons.RIGHT;
			if((buttons&0x00000200)!=0) ret|=SpaceMouseButtons.FRONT;
			if((buttons&0x00000400)!=0) ret|=SpaceMouseButtons.ESCAPE;
			if((buttons&0x00000800)!=0) ret|=SpaceMouseButtons.ALT;
			if((buttons&0x00001000)!=0) ret|=SpaceMouseButtons.SHIFT;
			if((buttons&0x00002000)!=0) ret|=SpaceMouseButtons.CTRL;
			if((buttons&0x00004000)!=0) ret|=SpaceMouseButtons.FIT;
			if((buttons&0x00008000)!=0) ret|=SpaceMouseButtons.PANEL;
			if((buttons&0x00010000)!=0) ret|=SpaceMouseButtons.PLUS;
			if((buttons&0x00020000)!=0) ret|=SpaceMouseButtons.MINUS;
			if((buttons&0x00040000)!=0) ret|=SpaceMouseButtons.DOMINANT;
			if((buttons&0x00080000)!=0) ret|=SpaceMouseButtons.ROTATE;
			// ignore USER keys
			return ret;
		}

		/// <summary>
		/// Converts the button event data for SpaceMouse (Wireless), SpaceNavigator and SpaceNavigator for Notebooks.
		/// </summary>
		/// <param name="buttons">The buttons event data.</param>
		/// <returns>A <see cref="SpaceMouseButtons"/> specifying the state of the device buttons.</returns>
		SpaceMouseButtons FromSpaceMouse(uint buttons)
		{
			return (SpaceMouseButtons)(buttons&0x00000003);
		}

		/// <summary>
		/// Converts the button event data for SpacePilot Pro.
		/// </summary>
		/// <param name="buttons">The buttons event data.</param>
		/// <returns>A <see cref="SpaceMouseButtons"/> specifying the state of the device buttons.</returns>
		SpaceMouseButtons FromSpacePilotPro(uint buttons)
		{
			return (SpaceMouseButtons)(buttons&0x7FFFFFFF);
		}

		/// <summary>
		/// Converts the button event data for SpaceMouse Pro (Wireless).
		/// </summary>
		/// <param name="buttons">The buttons event data.</param>
		/// <returns>A <see cref="SpaceMouseButtons"/> specifying the state of the device buttons.</returns>
		SpaceMouseButtons FromSpaceMousePro(uint buttons)
		{
			return (SpaceMouseButtons)(buttons&0x07C0F137);
		}

		/// <summary>
		/// Converts the button event data for SpaceMouse Touch.
		/// </summary>
		/// <param name="buttons">The buttons event data.</param>
		/// <returns>A <see cref="SpaceMouseButtons"/> specifying the state of the device buttons.</returns>
		SpaceMouseButtons FromSpaceMouseTouch(uint buttons)
		{
			return (SpaceMouseButtons)(buttons&0x003FFFFF);
		}
	}
}
