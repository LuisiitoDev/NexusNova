using NexusNova.UI.ViewModels;

namespace NexusNova.UI.Pages;

public partial class AssistantPage : ContentPage
{
    public AssistantPage(AssistantViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
