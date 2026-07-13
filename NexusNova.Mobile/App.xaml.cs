using NexusNova.UI.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace NexusNova
{
    public partial class App : Application
    {
        private readonly IServiceProvider _services;
        public App(IServiceProvider services)
        {
            InitializeComponent();
            UserAppTheme = AppTheme.Dark;
            _services = services;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(_services.GetRequiredService<LoginPage>());
        }
    }
}