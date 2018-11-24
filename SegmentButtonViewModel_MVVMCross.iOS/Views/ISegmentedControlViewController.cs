using KrzBB.SegmentButtonViewModel_MVVMCross.iOS.Attributes;
using UIKit;

namespace KrzBB.SegmentButtonViewModel_MVVMCross.iOS.Views
{
    public interface ISegmentedControlViewController
    {
        void ShowSegmentView(UIViewController viewController, SegmentPresentationAttribute attribute);
    }
}