//
using System;
using System.Windows;
using System.Windows.Controls;
namespace SimpleWPFApp
{
	//
	class MainWindow : Window
	{
		public MainWindow(string title, int height, int width)
		{
			this.Title = title;
			this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			this.Height = height;
			this.Width = width;
			this.Show();
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