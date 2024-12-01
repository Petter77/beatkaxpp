using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace App1
{
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
        private void NavigateTrustedProfile(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TrustedProfile));
        }
        private void NavigateStaffLogin(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(StaffLogin));
        }
    }
}