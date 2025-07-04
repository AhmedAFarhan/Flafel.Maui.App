﻿using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Flafel.Maui.WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : MauiWinUIApplication
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);

            var window = (MauiWinUIWindow)Application.Windows[0].Handler.PlatformView;
            var appWindow = window.AppWindow;

            // Set window style to frameless
            appWindow.SetPresenter(AppWindowPresenterKind.FullScreen);

            //var windowPresenter = (OverlappedPresenter)appWindow.Presenter;
            //windowPresenter.SetBorderAndTitleBar(false, false);

            //if (appWindow.Presenter is OverlappedPresenter p)
            //{
            //    p.SetBorderAndTitleBar(false, false);
            //}

            //appWindow.TitleBar.ExtendsContentIntoTitleBar = true;
            //appWindow.TitleBar.PreferredHeightOption = TitleBarHeightOption.Collapsed;
            //appWindow.TitleBar.ButtonBackgroundColor = Windows.UI.Color.FromArgb(1,20,100,100);
            //appWindow.TitleBar.ButtonInactiveBackgroundColor = Windows.UI.Color.FromArgb(1, 20, 100, 100);
        }
    }

}
