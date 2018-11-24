using System;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.ViewModels;
using UIKit;

namespace KrzBB.SegmentButtonViewModel_MVVMCross.iOS.Views
{
    public interface ITouchViewControllerPresenter
    {
        void Register(ITouchViewHost host);
    }

    public interface ITouchViewHost
    {
        void Show(UIViewController view, MvxTabPresentationAttribute attribute, MvxViewModelRequest request);
    }
}
