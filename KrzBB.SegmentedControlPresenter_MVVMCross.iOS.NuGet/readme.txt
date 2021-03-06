﻿MVVMCross.iOS Segmented Control Presenter


Library to create navigation between a few views using UISegmentedControl, view models and full MvvmCross support.


Installation

1. Add 'root view' where you place UISegmentedControl and UIView. UIView will be like a container for yours views. Add inheritance from SegmentedTabBarViewControllerBase and implement abstact methods. Add SegmentedControlPresentation attribute.

[MvxRootPresentation(WrapInNavigationController = true)] //or another
[SegmentedControlPresentation]
public partial class YourRootView : SegmentedTabBarViewControllerBase<YOUR_VIEW_MODEL>
{
    //others methods
    //...
    protected override UIView GetContentView()
    {
        return ContentView;
    }
    protected override UISegmentedControl GetSegmentedControl()
    {
        return SegmentControl;
    }
}

2. Add custom view presenter with correct implementations.In this example YourRootView uses MvxRootPresentation so AddSegmentedControlViewController method called in ShowRootViewController method.

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
    
    //In this example YourRootView uses MvxRootPresentation so AddSegmentedControlViewController method called in ShowRootViewController method.
    protected override async Task<bool> ShowRootViewController(UIViewController viewController, MvxRootPresentationAttribute attribute, MvxViewModelRequest request)
    {
        _customPresenter.AddSegmentedControlViewController(viewController, request);
        return await base.ShowRootViewController(viewController, attribute, request);
    }
}

3.Add at least two views and add SegmentPresentation attribute. Use correct SegmentedControlViewModelType type name.

[SegmentPresentation(Text = "First", SegmentedControlViewModelType = typeof(RootViewModel))]
public partial class FirstTabView : MvxViewController<firstviewmodel>
{
    public FirstTabView() : base("FirstTabView", null)
    {
    }
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
    }
}

4. Add navigation to these views.

_navigationService.Navigate<FirstViewModel>();
_navigationService.Navigate<SecondViewModel>();