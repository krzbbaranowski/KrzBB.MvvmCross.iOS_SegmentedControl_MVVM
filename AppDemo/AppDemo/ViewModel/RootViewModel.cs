using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace AppDemo.ViewModel
{
    public class RootViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private bool _thirdShowed;

        public RootViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowInitialViewModelsCommand = new MvxAsyncCommand(ShowInitialViewModels);
            AddSegmentCommand = new MvxAsyncCommand(ShowThirdViewModel);
        }

        public IMvxAsyncCommand ShowInitialViewModelsCommand { get; private set; }
        private async Task ShowInitialViewModels()
        {
            var tasks = new List<Task>();
            tasks.Add(_navigationService.Navigate<FirstViewModel>());
            tasks.Add(_navigationService.Navigate<SecondViewModel>());
            await Task.WhenAll(tasks);
        }

        public IMvxCommand AddSegmentCommand { get; private set; }
        private async Task ShowThirdViewModel()
        {
            if (!_thirdShowed)
            {
                await _navigationService.Navigate<ThirdViewModel>();
                _thirdShowed = true;
            }
        }
    }
}
