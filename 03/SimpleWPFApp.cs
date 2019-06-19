//
using System;
using System.Windows;
using System.Windows.Controls;
namespace SimpleWPFApp
{
	//
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
			Window mainWindow = new Window();
			mainWindow.Title = "My First WPF App!";
			mainWindow.Height = 200;
			mainWindow.Width = 300;
			mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			mainWindow.Show();
		}
	}
}