using System;
using AppDemo.ViewModel;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace AppDemo
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
               

            RegisterAppStart<RootViewModel>();
        }
    }
}