using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser; 

namespace SilverlightApplication2
{
	public partial class MainPage : UserControl
	{
		public MainPage()
		{
			// Required to initialize variables
			InitializeComponent();
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           //String var = (string)HtmlPage.Window.Invoke("getId");
           //value.Text = var;
           tutor.Text = ("Ejecuto");

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Grid1.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Grid1.Visibility = Visibility.Visible;
        }
	}
}