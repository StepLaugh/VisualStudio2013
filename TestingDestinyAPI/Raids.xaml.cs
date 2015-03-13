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
    public partial class Raids : PhoneApplicationPage
    {
        public Raids()
        {
            InitializeComponent();
        }

        private void RaidsPanorama_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Save1_btn_Click(object sender, RoutedEventArgs e)
        {
            saveInfo();
        }

        private void Save2_btn_Click(object sender, RoutedEventArgs e)
        {
            saveInfo();
        }

        private void saveInfo()
        {
            //Save all the info
            App.Current.RootVisual = new Character();

        }

        //VOG
        private void VOG_H_1_Checked(object sender, RoutedEventArgs e)
        {
            VOG_N_1.IsChecked = true;
        }

        private void VOG_H_2_Checked(object sender, RoutedEventArgs e)
        {
            VOG_N_2.IsChecked = true;
        }

        private void VOG_H_3_Checked(object sender, RoutedEventArgs e)
        {
            VOG_N_3.IsChecked = true;
        }

        private void VOG_H_4_Checked(object sender, RoutedEventArgs e)
        {
            VOG_N_4.IsChecked = true;
        }

        private void VOG_H_5_Checked(object sender, RoutedEventArgs e)
        {
            VOG_N_5.IsChecked = true;
        }

        private void VOG_H_6_Checked(object sender, RoutedEventArgs e)
        {
            VOG_N_6.IsChecked = true;
        }

        private void VOG_H_7_Checked(object sender, RoutedEventArgs e)
        {
            VOG_N_7.IsChecked = true;
        }


        //CROTAS END
        private void CE_H_1_Checked(object sender, RoutedEventArgs e)
        {
            CE_N_1.IsChecked = true;
        }

        private void CE_H_2_Checked(object sender, RoutedEventArgs e)
        {
            CE_N_2.IsChecked = true;
        }

        private void CE_H_3_Checked(object sender, RoutedEventArgs e)
        {
            CE_N_3.IsChecked = true;
        }

        private void CE_H_4_Checked(object sender, RoutedEventArgs e)
        {
            CE_N_4.IsChecked = true;
        }

        private void CE_H_5_Checked(object sender, RoutedEventArgs e)
        {
            CE_N_5.IsChecked = true;
        }

        private void CE_H_6_Checked(object sender, RoutedEventArgs e)
        {
            CE_N_6.IsChecked = true;
        }



    }
}