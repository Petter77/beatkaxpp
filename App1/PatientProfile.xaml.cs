using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Windows.Networking.NetworkOperators;
using Windows.System;
using System;    // Z powodu braku bazy operujemy na pliku tekstowym
using System.IO; //
using Windows.UI.ApplicationSettings;

namespace App1
{
    public sealed partial class PatientProfile : Page
    {
        private string _userID;
        public PatientProfile()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is string userId)
            {
                _userID = userId;
            }
        }
        private void LogOut(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage));
        }
        private void MenuItemClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                string buttonContent = button.Content.ToString();

                // Navigate to the corresponding page based on menu selection
                switch (buttonContent)
                {
                    case "Profil":
                        MainFrame.Navigate(typeof(PatientProfileInfo), _userID); // Navigate to ProfilePage
                        break;
                    case "Recepty":
                        MainFrame.Navigate(typeof(PatientRecipes), _userID); // Navigate to SettingsPage
                        break;
                    case "Historia Medyczna":
                        MainFrame.Navigate(typeof(PatientHistory), _userID); // Navigate to LoginPage
                        break;
                    case "Skierowania":
                        MainFrame.Navigate(typeof(PatientReferrals), _userID);
                        break;
                }
            }
        }


    }
}