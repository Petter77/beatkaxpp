using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace App1
{
    public sealed partial class StaffProfile : Page
    {
        public StaffProfile()
        {
            this.InitializeComponent();
        }
        private void LogOut(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage));
        }


    }
}