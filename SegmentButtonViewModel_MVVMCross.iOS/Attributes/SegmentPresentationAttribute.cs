using System;
using MvvmCross.Presenters.Attributes;

namespace KrzBB.SegmentButtonViewModel_MVVMCross.iOS.Attributes
{
    public class SegmentPresentationAttribute : MvxBasePresentationAttribute
    {
        public string Text { get; set; }

        public Type SegmentedControlViewModelType { get; set; }
    }
}
