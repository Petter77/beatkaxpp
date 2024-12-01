using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Windows.UI.Popups;


namespace App1
{
    public sealed partial class StaffLogin : Page
    {
        public StaffLogin()
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
            if(IdBox.Text == "01234567891")
            {
                Frame.Navigate(typeof(PatientProfile));
            }
        }
        private void EmptyCheck(object sender, RoutedEventArgs e)
        {
            if(IdBox.Text == "")
            {
                IdEmpty.Text = "Pole musi zostać wypełnione !";
                IdEmpty.Visibility = Visibility.Visible;
            }
            else
            {
                IdEmpty.Visibility = Visibility.Collapsed;
            }

        }
        private void StaffLoginCheck(object sender, RoutedEventArgs e)
        {
            var selected = UserRole.SelectedItem as ComboBoxItem;
            string selectedRole = selected.Content.ToString();
           
            switch (selectedRole)
            {
                case "Administrator":
                    if(IdBox.Text == "Admin" && PassBox.Password == "12345")
                    {
                        Frame.Navigate (typeof(StaffProfile));
                    }
                    else
                    {
                        Warning.Visibility = Visibility.Visible;
                        Warning.Text = "Podano Błędne ID i/lub Hasło";
                    }
                    break;
                case "Lekarz":
                    if (IdBox.Text == "Lekarz" && PassBox.Password == "12345")
                    {
                        Frame.Navigate(typeof(StaffProfile));
                    }
                    else
                    {
                        Warning.Visibility = Visibility.Visible;
                        Warning.Text = "Podano Błędne ID i/lub Hasło";
                    }
                    break;
                case "Technik Medyczny":
                    if (IdBox.Text == "Technik" && PassBox.Password == "12345")
                    {
                        Frame.Navigate(typeof(StaffProfile));

                    }
                    else
                    {
                        Warning.Visibility = Visibility.Visible;
                        Warning.Text = "Podano Błędne ID i/lub Hasło";
                    }
                    break;
                case "Ratownik Medyczny":
                    if (IdBox.Text == "Ratownik" && PassBox.Password == "12345")
                    {
                        Frame.Navigate(typeof(StaffProfile));
                    }
                    else
                    {
                        Warning.Visibility = Visibility.Visible;
                        Warning.Text = "Podano Błędne ID i/lub Hasło";
                    }
                    break;  
            }
        }
    }
}