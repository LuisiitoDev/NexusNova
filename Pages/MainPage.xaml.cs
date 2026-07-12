using NexusNova.Models;
using NexusNova.PageModels;

namespace NexusNova.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}