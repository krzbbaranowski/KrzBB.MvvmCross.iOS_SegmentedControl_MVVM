using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Presenters;
using MvvmCross.ViewModels;
using KrzBB.SegmentedControlPresenter_MVVMCross.iOS.Attributes;
using KrzBB.SegmentedControlPresenter_MVVMCross.iOS.Views;
using UIKit;

namespace KrzBB.SegmentedControlPresenter_MVVMCross.iOS
{
    public class SegmentedControlPresenter
    {
        private MvxIosViewPresenter _appPresenter;
        private Dictionary<Type, ISegmentedControlViewController> SegmentedControlsControllers { get; set; } = new Dictionary<Type, ISegmentedControlViewController>();

        public SegmentedControlPresenter(MvxIosViewPresenter touchViewPresenter)
        {
            _appPresenter = touchViewPresenter;
        }

        public void ShowSegmentedTabViewController(UIViewController viewController, SegmentPresentationAttribute attribute, MvxViewModelRequest request)
        {
            SegmentedControlsControllers[attribute.SegmentedControlViewModelType].ShowSegmentView(viewController, attribute);
        }

        public void RegisterAttributeTypes(IDictionary<Type, MvxPresentationAttributeAction> attributeTypesToActionsDictionary)
        {
            attributeTypesToActionsDictionary.Add(
                typeof(SegmentPresentationAttribute),
               new MvxPresentationAttributeAction
               {
                   ShowAction = async (viewType, attribute, request) =>
                   {
                       var viewController = (UIViewController)_appPresenter.CreateViewControllerFor(request);
                       ShowSegmentedTabViewController(viewController, (SegmentPresentationAttribute)attribute, request);

                       AddSegmentedControlViewController(viewController, request);

                       return await Task.FromResult(true);
                   },

                   CloseAction = (viewModel, attribute) =>
                   {
                       return Task.FromResult(true);
                   }
               });

            attributeTypesToActionsDictionary.Add(
                typeof(SegmentedControlPresentationAttribute),
               new MvxPresentationAttributeAction
               {
                   ShowAction = async (viewType, attribute, request) =>
                   {
                       var viewController = (UIViewController)_appPresenter.CreateViewControllerFor(request);
                       ShowSegmentedControlViewController(viewController, (SegmentedControlPresentationAttribute)attribute, request);

                       return await Task.FromResult(true);
                   },
                   CloseAction = (viewModel, attribute) =>
                   {
                       return Task.FromResult(true);
                   }
               });
        }

        private void ShowSegmentedControlViewController(UIViewController viewController, SegmentedControlPresentationAttribute attribute, MvxViewModelRequest request)
        {
            AddSegmentedControlViewController(viewController, request);
        }

        public void AddSegmentedControlViewController(UIViewController viewController, MvxViewModelRequest request)
        {
            if (viewController is ISegmentedControlViewController segmentedControlViewController)
            {
                var parentVMType = request.ViewModelType;

                if (SegmentedControlsControllers.ContainsKey(parentVMType))
                {
                    throw new InvalidOperationException($"You have already used {parentVMType} as segmented sontrol parent.");
                }

                SegmentedControlsControllers.Add(parentVMType, segmentedControlViewController);
            }
        }
    }
}