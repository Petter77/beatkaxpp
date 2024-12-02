using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace App1
{
    public sealed partial class PatientRecipes : Page
    {
        //private string _userID;
        public PatientRecipes()
        {
            this.InitializeComponent();
        }
        /*protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is string userId)
            {
                _userID = userId;
                PatientID.Text = $"Pacjent: {userId}"; // Use the passed user ID
            }
        }*/


    }
}