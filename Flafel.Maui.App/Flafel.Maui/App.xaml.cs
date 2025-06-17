namespace Flafel.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

		protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            // Get display dimensions
            var displayInfo = DeviceDisplay.Current.MainDisplayInfo;

            window.Width = 1150;
            window.MinimumWidth = 800;

            window.Height = 700;
            window.MinimumHeight = 500;

            // Center window
            window.X = (displayInfo.Width / displayInfo.Density - window.Width) / 2;
            window.Y = (displayInfo.Height / displayInfo.Density - window.Height) / 2;

            return window;
        }
    }
}
