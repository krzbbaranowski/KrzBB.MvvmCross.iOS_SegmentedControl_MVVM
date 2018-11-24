using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace AppDemo.ViewModel
{
    public class SecondViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public SecondViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowInitialViewModelsCommand = new MvxAsyncCommand(ShowInitialViewModels);
        }

        public IMvxAsyncCommand ShowInitialViewModelsCommand { get; private set; }
        private async Task ShowInitialViewModels()
        {
            var tasks = new List<Task>();
            tasks.Add(_navigationService.Navigate<FirstNestedViewModel>());
            tasks.Add(_navigationService.Navigate<SecondNestedViewModel>());
            await Task.WhenAll(tasks);
        }
    }
}
