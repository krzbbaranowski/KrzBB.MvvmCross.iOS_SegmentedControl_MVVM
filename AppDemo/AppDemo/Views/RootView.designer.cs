// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Demo.iOS.Views
{
	[Register ("RootView")]
	partial class RootView
	{
		[Outlet]
		UIKit.UIButton AddSegment { get; set; }

		[Outlet]
		UIKit.UIView ContentView { get; set; }

		[Outlet]
		UIKit.UISegmentedControl SegmentControl { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ContentView != null) {
				ContentView.Dispose ();
				ContentView = null;
			}

			if (SegmentControl != null) {
				SegmentControl.Dispose ();
				SegmentControl = null;
			}

			if (AddSegment != null) {
				AddSegment.Dispose ();
				AddSegment = null;
			}
		}
	}
}
