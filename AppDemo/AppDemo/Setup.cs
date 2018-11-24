using System;
using AppDemo.Views;
using MvvmCross;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using KrzBB.SegmentButtonViewModel_MVVMCross.iOS.Views;
using UIKit;

namespace AppDemo
{
    public class Setup : MvxIosSetup<App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
        }

        //protected override IMvxIosViewPresenter CreatePresenter()
        //{
        //    var presenter = new TouchViewPresenter((MvxApplicationDelegate)ApplicationDelegate, Window);
        //    Mvx.RegisterSingleton<ITouchViewControllerPresenter>(presenter);
        //    return presenter;
        //}


        protected override IMvxIosViewPresenter CreateViewPresenter()
        {
            var presenter = new TouchViewPresenter((MvxApplicationDelegate)ApplicationDelegate, Window);
            return presenter;
        }
    }
}
