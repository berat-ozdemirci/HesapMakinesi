using Microsoft.Extensions.DependencyInjection;

namespace HesapMakinesiÖdev
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            string tema = Preferences.Get("Tema", "Sistem");

            if (tema == "Acik")
            {
                UserAppTheme = AppTheme.Light;
            }
            else if (tema == "Koyu")
            {
                UserAppTheme = AppTheme.Dark;
            }
            else
            {
                UserAppTheme = AppTheme.Unspecified;
            }

            return new Window(new AppShell());
        }
    }
}