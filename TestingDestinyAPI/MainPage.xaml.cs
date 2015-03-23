                                               
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TestingDestinyAPI.Resources;
using Newtonsoft.Json;
using Windows.Storage;
using Windows.Storage.Streams;
using System.Text;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Newtonsoft.Json.Linq;
using System.Threading;


//http://json2csharp.com/#
//http://blogs.msdn.com/b/pakistan/archive/2013/06/14/getting-started-with-web-requests-amp-json-in-windows-phone.aspx
//API directories.
//http://pastebin.com/GTrVtScf
//Getting GITHUB to work with VS13
//http://michaelcrump.net/setting-up-github-to-work-with-visual-studio-2013-step-by-step
//Used to navigate through pages
//NavigationService.Navigate(new Uri("/Character.xaml", UriKind.Relative));
//GOTOHELP
//https://www.bungie.net/platform/destiny/help/
//Get emblems
//http://www.bungie.net/common/destiny_content/icons/a1314acb5a650eff3229df360576a2f5.jpg
//background image

//*************************
//****    TO DO LIST   ****
//*************************
// + Make it to where JSON can be deseriallized correct
// --> Make sure that clanTag and clanName don't error out.
// +  



namespace TestingDestinyAPI
{

    public partial class MainPage : PhoneApplicationPage
    {
        public string _ConsoleVersion;
        public string _UserID;
        //public string _MemID;
        //used to get membershipID from bungie.net
        
        

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            IsolatedStorageSettings fetch = IsolatedStorageSettings.ApplicationSettings;

            PSN_btn.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            xbox_btn.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            LogIn_btn.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            greeting_txt.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            userName_txt.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            title1_txt.FontFamily = new FontFamily("/Assets/Fonts/FUTRFW.TTF#Futurist Fixed-width");
            title2_txt.FontFamily = new FontFamily("/Assets/Fonts/FUTRFW.TTF#Futurist Fixed-width");
            title3_txt.FontFamily = new FontFamily("/Assets/Fonts/FUTRFW.TTF#Futurist Fixed-width");
            UserInput_txt.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");


            if (fetch.Contains("userId"))
            {
                if (fetch["userId"].ToString() != "")
                {
                    userName_txt.Text = fetch["userId"].ToString();
                }
            }
            else UserInput_txt.Text = "";

            
           
            
            //User has NOT logged in yet
            if(userName_txt.Text == "" || userName_txt.Text == "TextBlock")
            {
                userName_txt.Visibility = Visibility.Collapsed;
                greeting_txt.Visibility = Visibility.Collapsed;
                LogIn_btn.Visibility = Visibility.Collapsed;
                clearText.Visibility = Visibility.Collapsed;
                UserInput_txt.Visibility = Visibility.Collapsed;
                //move the locations
                PSN_btn.Margin = new Thickness(80, 275, 0, 0);
                xbox_btn.Margin = new Thickness(246, 275, 0, 0);
                UserInput_txt.Margin = new Thickness(123, 380, 0, 0);
                LogIn_btn.Margin = new Thickness(123, 280, 0, 0);
         
                //if first time signing in, change default character to "0"
                if (!fetch.Contains("currChar"))
                {
                    fetch.Add("currChar", "0");
                }
                else
                {
                    fetch.Remove("currChar");
                    fetch.Add("currChar", "0");
                }
                
            }
            //If user has logged in
            else
            {
                PSN_btn.Visibility = Visibility.Collapsed;
                xbox_btn.Visibility = Visibility.Collapsed;
                UserInput_txt.Visibility = Visibility.Collapsed;
                //Force the name into the entry box
                UserInput_txt.Text = userName_txt.Text;
            if (fetch.Contains("consoleId"))
            {
                if (fetch["consoleId"].ToString() != null) 
                {
                    _ConsoleVersion = fetch["consoleId"].ToString();
                }
            }

            }

   
            //Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            //**********
            //  DEBUG **
            //**********



            //Enable the specific buttons
            /*if(fetch.Contains("consoleId"))
            {
                if(fetch["consoleId"].ToString() == "2")
                {
                    PSN_btn.IsEnabled = true;
                    PSN_btn.Content = "PSN";
                    _ConsoleVersion = 0;
                }
                else
                {
                    _ConsoleVersion = 1;
                    //PSN_btn.Visibility = Visibility.Collapsed;
                    PSN_btn.IsEnabled = false;
                    PSN_btn.Content = "Tap again for PSN";
                }


                if (fetch["consoleId"].ToString() == "1")
                {
                    xbox_btn.IsEnabled = true;
                    xbox_btn.Content = "Xbox";
                    _ConsoleVersion = 0;
                }
                else
                {
                    _ConsoleVersion = 2;
                    //xbox_btn.Visibility = Visibility.Collapsed;
                    xbox_btn.IsEnabled = false;
                    xbox_btn.Content = "Tap again for Xbox";
                }

            }
            */
   
        }


        private void clearText_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings fetch = IsolatedStorageSettings.ApplicationSettings;

            //Allow Xbox and PSN buttons to be shown
            PSN_btn.Visibility = Visibility.Visible;
            xbox_btn.Visibility = Visibility.Visible;
            LogIn_btn.Visibility = Visibility.Collapsed;
            UserInput_txt.Text = "";
            //reset console version.
            _ConsoleVersion = "0";

            userName_txt.Visibility = Visibility.Collapsed;
            greeting_txt.Visibility = Visibility.Collapsed;
            LogIn_btn.Visibility = Visibility.Collapsed;
            clearText.Visibility = Visibility.Collapsed;
            UserInput_txt.Visibility = Visibility.Collapsed;
            //move the locations
            PSN_btn.Margin = new Thickness(80, 275, 0, 0);
            xbox_btn.Margin = new Thickness(246, 275, 0, 0);
            UserInput_txt.Margin = new Thickness(123, 445, 0, 0);
            LogIn_btn.Margin = new Thickness(123, 350, 0, 0);

            //if first time signing in, change default character to "0"
            if (!fetch.Contains("currChar"))
            {
                fetch.Add("currChar", "0");
            }
            else
            {
                fetch.Remove("currChar");
                fetch.Add("currChar", "0");
            }
        }

        private void xbox_btn_Click(object sender, RoutedEventArgs e)
        {
            if (_ConsoleVersion == "1")
            {
                PSN_btn.IsEnabled = true;
                PSN_btn.Content = "PSN";
                _ConsoleVersion = "0";
                UserInput_txt.Visibility = Visibility.Collapsed;

            }
            else
            {
                _ConsoleVersion = "1";
                //PSN_btn.Visibility = Visibility.Collapsed;
                PSN_btn.IsEnabled = false;
                //PSN_btn.Content = "Tap again for PSN";
                UserInput_txt.Visibility = Visibility.Visible;
                //LogIn_btn.Visibility = Visibility.Visible;
            }

        }

        private void PSN_btn_Click(object sender, RoutedEventArgs e)
        {

            if (_ConsoleVersion == "2")
            {
                xbox_btn.IsEnabled = true;
                xbox_btn.Content = "Xbox";
                _ConsoleVersion = "0";
                UserInput_txt.Visibility = Visibility.Collapsed;
            }
            else
            {
                _ConsoleVersion = "2";
                //xbox_btn.Visibility = Visibility.Collapsed;
                xbox_btn.IsEnabled = false;
                //xbox_btn.Content = "Tap again for Xbox";
                UserInput_txt.Visibility = Visibility.Visible;
                //LogIn_btn.Visibility = Visibility.Visible;
            }
        }


        private void UserInput_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LogIn_btn.Visibility == Visibility.Collapsed)
            {
                LogIn_btn.Visibility = Visibility.Visible;
            }
        }

        /*
        private void UserInput_txt_Tap(object sender, SelectionChangedEventArgs e)
        {
            UserInput_txt.Text = "";
        }
        */

        //***********************************************************************
        private void LogIn_btn_Click(object sender, RoutedEventArgs e)
        {
            LoadingBar.Visibility = Visibility.Visible;
            _UserID = UserInput_txt.Text;

            //check to see if entry is null
            
            /*
            if (_UserID == "")
            {
                //DO SOMETHING
            }
            //now that we know that it is not empty
            else
            
            */
            
            {
                //****************************************
                //** Save _UserID into isolated stroage **
                //****************************************
                IsolatedStorageSettings save = IsolatedStorageSettings.ApplicationSettings;
                if (!save.Contains("userId"))
                {
                    save.Add("userId", _UserID);
                }
                else
                {
                    save.Remove("userId");
                    save.Add("userId", _UserID);
                }
                //Do the same with Console Version
                if (!save.Contains("consoleId"))
                {
                    save.Add("consoleId", _ConsoleVersion);
                }
                else
                {
                    save.Remove("consoleId");
                    save.Add("consoleId", _ConsoleVersion);
                }
                //save info
                save.Save();


                //This is used to get membershipId from Bungie.net
                string pushURL = ("http://www.bungie.net/Platform/Destiny/SearchDestinyPlayer/" + _ConsoleVersion + "/" + _UserID + "/");

                getMemId mem = new getMemId();

                mem.Download(pushURL);

            }
            
   
        }

        private void UserInput_txt_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }











        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}