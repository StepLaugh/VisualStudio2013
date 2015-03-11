using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.Windows.Media;

namespace TestingDestinyAPI
{
    public partial class Character : PhoneApplicationPage
    {
        public Character()
        {
            InitializeComponent();

            //userName_txt.FontFamily = new FontFamily("/Assets/Fonts/CaviarDreams.ttf#Caviar Dreams");
            //clanName_txt.FontFamily = new FontFamily("/Assets/Fonts/CaviarDreams.ttf#Caviar Dreams");
            //clanTag_txt.FontFamily = new FontFamily("/Assets/Fonts/CaviarDreams.ttf#Caviar Dreams");
            //grimoireScore_txt.FontFamily = new FontFamily("/Assets/Fonts/CaviarDreams.ttf#Caviar Dreams");
            //memId_txt.FontFamily = new FontFamily("/Assets/Fonts/CaviarDreams.ttf#Caviar Dreams");

            //GET
            IsolatedStorageSettings fetch = IsolatedStorageSettings.ApplicationSettings;

            if (fetch.Contains("membershipId"))
            {
                memId_txt.Text = fetch["membershipId"].ToString();
            }

            if (fetch.Contains("userId")) 
            {
                userName_txt.Text = fetch["userId"].ToString();
            }

            if (fetch.Contains("grimoireScore"))
            {
                grimoireScore_txt.Text = fetch["grimoireScore"].ToString();
            }

            if (fetch.Contains("clanName"))
            {
                clanName_txt.Text = fetch["clanName"].ToString();
            }

            if (fetch.Contains("clanTag"))
            {
                clanTag_txt.Text = fetch["clanTag"].ToString();
            }

            fetch.Save();

            //MAIN CODE
            //*********

            //Debug
            





            
        }

        private void goToLogin_btn_Click(object sender, RoutedEventArgs e)
        {
            //App.Current.RootVisual = new MainPage();
            (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

        }
    }
}