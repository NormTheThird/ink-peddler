using System;
using System.Collections.Generic;
using System.IO;

namespace InkPeddler.Console.Services
{
    public class ZipCodeService
    {
        public ZipCodeService() { }

        public List<CityStateZipCodeModel> GetCityStateZipCodes()
        {
            var list = new List<CityStateZipCodeModel>();
            var path = "../../../files/us.txt";
            using (var streamReader = File.OpenText(path))
            {
                var lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    var columns = line.Split('\t');
                    list.Add(new CityStateZipCodeModel { City = columns[2], State = columns[3], ZipCode = columns[1] });
                }
                return list;
            }
        }

    }

    public class CityStateZipCodeModel
    {
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; } 
    }
}