using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO.IsolatedStorage;

namespace TestingDestinyAPI
{
    class getCharacter
    {

        string _MemID;
        string _UserID;
        string _ConsoleID;
        string _GrimoireScore;
        string _ClanTag;
        string _ClanName;
        string _Char1LVL;
        string _Char2LVL;
        string _Char3LVL;

        public void Download()
        {
            
        //Get previous information
        IsolatedStorageSettings fetch = IsolatedStorageSettings.ApplicationSettings;

            if (fetch.Contains("membershipId"))
            {
                _MemID = fetch["membershipId"].ToString();
            }

            if (fetch.Contains("userId")) 
            {
                _UserID = fetch["userId"].ToString();
            }

            if (fetch.Contains("consoleId"))
            {
                _ConsoleID = fetch["consoleId"].ToString();
            }

           string url = "http://www.bungie.net/Platform/Destiny/" + _ConsoleID +"/Account/" + _MemID +"/"; 


            var client = new WebClient();
            Uri uri = new Uri(url);
            var API_CODE = new API_KEY();

            String CODE = API_CODE.getCode;
             
            client.Headers["X-API-Key"] = CODE;

            
            client.DownloadStringCompleted += (sender, e) =>
            {
                saveData(e.Result);
                this.Navi();
                
            };
            client.DownloadStringAsync(uri);
          
        }


        public void saveData(string input)
        {

            JObject data = JObject.Parse(input);
            //Hard code way to parse through the "layers" in the json object
            JToken intoResponse = data.First.First.First.First;
            //Search JSON object to find membershipId
            _GrimoireScore = intoResponse["grimoireScore"].ToString();
           
            //Some people might not be in a clan.
      
            //_ClanTag = intoResponse["clanTag"].ToString();
          
            //_ClanName = intoResponse["clanName"].ToString();


            /*
            JToken further = data.First.First.First.First;
            JToken deep = further["characters"].ToString();
            //deep = deep["characterBase"].ToString();
            deep = deep["characterLevel"].ToString();
            _Char2LVL = further["1"]["characterLevel"].ToString();
            _Char3LVL = further["2"]["characterLevel"].ToString();
            */

            //save the membershipId to memory
            IsolatedStorageSettings save = IsolatedStorageSettings.ApplicationSettings;

            //GrimoireScore
            if (!save.Contains("grimoireScore"))
            {
                save.Add("grimoireScore", _GrimoireScore);
            }
            else
            {
                save.Remove("grimoireScore");
                save.Add("grimoireScore", _GrimoireScore);
            }

            //ClanName
            if (!save.Contains("clanName"))
            {
                save.Add("clanName", _ClanName);
            }
            else
            {
                save.Remove("clanName");
                save.Add("clanName", _ClanName);
            }

            //ClanTag
            if (!save.Contains("clanTag"))
            {
                save.Add("clanTag", _ClanTag);
            }
            else
            {
                save.Remove("clanTag");
                save.Add("clanTag", _ClanTag);
            }

            save.Save();
        }


        public void Navi()
        {
            //Going to the Character page
            App.Current.RootVisual = new Character();
        }

    }
}
