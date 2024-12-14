using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Popups;
using Npgsql;


namespace App1
{
    public sealed partial class TrustedProfile : Page
    {
        private string host = "localhost";
        private string database = "BazaMedyczna";
        private string Username = "pacjent";
        private string Password = "haslo";
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
        private async void TrustedProfileCheck(object sender, RoutedEventArgs e)
        {
            var cs = "Host=" + host + ";Username=" + Username + ";Password=" + Password + ";Database=" + database;
            using (var con = new NpgsqlConnection(cs))
            {
                await con.OpenAsync();

                string userId = txtBox.Text;
                if (userId.Length != 11)
                {
                    Warning.Text = "Pesel musi składać się z 11 cyfr";
                    Warning.Visibility = Visibility.Visible;
                    return;
                }

                string sql = "SELECT COUNT(*) FROM \"Pacjenci\" WHERE pesel = CAST(@userId AS NUMERIC)";
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("userId", userId);

                    var count = (long)await cmd.ExecuteScalarAsync();

                    if (count > 0)
                    {
                        var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                        localSettings.Values["userId"] = userId;
                        Frame.Navigate(typeof(PatientProfile));

                    }
                    else
                    {
                        Warning.Text = "Nie ma pacjenta z takim PESELEM!";
                        Warning.Visibility = Visibility.Visible;
                    }
                }
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