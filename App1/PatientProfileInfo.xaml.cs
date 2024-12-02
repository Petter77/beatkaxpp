using System;
using System.IO;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace App1
{
    public sealed partial class PatientProfileInfo : Page
    {
        private string userID;

        public PatientProfileInfo()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is string _userId)
            {
                userID = _userId;
                GetProfileData(userID);
            }
        }

        // Method to get the profile data and update the UI
        public void GetProfileData(string profileId)
        {
            //Ścieżka będzie inna 
            string filePath = "D:\\github\\beatkaxpp\\Data\\Profiles.txt";  // The path to the Profiles.txt file
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Split the line by spaces (or any other delimiter like comma, tab, etc.)
                        string[] profileData = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if (profileData.Length >= 6)
                        {
                            string id = profileData[0];
                            string name = profileData[1];
                            string surname = profileData[2];
                            string age = profileData[3];
                            string birthday = profileData[4];
                            string bloodType = profileData[5];

                            // Check if the current ID matches the one you're searching for
                            if (id == profileId)
                            {
                                // If match found, update the UI controls
                                // Use Dispatcher to run the UI update on the UI thread
                                DispatcherQueue.TryEnqueue(() =>
                                {
                                    PatientID.Text = userID;
                                    PatientName.Text = name;
                                    PatientSurname.Text = surname;
                                    PatientAge.Text = age;
                                    PatientBirthdate.Text = birthday;
                                    PatientBloodType.Text = bloodType;
                                });
                                return; // Stop the loop once the matching profile is found
                            }
                        }
                    }

                    // If no match found, display a message (optional)
                    DispatcherQueue.TryEnqueue(() =>
                    {
                        // Optionally, you can show an error or notification here
                        PatientID.Text = "Profile not found";
                    });
                }
            }
            catch (Exception ex)
            {
                // Handle file not found or other errors
                DispatcherQueue.TryEnqueue(() =>
                {
                    // Show error on the UI
                    PatientID.Text = $"Error: {ex.Message}";
                });
            }
        }
    }
}
