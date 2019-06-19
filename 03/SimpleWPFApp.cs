//
using System;
using System.Windows;
using System.Windows.Controls;
namespace SimpleWPFApp
{
	//
	class MainWindow : Window
	{
		// UI object
		private Button btnExitApp = new Button();
		
		public MainWindow(string title, int height, int width)
		{
			// Set button
			btnExitApp.Click += new RoutedEventHandler(btnExitApp_Clicked);
			btnExitApp.Content = "Exit Application";
			btnExitApp.Height = 25;
			btnExitApp.Width = 100;
			
			this.AddChild(btnExitApp);
			
			// Set Window
			this.Title = title;
			this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			this.Height = height;
			this.Width = width;
			this.Show();
		}
		
		private void btnExitApp_Clicked(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
	
	class MyWPFApp : Application
	{
		[STAThread]
		static void Main()
		{
			MyWPFApp app = new MyWPFApp();
			app.Startup += AppStartup;
			app.Exit += AppExit;
			app.Run();
		}
		
		static void AppExit(object sender, ExitEventArgs e)
		{
			MessageBox.Show("App hax exited");
		}
		
		static void AppStartup(object sender, StartupEventArgs e)
		{
			MainWindow mainWindow = new MainWindow("My First WPF App!", 200, 300);
		}
	}
}