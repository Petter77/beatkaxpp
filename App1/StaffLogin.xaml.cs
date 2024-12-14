using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Windows.UI.Popups;
using Npgsql;
using System.Collections.Generic;


namespace App1
{
    public sealed partial class StaffLogin : Page
    {
        private string host = "localhost";
        private string database = "BazaMedyczna";
        private string Username = "lekarze";
        private string Password = "haslo";
        public StaffLogin()
        {
            this.InitializeComponent();
            LoadUserRoles();
        }
        private async void LoadUserRoles()
        {
            var cs = $"Host={host};Username={Username};Password={Password};Database={database}";
            using (var con = new NpgsqlConnection(cs))
            {
                await con.OpenAsync();

                string sql = "SELECT nazwa FROM \"RolePersonelu\"";
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        List<string> roles = new List<string>();
                        while (await reader.ReadAsync())
                        {
                            roles.Add(reader.GetString(0));
                        }

                        UserRole.ItemsSource = roles;
                    }
                }
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
        private void EmptyCheck(object sender, RoutedEventArgs e)
        {
            if (IdBox.Text == "")
            {
                IdEmpty.Text = "Pole musi zostać wypełnione !";
                IdEmpty.Visibility = Visibility.Visible;
            }
            else
            {
                IdEmpty.Visibility = Visibility.Collapsed;
            }

        }
        private async void StaffLoginCheck(object sender, RoutedEventArgs e)
        {
            string selectedRole = (UserRole.SelectedItem as string)?.Trim();
            string userId = IdBox.Text;
            string password = PassBox.Password;
            var cs = $"Host={host};Username={Username};Password={Password};Database={database}";
            using (var con = new NpgsqlConnection(cs))
            {
                await con.OpenAsync();

                string sql = @"
        SELECT COUNT(*) 
        FROM ""PersonelMedyczny"" pm
        JOIN ""RolePersonelu"" rp ON pm.""idRoli"" = rp.""id""
        WHERE rp.""nazwa"" = @role AND pm.""imie"" = @id AND pm.""haslo"" = @password";

                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("role", selectedRole);
                    cmd.Parameters.AddWithValue("id", userId);
                    cmd.Parameters.AddWithValue("password", password);

                    var count = (long)await cmd.ExecuteScalarAsync();
                    //Nie wiem jeszcze jak zrobimy ten staff Profile więc narazie nawet ciasteczke nie zrobiłem
                    if (count > 0)
                    {
                        Frame.Navigate(typeof(StaffProfile));
                    }
                    else
                    {
                        Warning.Visibility = Visibility.Visible;
                        Warning.Text = "Podano Błędne ID i/lub Hasło";
                    }
                }
            }
        }
    }
}

