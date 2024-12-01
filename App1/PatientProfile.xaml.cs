using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace App1
{
    public sealed partial class PatientProfile : Page
    {
        public PatientProfile()
        {
            this.InitializeComponent();
        }
        private void LogOut(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage));
        }


    }
}