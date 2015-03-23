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
    public partial class Raids : PhoneApplicationPage
    {
        public string _CurrChar;
        public string temp;
        public IsolatedStorageSettings mem = IsolatedStorageSettings.ApplicationSettings;

        public Raids()
        {
            InitializeComponent();
            RaidsPanorama.FontFamily = new FontFamily("/Assets/Fonts/NordicAdvancedRegular.otf#Nordica Advanced");
            
            //Should be 1,2, or 3
            if (mem.Contains("currChar"))
            {
                _CurrChar = mem["currChar"].ToString();
            }
           
            // VOG NORMAL
            if (mem.Contains("VOG_N_1_" + _CurrChar))
            {
                VOG_N_1.IsChecked = true;
            } 
            else VOG_N_1.IsChecked = false;

            if (mem.Contains("VOG_N_2_" + _CurrChar))
            {
                VOG_N_2.IsChecked = true;
            }
            else VOG_N_2.IsChecked = false;

            if (mem.Contains("VOG_N_3_" + _CurrChar))
            {
                VOG_N_3.IsChecked = true;
            }
            else VOG_N_3.IsChecked = false;

            if (mem.Contains("VOG_N_4_" + _CurrChar))
            {
                VOG_N_4.IsChecked = true;
            }
            else VOG_N_4.IsChecked = false;

            if (mem.Contains("VOG_N_5_" + _CurrChar))
            {
                VOG_N_5.IsChecked = true;
            }
            else VOG_N_5.IsChecked = false;

            if (mem.Contains("VOG_N_6_" + _CurrChar))
            {
                VOG_N_6.IsChecked = true;
            }
            else VOG_N_6.IsChecked = false;

            if (mem.Contains("VOG_N_7_" + _CurrChar))
            {
                VOG_N_7.IsChecked = true;
            }
            else VOG_N_7.IsChecked = false;

            // VOG HARD
            if (mem.Contains("VOG_H_1_" + _CurrChar))
            {
                VOG_H_1.IsChecked = true;
            }
            else VOG_H_1.IsChecked = false;

            if (mem.Contains("VOG_H_2_" + _CurrChar))
            {
                VOG_H_2.IsChecked = true;
            }
            else VOG_H_2.IsChecked = false;

            if (mem.Contains("VOG_H_3_" + _CurrChar))
            {
                VOG_H_3.IsChecked = true;
            }
            else VOG_H_3.IsChecked = false;

            if (mem.Contains("VOG_H_4_" + _CurrChar))
            {
                VOG_H_4.IsChecked = true;
            }
            else VOG_H_4.IsChecked = false;

            if (mem.Contains("VOG_H_5_" + _CurrChar))
            {
                VOG_H_5.IsChecked = true;
            }
            else VOG_H_5.IsChecked = false;

            if (mem.Contains("VOG_H_6_" + _CurrChar))
            {
                VOG_H_6.IsChecked = true;
            }
            else VOG_H_6.IsChecked = false;

            if (mem.Contains("VOG_H_7_" + _CurrChar))
            {
                VOG_H_7.IsChecked = true;
            }
            else VOG_H_7.IsChecked = false;

            // CE NORMAL
            if (mem.Contains("CE_N_1_" + _CurrChar))
            {
                CE_N_1.IsChecked = true;
            }
            else CE_N_1.IsChecked = false;

            if (mem.Contains("CE_N_2_" + _CurrChar))
            {
                CE_N_2.IsChecked = true;
            }
            else CE_N_2.IsChecked = false;

            if (mem.Contains("CE_N_3_" + _CurrChar))
            {
                CE_N_3.IsChecked = true;
            }
            else CE_N_3.IsChecked = false;

            if (mem.Contains("CE_N_4_" + _CurrChar))
            {
                CE_N_4.IsChecked = true;
            }
            else CE_N_4.IsChecked = false;

            if (mem.Contains("CE_N_5_" + _CurrChar))
            {
                CE_N_5.IsChecked = true;
            }
            else CE_N_5.IsChecked = false;

            if (mem.Contains("CE_N_6_" + _CurrChar))
            {
                CE_N_6.IsChecked = true;
            }
            else CE_N_6.IsChecked = false;

            if (mem.Contains("CE_N_7_" + _CurrChar))
            {
                CE_N_7.IsChecked = true;
            }
            else CE_N_7.IsChecked = false;

            // CE HARD
            if (mem.Contains("CE_H_1_" + _CurrChar))
            {
                CE_H_1.IsChecked = true;
            }
            else CE_H_1.IsChecked = false;

            if (mem.Contains("CE_H_2_" + _CurrChar))
            {
                CE_H_2.IsChecked = true;
            }
            else CE_H_2.IsChecked = false;

            if (mem.Contains("CE_H_3_" + _CurrChar))
            {
                CE_H_3.IsChecked = true;
            }
            else CE_H_3.IsChecked = false;

            if (mem.Contains("CE_H_4_" + _CurrChar))
            {
                CE_H_4.IsChecked = true;
            }
            else CE_H_4.IsChecked = false;

            if (mem.Contains("CE_H_5_" + _CurrChar))
            {
                CE_H_5.IsChecked = true;
            }
            else CE_H_5.IsChecked = false;

            if (mem.Contains("CE_H_6_" + _CurrChar))
            {
                CE_H_6.IsChecked = true;
            }
            else CE_H_6.IsChecked = false;

            if (mem.Contains("CE_H_7_" + _CurrChar))
            {
                CE_H_7.IsChecked = true;
            }
            else CE_H_7.IsChecked = false;


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

            //(App.Current.RootVisual as PhoneApplicationFrame).Navigate(
            //                        new Uri("/MainPage.xaml", UriKind.Relative)); 
            //NavigationService.Navigate(new Uri("/Character.xaml", UriKind.Relative));

            //var previous = App.Current.RootVisual;
            App.Current.RootVisual = new Character();
            /*if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            */

        }

        //VOG NORMAL
        private void VOG_N_1_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("VOG_N_1_" + _CurrChar);
        }

        private void VOG_N_2_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("VOG_N_2_" + _CurrChar);
        }

        private void VOG_N_3_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("VOG_N_3_" + _CurrChar);
        }

        private void VOG_N_4_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("VOG_N_4_" + _CurrChar);
        }

        private void VOG_N_5_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("VOG_N_5_" + _CurrChar);
        }

        private void VOG_N_6_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("VOG_N_6_" + _CurrChar);
        }

        private void VOG_N_7_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("VOG_N_7_" + _CurrChar);
        }

        //VOG HARD
        private void VOG_H_1_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("VOG_H_1_" + _CurrChar);
        }

        private void VOG_H_2_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("VOG_H_2_" + _CurrChar);
        }

        private void VOG_H_3_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("VOG_H_3_" + _CurrChar);
        }

        private void VOG_H_4_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("VOG_H_4_" + _CurrChar);
        }

        private void VOG_H_5_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("VOG_H_5_" + _CurrChar);
        }

        private void VOG_H_6_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("VOG_H_6_" + _CurrChar);
        }

        private void VOG_H_7_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("VOG_H_7_" + _CurrChar);
        }

        //CE NORMAL
        private void CE_N_1_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("CE_N_1_" + _CurrChar);
        }

        private void CE_N_2_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("CE_N_2_" + _CurrChar);
        }

        private void CE_N_3_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("CE_N_3_" + _CurrChar);
        }

        private void CE_N_4_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("CE_N_4_" + _CurrChar);
        }

        private void CE_N_5_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("CE_N_5_" + _CurrChar);
        }

        private void CE_N_6_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("CE_N_6_" + _CurrChar);
        }

        private void CE_N_7_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("CE_N_7_" + _CurrChar);
        }

        //CE HARD
        private void CE_H_1_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("CE_H_1_" + _CurrChar);
        }

        private void CE_H_2_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("CE_H_2_" + _CurrChar);
        }

        private void CE_H_3_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("CE_H_3_" + _CurrChar);
        }

        private void CE_H_4_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("CE_H_4_" + _CurrChar);
        }

        private void CE_H_5_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("CE_H_5_" + _CurrChar);
        }

        private void CE_H_6_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("CE_H_6_" + _CurrChar);
        }

        private void CE_H_7_Unchecked(object sender, RoutedEventArgs e)
        {
            mem.Remove("CE_H_7_" + _CurrChar);
        }


        //VOG Normal
        private void VOG_N_1_Checked(object sender, RoutedEventArgs e)
        {
            if (!mem.Contains("VOG_N_1_" + _CurrChar))
            {
                mem.Add(("VOG_N_1_" + _CurrChar), "true");
            }
        }

        private void VOG_N_2_Checked(object sender, RoutedEventArgs e)
        {
            if (!mem.Contains("VOG_N_2_" + _CurrChar))
            {
                mem.Add(("VOG_N_2_" + _CurrChar), "true");
            }
        }

        private void VOG_N_3_Checked(object sender, RoutedEventArgs e)
        {
            if (!mem.Contains("VOG_N_3_" + _CurrChar))
            {
                mem.Add(("VOG_N_3_" + _CurrChar), "true");
            }
        }

        private void VOG_N_4_Checked(object sender, RoutedEventArgs e)
        {
            if (!mem.Contains("VOG_N_4_" + _CurrChar))
            {
                mem.Add(("VOG_N_4_" + _CurrChar), "true");
            }
        }

        private void VOG_N_5_Checked(object sender, RoutedEventArgs e)
        {
            if (!mem.Contains("VOG_N_5_" + _CurrChar))
            {
                mem.Add(("VOG_N_5_" + _CurrChar), "true");
            }
        }

        private void VOG_N_6_Checked(object sender, RoutedEventArgs e)
        {
            if (!mem.Contains("VOG_N_6_" + _CurrChar))
            {
                mem.Add(("VOG_N_6_" + _CurrChar), "true");
            }
        }

        private void VOG_N_7_Checked(object sender, RoutedEventArgs e)
        {
            if (!mem.Contains("VOG_N_7_" + _CurrChar))
            {
                mem.Add(("VOG_N_7_" + _CurrChar), "true");
            }
        }


        //VOG HARD
        private void VOG_H_1_Checked(object sender, RoutedEventArgs e)
        {
            VOG_N_1.IsChecked = true;

            if (!mem.Contains("VOG_H_1_" + _CurrChar))
            {
                mem.Add(("VOG_H_1_" + _CurrChar), "true");
            }
        }

        private void VOG_H_2_Checked(object sender, RoutedEventArgs e)
        {
            VOG_N_2.IsChecked = true;

            if (!mem.Contains("VOG_H_2_" + _CurrChar))
            {
                mem.Add(("VOG_H_2_" + _CurrChar), "true");
            }
        }

        private void VOG_H_3_Checked(object sender, RoutedEventArgs e)
        {
            VOG_N_3.IsChecked = true;

            if (!mem.Contains("VOG_H_3_" + _CurrChar))
            {
                mem.Add(("VOG_H_3_" + _CurrChar), "true");
            }
        }

        private void VOG_H_4_Checked(object sender, RoutedEventArgs e)
        {
            VOG_N_4.IsChecked = true;

            if (!mem.Contains("VOG_H_4_" + _CurrChar))
            {
                mem.Add(("VOG_H_4_" + _CurrChar), "true");
            }
        }

        private void VOG_H_5_Checked(object sender, RoutedEventArgs e)
        {
            VOG_N_5.IsChecked = true;

            if (!mem.Contains("VOG_H_5_" + _CurrChar))
            {
                mem.Add(("VOG_H_5_" + _CurrChar), "true");
            }
        }

        private void VOG_H_6_Checked(object sender, RoutedEventArgs e)
        {
            VOG_N_6.IsChecked = true;

            if (!mem.Contains("VOG_H_6_" + _CurrChar))
            {
                mem.Add(("VOG_H_6_" + _CurrChar), "true");
            }
        }

        private void VOG_H_7_Checked(object sender, RoutedEventArgs e)
        {
            VOG_N_7.IsChecked = true;

            if (!mem.Contains("VOG_H_7_" + _CurrChar))
            {
                mem.Add(("VOG_H_7_" + _CurrChar), "true");
            }
        }

        //CE Normal
        private void CE_N_1_Checked(object sender, RoutedEventArgs e)
        {
            if (!mem.Contains("CE_N_1_" + _CurrChar))
            {
                mem.Add(("CE_N_1_" + _CurrChar), "true");
            }
        }

        private void CE_N_2_Checked(object sender, RoutedEventArgs e)
        {
            if (!mem.Contains("CE_N_2_" + _CurrChar))
            {
                mem.Add(("CE_N_2_" + _CurrChar), "true");
            }
        }

        private void CE_N_3_Checked(object sender, RoutedEventArgs e)
        {
            if (!mem.Contains("CE_N_3_" + _CurrChar))
            {
                mem.Add(("CE_N_3_" + _CurrChar), "true");
            }
        }

        private void CE_N_4_Checked(object sender, RoutedEventArgs e)
        {
            if (!mem.Contains("CE_N_4_" + _CurrChar))
            {
                mem.Add(("CE_N_4_" + _CurrChar), "true");
            }
        }

        private void CE_N_5_Checked(object sender, RoutedEventArgs e)
        {
            if (!mem.Contains("CE_N_5_" + _CurrChar))
            {
                mem.Add(("CE_N_5_" + _CurrChar), "true");
            }
        }

        private void CE_N_6_Checked(object sender, RoutedEventArgs e)
        {
            if (!mem.Contains("CE_N_6_" + _CurrChar))
            {
                mem.Add(("CE_N_6_" + _CurrChar), "true");
            }
        }

        private void CE_N_7_Checked(object sender, RoutedEventArgs e)
        {
            if (!mem.Contains("CE_N_7_" + _CurrChar))
            {
                mem.Add(("CE_N_7_" + _CurrChar), "true");
            }
        }


        //CE HARD
        private void CE_H_1_Checked(object sender, RoutedEventArgs e)
        {
            CE_N_1.IsChecked = true;

            if (!mem.Contains("CE_H_1_" + _CurrChar))
            {
                mem.Add(("CE_H_1_" + _CurrChar), "true");
            }
        }

        private void CE_H_2_Checked(object sender, RoutedEventArgs e)
        {
            CE_N_2.IsChecked = true;

            if (!mem.Contains("CE_H_2_" + _CurrChar))
            {
                mem.Add(("CE_H_2_" + _CurrChar), "true");
            }
        }

        private void CE_H_3_Checked(object sender, RoutedEventArgs e)
        {
            CE_N_3.IsChecked = true;

            if (!mem.Contains("CE_H_3_" + _CurrChar))
            {
                mem.Add(("CE_H_3_" + _CurrChar), "true");
            }
        }

        private void CE_H_4_Checked(object sender, RoutedEventArgs e)
        {
            CE_N_4.IsChecked = true;

            if (!mem.Contains("CE_H_4_" + _CurrChar))
            {
                mem.Add(("CE_H_4_" + _CurrChar), "true");
            }
        }

        private void CE_H_5_Checked(object sender, RoutedEventArgs e)
        {
            CE_N_5.IsChecked = true;

            if (!mem.Contains("CE_H_5_" + _CurrChar))
            {
                mem.Add(("CE_H_5_" + _CurrChar), "true");
            }
        }

        private void CE_H_6_Checked(object sender, RoutedEventArgs e)
        {
            CE_N_6.IsChecked = true;

            if (!mem.Contains("CE_H_6_" + _CurrChar))
            {
                mem.Add(("CE_H_6_" + _CurrChar), "true");
            }
        }

        private void CE_H_7_Checked(object sender, RoutedEventArgs e)
        {
            CE_N_7.IsChecked = true;

            if (!mem.Contains("CE_H_7_" + _CurrChar))
            {
                mem.Add(("CE_H_7_" + _CurrChar), "true");
            }
        }

    }
}