using System;
using AppDemo.ViewModel;
using KrzBB.SegmentedControlPresenter_MVVMCross.iOS.Attributes;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace AppDemo.Views.Tabs
{
    [SegmentPresentation(Text = "Second nested", SegmentedControlViewModelType = typeof(SecondViewModel))]
    public partial class SecondNestedView : MvxViewController<SecondNestedViewModel>
    {
        public SecondNestedView() : base("SecondNestedView", null)
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

