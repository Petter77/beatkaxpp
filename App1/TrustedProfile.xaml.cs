using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Popups;


namespace App1
{
    public sealed partial class TrustedProfile : Page
    {
        public TrustedProfile()
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
        private void TrustedProfileCheck(object sender, RoutedEventArgs e)
        {
            if(txtBox.Text == "01234567891")
            {
                Frame.Navigate(typeof(PatientProfile));
            }
        }
        private void NumberValidationTextBox(object sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }
        private void MinCheck(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text.Length < 11)
            {
                Warning.Visibility = Visibility.Visible;
                Warning.Text = "Pesel musi składać się z 11 cyfr";
            }
            else
            {
                Warning.Visibility = Visibility.Collapsed;  
                Warning.Text = "";
            }
        }
    }
}