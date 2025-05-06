using MigraineTrackerApp.Pages.LoginScreen;
using MigraineTrackerApp.Pages.SignUpScreen;

namespace MigraineTrackerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new SignUpScreenView());
        }
    }
}