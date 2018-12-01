using System.Threading.Tasks;
using KrzBB.SegmentButtonViewModel_MVVMCross.iOS;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.ViewModels;
using UIKit;

namespace AppDemo
{
    public class CustomViewPresenter : MvxIosViewPresenter
    {
        private SegmentedControlPresenter _customPresenter;

        public CustomViewPresenter(IUIApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
            _customPresenter = new SegmentedControlPresenter(this);
        }

        public override void RegisterAttributeTypes()
        {
            base.RegisterAttributeTypes();

            _customPresenter.RegisterAttributeTypes(AttributeTypesToActionsDictionary);
        }

        protected override async Task<bool> ShowRootViewController(UIViewController viewController, MvxRootPresentationAttribute attribute, MvxViewModelRequest request)
        {
            _customPresenter.AddSegmentedControlViewController(viewController, request);

            return await base.ShowRootViewController(viewController, attribute, request);
        }
    }
}

