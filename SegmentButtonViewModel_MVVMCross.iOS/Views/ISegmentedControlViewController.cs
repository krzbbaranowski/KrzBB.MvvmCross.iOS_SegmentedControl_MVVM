using KrzBB.SegmentedControlPresenter_MVVMCross.iOS.Attributes;
using UIKit;

namespace KrzBB.SegmentedControlPresenter_MVVMCross.iOS.Views
{
    public interface ISegmentedControlViewController
    {
        void ShowSegmentView(UIViewController viewController, SegmentPresentationAttribute attribute);
    }
}