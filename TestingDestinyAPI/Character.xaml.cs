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

            //all the stats should al ready be up.



            userName_txt.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            clanName_txt.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            //clanTag_txt.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            grimoireScore_txt.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            memId_txt.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            goToRaids.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            goToWeekly.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            goToExtras.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            goToSettings.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            char1_level.FontFamily = new FontFamily("/Assets/Fonts/CaviarDreams.ttf#Caviar Dreams");
            char2_level.FontFamily = new FontFamily("/Assets/Fonts/CaviarDreams.ttf#Caviar Dreams");
            char3_level.FontFamily = new FontFamily("/Assets/Fonts/CaviarDreams.ttf#Caviar Dreams");

            //GET
            IsolatedStorageSettings fetch = IsolatedStorageSettings.ApplicationSettings;

            if (fetch.Contains("membershipId"))
            {
                memId_txt.Text = fetch["membershipId"].ToString();
            }

            if (fetch.Contains("userId")) 
            {
                userName_txt.Text = fetch["userId"].ToString();

                int numberChar = userName_txt.Text.Length;
                int newWidth = 50;

                //max number of characters someone can have.
                if (numberChar > 0 && numberChar < 16)
                {
                    titleGuard3.MaxWidth = 400;
                    titleGuard3.Width = newWidth + (numberChar * 25);
                } 
            }



            if (fetch.Contains("grimoireScore"))
            {
                grimoireScore_txt.Text = fetch["grimoireScore"].ToString();
            }

            //if (fetch.Contains("clanName"))
            //{
            //    clanName_txt.Text = fetch["clanName"].ToString();
            //}

            //if (fetch.Contains("clanTag"))
            //{
            //    //clanTag_txt.Text = fetch["clanTag"].ToString();
            //}

            if(fetch.Contains("currChar"))
            {
                _CurrChar = fetch["currChar"].ToString();
            }

            if (clanName_txt.Text == "(Clan Name)")
            {
                clanName_txt.Visibility = Visibility.Collapsed;
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
            //App.Current.RootVisual.DesiredSize.Height = 800;

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

                char1_class.Visibility = Visibility.Visible;
                char1_gender.Visibility = Visibility.Visible;
                char1_level.Visibility = Visibility.Visible;
                char1_race.Visibility = Visibility.Visible;

                char2_class.Visibility = Visibility.Visible;
                char2_gender.Visibility = Visibility.Visible;
                char2_level.Visibility = Visibility.Visible;
                char2_race.Visibility = Visibility.Visible;

                char3_class.Visibility = Visibility.Visible;
                char3_gender.Visibility = Visibility.Visible;
                char3_level.Visibility = Visibility.Visible;
                char3_race.Visibility = Visibility.Visible;

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

                char1_class.Visibility = Visibility.Visible;
                char1_gender.Visibility = Visibility.Visible;
                char1_level.Visibility = Visibility.Visible;
                char1_race.Visibility = Visibility.Visible;

                char2_class.Visibility = Visibility.Visible;
                char2_gender.Visibility = Visibility.Visible;
                char2_level.Visibility = Visibility.Visible;
                char2_race.Visibility = Visibility.Visible;

                char3_class.Visibility = Visibility.Visible;
                char3_gender.Visibility = Visibility.Visible;
                char3_level.Visibility = Visibility.Visible;
                char3_race.Visibility = Visibility.Visible;

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

                char1_class.Visibility = Visibility.Visible;
                char1_gender.Visibility = Visibility.Visible;
                char1_level.Visibility = Visibility.Visible;
                char1_race.Visibility = Visibility.Visible;

                char2_class.Visibility = Visibility.Visible;
                char2_gender.Visibility = Visibility.Visible;
                char2_level.Visibility = Visibility.Visible;
                char2_race.Visibility = Visibility.Visible;

                char3_class.Visibility = Visibility.Visible;
                char3_gender.Visibility = Visibility.Visible;
                char3_level.Visibility = Visibility.Visible;
                char3_race.Visibility = Visibility.Visible;

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

        private void goToSettings_Click(object sender, RoutedEventArgs e)
        {
            App.Current.RootVisual = new Settings();
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

            hideCharDetails();

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

            hideCharDetails();

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

                hideCharDetails();
            

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

        private void hideCharDetails()
        {
            char1_back.Visibility = Visibility.Collapsed;
            char2_back.Visibility = Visibility.Collapsed;
            char3_back.Visibility = Visibility.Collapsed;

            char1_class.Visibility = Visibility.Collapsed;
            char1_gender.Visibility = Visibility.Collapsed;
            char1_level.Visibility = Visibility.Collapsed;
            char1_race.Visibility = Visibility.Collapsed;

            char2_class.Visibility = Visibility.Collapsed;
            char2_gender.Visibility = Visibility.Collapsed;
            char2_level.Visibility = Visibility.Collapsed;
            char2_race.Visibility = Visibility.Collapsed;

            char3_class.Visibility = Visibility.Collapsed;
            char3_gender.Visibility = Visibility.Collapsed;
            char3_level.Visibility = Visibility.Collapsed;
            char3_race.Visibility = Visibility.Collapsed;
        }

        private void char1_back_Click(object sender, RoutedEventArgs e)
        {
            this.char1_btn_Click(sender,e);
        }

        private void char2_back_Click(object sender, RoutedEventArgs e)
        {
            this.char2_btn_Click(sender, e);
        }

        private void char3_back_Click(object sender, RoutedEventArgs e)
        {
            this.char3_btn_Click(sender, e);
        }




    }
}




                