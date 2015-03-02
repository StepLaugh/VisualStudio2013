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

namespace TestingDestinyAPI
{
    public partial class Character : PhoneApplicationPage
    {
        public Character()
        {
            InitializeComponent();

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

            fetch.Save();

            //http://www.bungie.net/Platform/Destiny/1/Account/4611686018434091019

        }
    }
}