﻿using SciterSharp;
using SciterSharp.Interop;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciterBootstrap
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Sciter needs this for drag'n'drop support; STAThread is required for OleInitialize succeess
			int oleres = PInvokeWindows.OleInitialize(IntPtr.Zero);
			Debug.Assert(oleres == 0);
			
			// Create the window
			var wnd = new Window();
			wnd.CreateMainWindow(1500, 800);
			wnd.CenterTopLevelWindow();
			wnd.SetupAeroArea();
			wnd.Title = "SciterBootstrap";
			wnd.Icon = Properties.Resources.IconMain;

			// Prepares SciterHost and then load the page
			var host = new Host();
			host.Setup(wnd);
			host.AttachEvh(new HostEvh());
			host.SetupPage("index.html");

			// Show window and Run message loop
			wnd.Show();
			PInvokeUtils.RunMsgLoop();
		}
	}
}