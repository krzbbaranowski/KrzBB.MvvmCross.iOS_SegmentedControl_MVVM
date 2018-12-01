using System;
using System.Collections.Generic;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using KrzBB.SegmentedControlPresenter_MVVMCross.iOS.Attributes;
using UIKit;

namespace KrzBB.SegmentedControlPresenter_MVVMCross.iOS.Views
{
    public abstract class SegmentedTabBarViewControllerBase<TViewModel> : MvxViewController<TViewModel>, ISegmentedControlViewController
        where TViewModel : MvxViewModel
    {
        private const int UnselectedIndex = -1;

        private int _lastSelectedTab = UnselectedIndex;
        private List<string> _texts = new List<string>();

        private List<UIViewController> _viewControllers = new List<UIViewController>();

        private UISegmentedControl _segmentedControl;
        private UIView _contentView;

        public SegmentedTabBarViewControllerBase(string nibName, NSBundle bundle)
            : base(nibName, bundle)
        {
        }

        protected SegmentedTabBarViewControllerBase(IntPtr handle) : base(handle)
        {
        }

        public void ShowSegmentView(UIViewController viewController, SegmentPresentationAttribute attribute)
        {
            if (_viewControllers.Contains(viewController))
                throw new ArgumentException($"You have already added {viewController.GetType()} to this segmented tab bar!");

            _viewControllers.Add(viewController);

            _texts.Add(attribute.Text);

            UpdateTabBar();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _contentView = GetContentView();
            _segmentedControl = GetSegmentedControl();
            _segmentedControl.ValueChanged += ChooseSegmentButtonChanged;

            _segmentedControl.RemoveAllSegments();

            UpdateTabBar();
        }

        private void UpdateTabBar()
        {
            if (_texts.Count == 0)
                return;

            var newIndex = (int)_segmentedControl.NumberOfSegments;

            _segmentedControl.InsertSegment(_texts[newIndex], newIndex, true);

            if (_lastSelectedTab == UnselectedIndex)
            {
                _lastSelectedTab = 0;
                _segmentedControl.SelectedSegment = _lastSelectedTab;
                ChooseSegmentButtonChanged(null, null);
            }
        }

        protected abstract UISegmentedControl GetSegmentedControl();
        protected abstract UIView GetContentView();

        private void ChooseSegmentButtonChanged(object sender, EventArgs e)
        {
            var currentViewController = _viewControllers[(int)_segmentedControl.SelectedSegment];

            currentViewController.View.TranslatesAutoresizingMaskIntoConstraints = false;

            _contentView.AddSubview(currentViewController.View);
            _contentView.AddConstraints(
                currentViewController.View.WithSameLeft(_contentView),
                currentViewController.View.WithSameRight(_contentView),
                currentViewController.View.WithSameTop(_contentView),
                currentViewController.View.WithSameBottom(_contentView)
            );
        }
    }
}
