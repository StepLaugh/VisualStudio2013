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
        public string _CurrChar;

        IsolatedStorageSettings save = IsolatedStorageSettings.ApplicationSettings;

        public Character()
        {

            InitializeComponent();

            char1_border.Visibility = Visibility.Collapsed;
            char2_border.Visibility = Visibility.Collapsed;
            char3_border.Visibility = Visibility.Collapsed;

            goToRaids.Visibility = Visibility.Collapsed;
            goToWeekly.Visibility = Visibility.Collapsed;
            goToExtras.Visibility = Visibility.Collapsed;
            goToSettings.Visibility = Visibility.Collapsed;
            quickNightfall.Visibility = Visibility.Collapsed;
            quickWeekly.Visibility = Visibility.Collapsed;
            quickVOG.Visibility = Visibility.Collapsed;
            quickCE.Visibility = Visibility.Collapsed;

            char1_back.Visibility = Visibility.Visible;
            char2_back.Visibility = Visibility.Visible;
            char3_back.Visibility = Visibility.Visible;



            userName_txt.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            clanName_txt.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            //clanTag_txt.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            grimoireScore_txt.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            memId_txt.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            goToRaids.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            goToWeekly.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            goToExtras.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            goToSettings.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");

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
                //clanTag_txt.Text = fetch["clanTag"].ToString();
            }

            if(fetch.Contains("currChar"))
            {
                _CurrChar = fetch["currChar"].ToString();
            }


            fetch.Save();

            //MAIN CODE
            //*********

            //Check to see if weekly and nightfall are done
            
            //Re-enable which charcater to select
            if (_CurrChar == "1")
            {
                enable1();
            }
            if (_CurrChar == "2")
            {
                enable2();
            }
            if (_CurrChar == "3")
            {
                enable3();
            }





            
        }

        private void goToLogin_btn_Click(object sender, RoutedEventArgs e)
        {
            
            App.Current.RootVisual = new MainPage();
            //(Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

        }

        private void char1_btn_Click(object sender, RoutedEventArgs e)
        {
            if (_CurrChar == "1")
            {
                char1_btn.IsEnabled = true;
                char2_btn.IsEnabled = true;
                char3_btn.IsEnabled = true;

                char1_border.Visibility = Visibility.Collapsed;
                char2_border.Visibility = Visibility.Collapsed;
                char3_border.Visibility = Visibility.Collapsed;

                goToRaids.Visibility = Visibility.Collapsed;
                goToWeekly.Visibility = Visibility.Collapsed;
                goToExtras.Visibility = Visibility.Collapsed;
                goToSettings.Visibility = Visibility.Collapsed;

                quickNightfall.Visibility = Visibility.Collapsed;
                quickWeekly.Visibility = Visibility.Collapsed;
                quickVOG.Visibility = Visibility.Collapsed;
                quickCE.Visibility = Visibility.Collapsed;

                char1_back.Visibility = Visibility.Visible;
                char2_back.Visibility = Visibility.Visible;
                char3_back.Visibility = Visibility.Visible;

                _CurrChar = "0";
            }
            else
            {
                enable1();
            }
        }


        private void char2_btn_Click(object sender, RoutedEventArgs e)
        {
            if (_CurrChar == "2")
            {
                char1_btn.IsEnabled = true;
                char2_btn.IsEnabled = true;
                char3_btn.IsEnabled = true;

                char1_border.Visibility = Visibility.Collapsed;
                char2_border.Visibility = Visibility.Collapsed;
                char3_border.Visibility = Visibility.Collapsed;

                goToRaids.Visibility = Visibility.Collapsed;
                goToWeekly.Visibility = Visibility.Collapsed;
                goToExtras.Visibility = Visibility.Collapsed;
                goToSettings.Visibility = Visibility.Collapsed;

                quickNightfall.Visibility = Visibility.Collapsed;
                quickWeekly.Visibility = Visibility.Collapsed;
                quickVOG.Visibility = Visibility.Collapsed;
                quickCE.Visibility = Visibility.Collapsed;

                char1_back.Visibility = Visibility.Visible;
                char2_back.Visibility = Visibility.Visible;
                char3_back.Visibility = Visibility.Visible;

                _CurrChar = "0";
            }
            else
            {
                enable2();
            }
        }

        private void char3_btn_Click(object sender, RoutedEventArgs e)
        {
            if (_CurrChar == "3")
            {
                char1_btn.IsEnabled = true;
                char2_btn.IsEnabled = true;
                char3_btn.IsEnabled = true;

                char1_border.Visibility = Visibility.Collapsed;
                char2_border.Visibility = Visibility.Collapsed;
                char3_border.Visibility = Visibility.Collapsed;

                goToRaids.Visibility = Visibility.Collapsed;
                goToWeekly.Visibility = Visibility.Collapsed;
                goToExtras.Visibility = Visibility.Collapsed;
                goToSettings.Visibility = Visibility.Collapsed;

                quickNightfall.Visibility = Visibility.Collapsed;
                quickWeekly.Visibility = Visibility.Collapsed;
                quickVOG.Visibility = Visibility.Collapsed;
                quickCE.Visibility = Visibility.Collapsed;

                char1_back.Visibility = Visibility.Visible;
                char2_back.Visibility = Visibility.Visible;
                char3_back.Visibility = Visibility.Visible;

                _CurrChar = "0";
            }
            else
            {
                enable3();
            }
        }

        private void goToRaids_Click(object sender, RoutedEventArgs e)
        {
            App.Current.RootVisual = new Raids();
        }

        private void goToWeekly_Click(object sender, RoutedEventArgs e)
        {

        }

        private void enable1()
        {
            
                this._CurrChar = "1";

                //Disable other buttons
                char2_btn.IsEnabled = false;
                char3_btn.IsEnabled = false;

                char1_border.Visibility = Visibility.Visible;
                char2_border.Visibility = Visibility.Collapsed;
                char3_border.Visibility = Visibility.Collapsed;

                goToRaids.Visibility = Visibility.Visible;
                goToWeekly.Visibility = Visibility.Visible;
                goToExtras.Visibility = Visibility.Visible;
                goToSettings.Visibility = Visibility.Visible;

                quickNightfall.Visibility = Visibility.Visible;
                quickWeekly.Visibility = Visibility.Visible;
                quickVOG.Visibility = Visibility.Visible;
                quickCE.Visibility = Visibility.Visible;

                char1_back.Visibility = Visibility.Collapsed;
                char2_back.Visibility = Visibility.Collapsed;
                char3_back.Visibility = Visibility.Collapsed;
            

            if (!save.Contains("currChar"))
            {
                save.Add("currChar", _CurrChar);
            }
            else
            {
                save.Remove("currChar");
                save.Add("currChar", _CurrChar);
            }
        }

        private void enable2()
        {
            
                this._CurrChar = "2";

                //Disable other buttons
                char1_btn.IsEnabled = false;
                char3_btn.IsEnabled = false;

                char2_border.Visibility = Visibility.Visible;
                char1_border.Visibility = Visibility.Collapsed;
                char3_border.Visibility = Visibility.Collapsed;

                goToRaids.Visibility = Visibility.Visible;
                goToWeekly.Visibility = Visibility.Visible;
                goToExtras.Visibility = Visibility.Visible;
                goToSettings.Visibility = Visibility.Visible;

                quickNightfall.Visibility = Visibility.Visible;
                quickWeekly.Visibility = Visibility.Visible;
                quickVOG.Visibility = Visibility.Visible;
                quickCE.Visibility = Visibility.Visible;

                char1_back.Visibility = Visibility.Collapsed;
                char2_back.Visibility = Visibility.Collapsed;
                char3_back.Visibility = Visibility.Collapsed;
            

            if (!save.Contains("currChar"))
            {
                save.Add("currChar", _CurrChar);
            }
            else
            {
                save.Remove("currChar");
                save.Add("currChar", _CurrChar);
            }
        }

        private void enable3()
        {
            
                this._CurrChar = "3";

                //Disable other buttons
                char2_btn.IsEnabled = false;
                char1_btn.IsEnabled = false;

                char3_border.Visibility = Visibility.Visible;
                char2_border.Visibility = Visibility.Collapsed;
                char1_border.Visibility = Visibility.Collapsed;

                goToRaids.Visibility = Visibility.Visible;
                goToWeekly.Visibility = Visibility.Visible;
                goToExtras.Visibility = Visibility.Visible;
                goToSettings.Visibility = Visibility.Visible;

                quickNightfall.Visibility = Visibility.Visible;
                quickWeekly.Visibility = Visibility.Visible;
                quickVOG.Visibility = Visibility.Visible;
                quickCE.Visibility = Visibility.Visible;

                char1_back.Visibility = Visibility.Collapsed;
                char2_back.Visibility = Visibility.Collapsed;
                char3_back.Visibility = Visibility.Collapsed;
            

            if (!save.Contains("currChar"))
            {
                save.Add("currChar", _CurrChar);
            }
            else
            {
                save.Remove("currChar");
                save.Add("currChar", _CurrChar);
            }

        }
    }
}




                