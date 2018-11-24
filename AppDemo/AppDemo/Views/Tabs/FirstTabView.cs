﻿using System;
using AppDemo.ViewModel;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using KrzBB.SegmentButtonViewModel_MVVMCross.iOS.Attributes;
using UIKit;

namespace Demo.iOS.Views.Tabs
{
    [SegmentPresentation( Text = "First", SegmentedControlViewModelType = typeof(RootViewModel))]
    public partial class FirstTabView : MvxViewController<FirstViewModel>
    {
        public FirstTabView() : base("FirstTabView", null)
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
