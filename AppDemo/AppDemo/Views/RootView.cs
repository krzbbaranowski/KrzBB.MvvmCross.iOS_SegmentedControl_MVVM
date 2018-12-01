using UIKit;
using AppDemo.ViewModel;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views.Gestures;
using KrzBB.SegmentedControlPresenter_MVVMCross.iOS.Views;
using KrzBB.SegmentedControlPresenter_MVVMCross.iOS.Attributes;
using MvvmCross.Platforms.Ios.Presenters.Attributes;

namespace Demo.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    [SegmentedControlPresentation]
    public partial class RootView : SegmentedTabBarViewControllerBase<RootViewModel>
    {
        private bool _isPresentedFirstTime = true;

        public RootView() : base("RootView", null)
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

            var set = this.CreateBindingSet<RootView, RootViewModel>();
            set.Bind(AddSegment.Tap()).For(tap => tap.Command).To(vm => vm.AddSegmentCommand);
            set.Apply();
        }

        protected override UIView GetContentView()
        {
            return ContentView;
        }

        protected override UISegmentedControl GetSegmentedControl()
        {
            return SegmentControl;
        }
    }
}
