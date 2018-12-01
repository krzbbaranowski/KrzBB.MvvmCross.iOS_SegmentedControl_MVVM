using System;
using AppDemo.ViewModel;
using MvvmCross.Platforms.Ios.Views;
using KrzBB.SegmentedControlPresenter_MVVMCross.iOS.Attributes;
using UIKit;

namespace AppDemo.Views.Tabs
{
    [SegmentPresentation(Text = "Third", SegmentedControlViewModelType = typeof(RootViewModel))]
    public partial class ThirdTabView : MvxViewController<ThirdViewModel>
    {
        public ThirdTabView() : base("ThirdTabView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

