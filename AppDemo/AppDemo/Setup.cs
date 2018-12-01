using System;
using AppDemo.Views;
using MvvmCross;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using KrzBB.SegmentedControlPresenter_MVVMCross.iOS.Views;
using UIKit;
using KrzBB.SegmentedControlPresenter_MVVMCross.iOS;

namespace AppDemo
{
    public class Setup : MvxIosSetup<App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
        }

        protected override IMvxIosViewPresenter CreateViewPresenter()
        {
            var presenter = new CustomViewPresenter((MvxApplicationDelegate)ApplicationDelegate, Window);
            return presenter;
        }
    }
}
