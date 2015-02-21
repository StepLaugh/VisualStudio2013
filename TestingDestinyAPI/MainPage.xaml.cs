﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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


//http://json2csharp.com/#
//http://blogs.msdn.com/b/pakistan/archive/2013/06/14/getting-started-with-web-requests-amp-json-in-windows-phone.aspx
//API directories.
//http://pastebin.com/GTrVtScf
//Getting GITHUB to work with VS13
//http://michaelcrump.net/setting-up-github-to-work-with-visual-studio-2013-step-by-step

namespace TestingDestinyAPI
{


    public partial class MainPage : PhoneApplicationPage
    {
        public int ConsoleVersion;
        public string UserID;

        public class Response
        {
            public string iconPath { get; set; }
            public int membershipType { get; set; }
            public string membershipId { get; set; }
            public string displayName { get; set; }
        }

        public class MessageData
        {
        }

        public class RootObject
        {
            public List<Response> Response { get; set; }
            public int ErrorCode { get; set; }
            public int ThrottleSeconds { get; set; }
            public string ErrorStatus { get; set; }
            public string Message { get; set; }
            public MessageData MessageData { get; set; }
        }


        // Constructor
        public MainPage()
        {
            InitializeComponent();

            //Xbox
            if (ConsoleVersion == 1)
            {
                UserInput_txt.Text = "Enter your Gamertag";
            }

            //PSN
            if (ConsoleVersion == 2)
            {
                UserInput_txt.Text = "Enter your PSN ID";
            }
            
              // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            
        }



        private void xbox_btn_Click(object sender, RoutedEventArgs e)
        {
            if (ConsoleVersion == 1)
            {
                PSN_btn.IsEnabled = true;
                PSN_btn.Content = "PSN";
                ConsoleVersion = 0;
            }
            else
            {
                ConsoleVersion = 1;
                //PSN_btn.Visibility = Visibility.Collapsed;
                PSN_btn.IsEnabled = false;
                PSN_btn.Content = "Tap again for PSN";
            }

        }

        private void PSN_btn_Click(object sender, RoutedEventArgs e)
        {

            if (ConsoleVersion == 2)
            {
                xbox_btn.IsEnabled = true;
                xbox_btn.Content = "Xbox";
                ConsoleVersion = 0;
            }
            else
            {
                ConsoleVersion = 2;
                //xbox_btn.Visibility = Visibility.Collapsed;
                xbox_btn.IsEnabled = false;
                xbox_btn.Content = "Tap again for Xbox";
            }
        }
        //****************************************************************************************
        private void LogIn_btn_Click(object sender, RoutedEventArgs e)
        {

            Download();

           
        }


        
        public void Download()
        {
            DownloadString((result) =>
            {
                
                //!!Require to import Newtonsoft.Json.dll for JObject!!
                JObject fdata = JObject.Parse(result);

                //****************
                // RIGHT HERE !! *
                //****************

                //I want to be able to parse through the Json object till I find "membershipId" and then display the contents.

                UserInput_txt.Text = fdata["Message"].ToString();

                //********
                // /END **
                //********

            }, "http://www.bungie.net/Platform/Destiny/SearchDestinyPlayer/1/leroyjenkins980/");
        }

        public void DownloadString(Action<string> callback, string url)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += (p, q) =>
            {
                if (q.Error == null)
                {
                    callback(q.Result);

                }

            };

            client.DownloadStringAsync(new Uri(url));

        }
    

        // **************************************
        // **  OLD CODE I DON'T USE RIGHT NOW  **
        // **************************************

        // **** Used to retrieve the info (Doesn't work) ****
        
        //UserID = UserInput_txt.Text;
        //string url = "http://www.bungie.net/Platform/Destiny/SearchDestinyPlayer/" + ConsoleVersion + "/" + UserID +"/";
        //WebClient webClient = new WebClient();
        //string test = string.Format("http://www.bungie.net/Platform/Destiny/SearchDestinyPlayer/{0}/{1}/", ConsoleVersion, UserInput_txt.Text);

        //webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
        //webClient.DownloadStringAsync(new Uri(string.Format("http://www.bungie.net/Platform/Destiny/SearchDestinyPlayer/{0}/{1}/", ConsoleVersion, UserInput_txt.Text)));
        //MessageBox.Show(test);


        
        /*private void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Result))
                {
                    //Parse result into Json string
                    
                    //var root1 = JsonConvert.DeserializeObject<RootObject>(e.Result);
                    var root2 = JsonConvert.DeserializeObject<Response>(e.Result);
                    this.DataContext = root2;
                    MessageBox.Show(root2.membershipId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        */



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