using System.Threading.Tasks;
using KrzBB.SegmentButtonViewModel_MVVMCross.iOS;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.ViewModels;
using UIKit;

namespace AppDemo
{
    public class TouchViewPresenter : MvxIosViewPresenter
    {
        SegmentedControlPresenter customePresenter;

        public TouchViewPresenter(IUIApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
            customePresenter = new SegmentedControlPresenter(this);
        }

        public override void RegisterAttributeTypes()
        {
            base.RegisterAttributeTypes();

            customePresenter.RegisterAttributeTypes(AttributeTypesToActionsDictionary);
        }

        protected override async Task<bool> ShowRootViewController(UIViewController viewController, MvxRootPresentationAttribute attribute, MvxViewModelRequest request)
        {
            customePresenter.AddSegmentedControlViewController(viewController, request);

            return await base.ShowRootViewController(viewController, attribute, request);
        }
    }
}
