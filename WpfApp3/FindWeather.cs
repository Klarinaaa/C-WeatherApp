using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace WpfApp3
{
    class FindWeather
    {
        private const string apiWKey = "" // Place Weather Unlock Api Key Here;
        private const string reqWUrl = "http://api.weatherunlocked.com/api/current/";

        private const string apiGKey = "" //Place Google API Key Here;

        // NOTE: Without these keys the program will be unable to function

        public static string[] getCords(string location)
        {
            var reqGUrl = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address=" + location + apiGKey);
            string[] returnvalue = new string[2];
            WebRequest request = WebRequest.Create(reqGUrl);
            WebResponse response = request.GetResponse();
            XDocument data = XDocument.Load(response.GetResponseStream());

            XElement result = data.Element("GeocodeResponse").Element("result");
            XElement locationElement = result.Element("geometry").Element("location");
            XElement latE = locationElement.Element("lat");
            XElement lngE = locationElement.Element("lng");

            int indexLat = latE.ToString().Remove(0, 5).IndexOf("<");
            int indexLng = lngE.ToString().Remove(0, 5).IndexOf("<");

            if (indexLat  > 0 )
            {
                returnvalue[0] = latE.ToString().Remove(0, 5).Substring(0, indexLat);
                Console.WriteLine(returnvalue[0]);
            }
            if (indexLng > 0)
            {
                returnvalue[1] = lngE.ToString().Remove(0, 5).Substring(0, indexLng);
                Console.WriteLine(returnvalue[1]);
            }
            response.Close();

            return returnvalue;
        }

        public static string[] getWeather(string location)
        {
            string[] returnWeather = new string[4];
            string[] cords = getCords(location);
            var reqWFinalUrl = reqWUrl + cords[0] + "," + cords[1] + apiWKey;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(reqWFinalUrl);
            request.Accept = "application/xml";
            Console.WriteLine(reqWFinalUrl);
            WebResponse response = request.GetResponse();
            XDocument data = XDocument.Load(response.GetResponseStream());
            XElement temp = data.Element("CurrentWeather").Element("temperature_c");
            XElement humidity = data.Element("CurrentWeather").Element("humidity");
            XElement desc = data.Element("CurrentWeather").Element("weather_description");

            int indexTemp = temp.ToString().Remove(0, 15).IndexOf('<');
            int indexHumid = humidity.ToString().Remove(0, 10).IndexOf('<');
            int indexDesc = desc.ToString().Remove(0, 21).IndexOf('<');

            if (indexTemp > 0)
            {
                returnWeather[0] = temp.ToString().Remove(0, 15).Substring(0, indexTemp);
            }
            if (indexHumid > 0)
            {
                returnWeather[1] = humidity.ToString().Remove(0, 10).Substring(0, indexHumid);
            }
            if (indexDesc > 0)
            {
                returnWeather[2] = desc.ToString().Remove(0, 21).Substring(0, indexDesc);
            }

            return returnWeather;
        }
    }
}


