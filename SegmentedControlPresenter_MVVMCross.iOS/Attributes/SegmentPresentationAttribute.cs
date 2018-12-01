using System;
using System.Collections.Generic;
using MvvmCross.Presenters.Attributes;

namespace KrzBB.SegmentedControlPresenter_MVVMCross.iOS.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class SegmentPresentationAttribute : MvxBasePresentationAttribute
    {
        public string Text { get; set; }

        public Type SegmentedControlViewModelType { get; set; }
    }
}
