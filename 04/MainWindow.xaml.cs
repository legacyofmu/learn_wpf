//
using System;
using System.Windows;
using System.Windows.Controls;

namespace SimpleXamlApp
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		
		private void btnExitApp_Clicked(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
