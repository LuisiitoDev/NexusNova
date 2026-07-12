using NexusNova.UI.ViewModels;

namespace NexusNova.UI.Pages;

public partial class AgendaPage : ContentPage
{
    public AgendaPage(AgendaViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
