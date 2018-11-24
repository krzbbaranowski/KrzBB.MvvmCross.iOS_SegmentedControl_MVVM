// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Demo.iOS.Views.Tabs
{
	[Register ("SecondTabView")]
	partial class SecondTabView
	{
		[Outlet]
		UIKit.UIView ContentView { get; set; }

		[Outlet]
		UIKit.UISegmentedControl SegmentedControl { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (SegmentedControl != null) {
				SegmentedControl.Dispose ();
				SegmentedControl = null;
			}

			if (ContentView != null) {
				ContentView.Dispose ();
				ContentView = null;
			}
		}
	}
}
