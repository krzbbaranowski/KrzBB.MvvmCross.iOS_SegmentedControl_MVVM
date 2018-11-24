using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Presenters;
using MvvmCross.ViewModels;
using KrzBB.SegmentButtonViewModel_MVVMCross.iOS.Attributes;
using KrzBB.SegmentButtonViewModel_MVVMCross.iOS.Views;
using UIKit;

namespace AppDemo.Views
{
    public class TouchViewPresenter : MvxIosViewPresenter//, ITouchViewControllerPresenter
    {
        private ITouchViewHost _viewHost;

        public Dictionary<Type, ISegmentedControlViewController> SegmentedViewControllers { get; protected set; } = new Dictionary<Type, ISegmentedControlViewController>();

        public TouchViewPresenter(IUIApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        public override void RegisterAttributeTypes()
        {
            base.RegisterAttributeTypes();

            AttributeTypesToActionsDictionary.Add(
                typeof(SegmentPresentationAttribute),
               new MvxPresentationAttributeAction
               {
                   ShowAction = async (viewType, attribute, request) =>
                   {
                       var viewController = (UIViewController)this.CreateViewControllerFor(request);
                       ShowSegmentedTabViewController(viewController, (SegmentPresentationAttribute)attribute, request);

                       return await Task.FromResult(true);
                   },
                   CloseAction = (viewModel, attribute) => CloseTabViewController(viewModel, (MvxTabPresentationAttribute)attribute)
               });

            AttributeTypesToActionsDictionary.Add(
                typeof(SegmentedControlPresentationAttribute),
               new MvxPresentationAttributeAction
               {
                   ShowAction = async (viewType, attribute, request) =>
                   {
                       var viewController = (UIViewController)this.CreateViewControllerFor(request);
                       ShowSegmentedControlViewController(viewController, (SegmentedControlPresentationAttribute)attribute, request);

                       return await Task.FromResult(true);
                   },
                   CloseAction = (viewModel, attribute) => CloseTabViewController(viewModel, (MvxTabPresentationAttribute)attribute)
               });
        }

        private void ShowSegmentedControlViewController(UIViewController viewController, SegmentedControlPresentationAttribute attribute, MvxViewModelRequest request)
        {
            AddSegmentedControlViewController(viewController, request);
        }

        protected void ShowSegmentedTabViewController(UIViewController viewController, SegmentPresentationAttribute attribute, MvxViewModelRequest request)
        {
            SegmentedViewControllers[attribute.SegmentedControlViewModelType].ShowSegmentView(viewController, attribute);
        }

        protected override async Task<bool> ShowTabViewController(UIViewController viewController, MvxTabPresentationAttribute attribute, MvxViewModelRequest request)
        {
            AddSegmentedControlViewController(viewController, request);

            return await base.ShowTabViewController(viewController, attribute, request);
        }

        protected override async Task<bool> ShowRootViewController(UIViewController viewController, MvxRootPresentationAttribute attribute, MvxViewModelRequest request)
        {
            AddSegmentedControlViewController(viewController, request);

            return await base.ShowRootViewController(viewController, attribute, request);
        }

        private void AddSegmentedControlViewController(UIViewController viewController, MvxViewModelRequest request)
        {
            if (viewController is ISegmentedControlViewController segmentedControlViewController)
            {
                var parentVMType = request.ViewModelType;

                if (SegmentedViewControllers.ContainsKey(parentVMType))
                {
                    throw new InvalidOperationException($"You have already used {parentVMType} as segmented sontrol parent.");
                }

                SegmentedViewControllers.Add(parentVMType, segmentedControlViewController);
            }
        }
    }
}
