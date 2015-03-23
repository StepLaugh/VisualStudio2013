using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace TestingDestinyAPI
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void goToChar_Click(object sender, RoutedEventArgs e)
        {
            App.Current.RootVisual = new Character();
        }

        private void goToMainPage_Click(object sender, RoutedEventArgs e)
        {
            App.Current.RootVisual = new MainPage();
        }
    }
}