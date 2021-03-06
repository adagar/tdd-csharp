﻿using System.Windows;
using Caliburn.Micro;

namespace TrueOrFalse.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {           
            CurrentViewModel = IoC.Get<MainViewModel>();
            
        }

        private object _currentViewModel;

        public object CurrentViewModel
        {
            get { return _currentViewModel; }
            private set
            {
                _currentViewModel = value;
                NotifyOfPropertyChange();
            }
        }

        protected override void OnInitialize()
        {
            ActivateItem(CurrentViewModel);
            DisplayName = "TrueOrFalse";
        }        
    }
}
