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
		
		// string that updated when events occur.
		private string lifeTimeData = String.Empty;
		
		protected void MainWindow_Activated(object sender, EventArgs e)
		{
			lifeTimeData += "Activated Event Fired\n";
		}
		
		protected void MainWindow_Deactivated(object sender, EventArgs e)
		{
			lifeTimeData += "Deactivated Event Fired\n";
		}
		
		protected void MainWindow_Loaded(object sender, EventArgs e)
		{
			lifeTimeData += "Loaded Event Fired\n";
		}
		
		protected void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			lifeTimeData += "Closing Event Fired\n";
			
			string msg = "Do you want to close without saving?";
			MessageBoxResult result = MessageBox.Show(msg, "My App", MessageBoxButton.YesNo, MessageBoxImage.Warning);
			if (result == MessageBoxResult.No)
			{
				e.Cancel = true;
			}
		}
		
		protected void MainWindow_Closed(object sender, EventArgs e)
		{
			lifeTimeData += "Closing Event Fired\n";
			MessageBox.Show(lifeTimeData);
		}

		public MainWindow(string title, int height, int width)
		{
			// Set event
			this.Activated += MainWindow_Activated;
			this.Deactivated += MainWindow_Deactivated;
			this.Closing += MainWindow_Closing;
			this.Closed += MainWindow_Closed;
			
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
			if ((bool)Application.Current.Properties["GodMode"])
			{
				MessageBox.Show("Cheater!");
			}
			
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
			MessageBox.Show("App has exited");
		}
		
		static void AppStartup(object sender, StartupEventArgs e)
		{
			// Check parameter is input, if exist then set true
			Application.Current.Properties["GodMode"] = false;
			
			foreach (string arg in e.Args)
			{
				if (arg.ToLower() == "/godmode")
				{
					Application.Current.Properties["GodMode"] = true;
					break;
				}
			}
			
			MainWindow mainWindow = new MainWindow("My First WPF App!", 200, 300);
		}
		
		static void MinimizeAllWindows()
		{
			foreach (Window wnd in Application.Current.Windows)
			{
				wnd.WindowState = WindowState.Minimized;
			}
		}
	}
}