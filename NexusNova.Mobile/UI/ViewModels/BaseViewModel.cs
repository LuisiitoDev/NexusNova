using CommunityToolkit.Mvvm.ComponentModel;

namespace NexusNova.UI.ViewModels;

public abstract partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private string _userName = "Luis";

    [ObservableProperty]
    private bool _isSyncLive = true;

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _busyMessage = string.Empty;
}
