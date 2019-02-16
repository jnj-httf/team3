using Challenge1HackTeam3.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
                                 
            var ret = json.Records.Where(x => x!= null && 
                HttpUtility.UrlEncode(x.dsc_cidade.Trim().ToUpper(), Encoding.GetEncoding(28597)).Replace("+", " ") == HttpUtility.UrlEncode(cidade.Trim().ToUpper(), Encoding.GetEncoding(28597)).Replace("+", " ")).ToList();

            return ret;
        }


        public static IEnumerable<Record> GetUbsByLat(double lat, double lng)
        {
            System.Device.Location.GeoCoordinate _Coord = new System.Device.Location.GeoCoordinate(lat, lng);
            
            var cities = GetUbs();
            List<Record> lstRet = new List<Record>();
            cities.Records.ForEach(x =>
           {
               if (x != null)
               {
                   x.distance = (_Coord.GetDistanceTo(new System.Device.Location.GeoCoordinate(Convert.ToDouble(x.vlr_latitude.Replace(".",",")), Convert.ToDouble(x.vlr_longitude.Replace(".", ","))))/1000);
                   lstRet.Add(x);
               }
              
           });

            return lstRet.Where(x => x != null).ToList().OrderBy(x =>  x.distance).Take(10);
        }
        
    }
}