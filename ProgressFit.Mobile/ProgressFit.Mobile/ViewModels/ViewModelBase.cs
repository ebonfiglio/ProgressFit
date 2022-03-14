using JetBrains.Annotations;
using ProgressFit.Mobile.Services.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgressFit.Mobile.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
            //protected readonly IConnectionService _connectionService;
            protected readonly INavigationService _navigationService;
            //protected readonly IDialogService _dialogService;

            public ViewModelBase( INavigationService navigationService)
            {
               // _connectionService = connectionService;
                _navigationService = navigationService;
                //_dialogService = dialogService;
            }

            private bool _isBusy;

            public event PropertyChangedEventHandler PropertyChanged;

            public bool IsBusy
            {
                get => _isBusy;
                set
                {
                    _isBusy = value;
                    OnPropertyChanged(nameof(IsBusy));
                }
            }

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public virtual Task InitializeAsync(object data)
            {
                return Task.FromResult(false);
            }
        }
}
