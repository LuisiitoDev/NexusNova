using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NexusNova.UI.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isCredentialConnected = false;

    [ObservableProperty]
    private bool _isBusy = false;

    [RelayCommand]
    private async Task SignInWithGoogleAsync()
    {
        IsBusy = true;
        try
        {
            await Task.Delay(1500);
            IsCredentialConnected = true;
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task SimulateSignInAsync()
    {
        IsBusy = true;
        try
        {
            await Task.Delay(800);
            IsCredentialConnected = true;
        }
        finally
        {
            IsBusy = false;
        }
    }
}
