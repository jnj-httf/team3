using Challenge1HackTeam3.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace Challenge1HackTeam3.Services
{
    public class UbsAPI
    {

        public static ResponseDTO GetUbs()
        {
            ResponseDTO pages = new ResponseDTO();

            if (File.Exists(@"c:\temp\baseUBS.jj"))
            {
                StreamReader sr = new StreamReader(@"c:\temp\baseUBS.jj");
                var jsonFile = sr.ReadToEnd();
                pages = JsonConvert.DeserializeObject<ResponseDTO>(jsonFile);
                sr.Close();
            }
            else
            {
                pages = GetPage(1);

                var totalPages = pages._MetaData.page.Split('/');
                List<int> lstCount = new List<int>();

                for (int i = 1; i < Convert.ToInt32(totalPages[1].Trim()); i++)
                    lstCount.Add(i);

                lstCount.AsParallel().ForAll(x =>
                {
                    ResponseDTO page = GetPage(x);
                    pages.Records.AddRange(page.Records);
                });

                StreamWriter sw = new StreamWriter(@"c:\temp\baseUBS.jj");
                sw.WriteLine(JsonConvert.SerializeObject(pages));
                sw.Close();
            }

            return pages;
        }

        private static ResponseDTO GetPage(int page)
        {
            var client = new RestClient("https://api-ldc-hackathon.herokuapp.com/api/");
            var request = new RestRequest("ubs/" + page.ToString() , Method.GET);

            //adicionar o tipo no execute
            IRestResponse response = client.Execute<ResponseDTO>(request);
            var cont = response.Content;
            return JsonConvert.DeserializeObject<ResponseDTO>(cont);
        }
        
        public static List<Record> getUbsByCity(string cidade)
        {
            ResponseDTO json = GetUbs();
            var ret = json.Records.Where(x => x!= null && x.dsc_cidade.Trim().ToUpper() == cidade.Trim().ToUpper()).ToList();

            return ret;
        }


        public static IEnumerable<Record> GetUbsByLat(double lat, double lng)
        {
            var cities = GetUbs();
            cities.Records.ForEach(x =>
           {
               double R = 6371e3;
               var dlat = Convert.ToDouble(x.vlr_latitude) - lat;
               var dlon = Convert.ToDouble(x.vlr_longitude) - lng;

               var q = Math.Pow(Math.Sin(dlat), 2) + Math.Cos(lat) * Math.Cos(Convert.ToDouble(x.vlr_latitude)) * Math.Pow(Math.Sin(dlon), 2);
               var c = 2 * Math.Atan2(Math.Sqrt(q), Math.Sqrt(1 - q));

               var d = c * R;
               var distance = d / 1000;

               x.distance = distance;

           });

            return cities.Records.OrderBy(x => x.distance).Take(10);
        }


    }
}