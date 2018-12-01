using System;
using AppDemo.ViewModel;
using MvvmCross.Platforms.Ios.Views;
using KrzBB.SegmentedControlPresenter_MVVMCross.iOS.Attributes;
using UIKit;
using KrzBB.SegmentedControlPresenter_MVVMCross.iOS.Views;

namespace Demo.iOS.Views.Tabs
{
    [SegmentPresentation(Text = "Second", SegmentedControlViewModelType = typeof(RootViewModel))]
    [SegmentedControlPresentation]
    public partial class SecondTabView : SegmentedTabBarViewControllerBase<SecondViewModel>
    {
        private bool _isPresentedFirstTime = true;

        public SecondTabView() : base("SecondTabView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (ViewModel != null && _isPresentedFirstTime)
            {
                _isPresentedFirstTime = false;
                ViewModel.ShowInitialViewModelsCommand.ExecuteAsync(null);
            }
        }

        protected override UISegmentedControl GetSegmentedControl()
        {
            return SegmentedControl;
        }

        protected override UIView GetContentView()
        {
            return ContentView;
        }
    }
}

