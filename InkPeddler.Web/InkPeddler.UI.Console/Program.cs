using System;

namespace InkPeddler.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
        }

        //private static void LoadBusinesses()
        //{
        //    System.Console.WriteLine("Getting tattoo shops ...");
        //    var listOfStates = GetListOfStates();
        //    var businesses = CreateBusinessModelList(listOfStates);
        //    SaveBusinesses(businesses);
        //    System.Console.ReadKey();
        //}

        //private static BusinessModel ConvertNodeToBusinessModel(XmlNode node)
        //{
        //    try
        //    {
        //        var latitude = Convert.ToDecimal(node["geometry"]["location"]["lat"].InnerText);
        //        var longitude = Convert.ToDecimal(node["geometry"]["location"]["lng"].InnerText);
        //        var address = ParseAddress(latitude.ToString(), longitude.ToString());

        //        var now = DateTime.Now;
        //        return new BusinessModel
        //        {
        //            Id = Guid.NewGuid(),
        //            AWSProfileImageId = null,
        //            Name = node["name"].InnerText,
        //            GoogleMapId = node["id"].InnerText,
        //            GoogleMapPlaceId = node["place_id"].InnerText,
        //            FacebookUrl = "",
        //            WebsiteUrl = "",
        //            InstagramUrl = "",
        //            TwitterUrl = "",
        //            PhoneNumber = "",
        //            Address = new AddressModel
        //            {
        //                Id = Guid.NewGuid(),
        //                Address1 = address.Address,
        //                Address2 = "",
        //                City = address.City,
        //                State = address.State,
        //                Latitude = latitude,
        //                Longitude = longitude,
        //                ZipCode = address.Zip,
        //                DateCreated = now
        //            },
        //            DateCreated = now,
        //            IsActive = true,
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        System.Console.WriteLine(e);
        //        throw;
        //    }

        //}

        //private static XmlDocument GetTattooShopsForState(string search, string nextPageToken)
        //{
        //    try
        //    {
        //        var xmlDocument = new XmlDocument();
        //        var url = @"https://maps.googleapis.com/maps/api/place/textsearch/xml?query=tattoo+" + search + "&key=AIzaSyAAXcppFi9H2VWTMvcxIHtqVkz_Dt2bssI";
        //        if (!nextPageToken.Equals("START"))
        //            url += "&pagetoken=" + nextPageToken;

        //        var request = WebRequest.Create(url);
        //        using (var response = request.GetResponse())
        //        {
        //            using (var stream = response.GetResponseStream())
        //            {
        //                xmlDocument.Load(stream);
        //                return xmlDocument;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Console.WriteLine(ex);
        //        return null;
        //    }
        //}

        //private static AddressData ParseAddress(string lat, string lng)
        //{
        //    var addressShortName = string.Empty;
        //    var addressCountry = string.Empty;
        //    var addressAdministrativeAreaLevel1 = string.Empty;
        //    var addressAdministrativeAreaLevel2 = string.Empty;
        //    var addressAdministrativeAreaLevel3 = string.Empty;
        //    var addressColloquialArea = string.Empty;
        //    var addressLocality = string.Empty;
        //    var addressSublocality = string.Empty;
        //    var addressNeighborhood = string.Empty;
        //    var addressRoute = string.Empty;
        //    var addressStreetNumber = string.Empty;
        //    var addressPostalCode = string.Empty;

        //    XmlDocument doc = new XmlDocument();
        //    var url = @"https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + lat + "," + lng + "&sensor=false&key=AIzaSyAAXcppFi9H2VWTMvcxIHtqVkz_Dt2bssI";
        //    var request = WebRequest.Create(url);
        //    using (var response = request.GetResponse())
        //    {
        //        using (var stream = response.GetResponseStream())
        //        {
        //            doc.Load(stream);
        //        }
        //    }

        //    var element = doc.SelectSingleNode("//GeocodeResponse/status");
        //    if (element == null || element.InnerText == Constants.ApiResponses.ZeroResults)
        //    {
        //        return null;
        //    }

        //    XmlNodeList xnList = doc.SelectNodes("//GeocodeResponse/result/address_component");

        //    if (xnList == null) return null;

        //    foreach (XmlNode xn in xnList)
        //    {
        //        var longname = xn["long_name"].InnerText;
        //        var shortname = xn["short_name"].InnerText;
        //        var typename = xn["type"]?.InnerText;

        //        switch (typename)
        //        {
        //            case "country":
        //                addressCountry = longname;
        //                addressShortName = shortname;
        //                break;
        //            case "locality":
        //                addressLocality = longname;
        //                break;
        //            case "sublocality":
        //                addressSublocality = longname;
        //                break;
        //            case "neighborhood":
        //                addressNeighborhood = longname;
        //                break;
        //            case "colloquial_area":
        //                addressColloquialArea = longname;
        //                break;
        //            case "administrative_area_level_1":
        //                addressAdministrativeAreaLevel1 = shortname;
        //                break;
        //            case "administrative_area_level_2":
        //                addressAdministrativeAreaLevel2 = longname;
        //                break;
        //            case "administrative_area_level_3":
        //                addressAdministrativeAreaLevel3 = longname;
        //                break;
        //            case "route":
        //                addressRoute = shortname;
        //                break;
        //            case "street_number":
        //                addressStreetNumber = shortname;
        //                break;
        //            case "postal_code":
        //                addressPostalCode = longname;
        //                break;
        //        }
        //    }

        //    return new AddressData
        //    {
        //        Country = addressCountry,
        //        State = addressAdministrativeAreaLevel1,
        //        City = addressLocality,
        //        Address = addressStreetNumber + " " + addressRoute + " " + addressSublocality,
        //        Zip = addressPostalCode,
        //    };
        //}

        //private static void SaveBusinesses(List<BusinessModel> businesses)
        //{
        //    int count = 0;
        //    System.Console.Write("Saveing Businesses ");
        //    using (var progress = new ProgressBar())
        //    {
        //        foreach (var newBusiness in businesses)
        //        {
        //            DbInterception.Add(new TemporalTableCommandTreeInterceptor());
        //            using (var context = new InkPeddlerEntities())
        //            {
        //                var business = context.Businesses.FirstOrDefault(b => b.GoogleMapId.Equals(newBusiness.GoogleMapId, StringComparison.CurrentCultureIgnoreCase));
        //                if (business == null)
        //                {
        //                    business = new Business { Id = Guid.NewGuid(), GoogleMapId = newBusiness.GoogleMapId, DateCreated = newBusiness.DateCreated };
        //                    business.Address = new Address { Id = Guid.NewGuid(), DateCreated = newBusiness.DateCreated };
        //                    context.Businesses.Add(business);
        //                }

        //                business.AWSProfileImageId = newBusiness.AWSProfileImageId;
        //                business.Name = newBusiness.Name;
        //                business.GoogleMapPlaceId = newBusiness.GoogleMapPlaceId;
        //                business.PhoneNumber = newBusiness.PhoneNumber;
        //                business.WebsiteUrl = newBusiness.WebsiteUrl;
        //                business.FacebookUrl = newBusiness.FacebookUrl;
        //                business.TwitterUrl = newBusiness.TwitterUrl;
        //                business.InstagramUrl = newBusiness.InstagramUrl;
        //                business.IsActive = newBusiness.IsActive;

        //                business.Address.Address1 = newBusiness.Address.Address1;
        //                business.Address.Address2 = newBusiness.Address.Address2;
        //                business.Address.City = newBusiness.Address.City;
        //                business.Address.State = newBusiness.Address.State;
        //                business.Address.ZipCode = newBusiness.Address.ZipCode;
        //                business.Address.Latitude = newBusiness.Address.Latitude;
        //                business.Address.Longitude = newBusiness.Address.Longitude;

        //                context.SaveChanges();
        //                count++;
        //                progress.Report((double)count / businesses.Count);
        //            }
        //        }
        //    }
        //}

        //private static List<string> GetListOfStates()
        //{
        //    var list = new List<string>();
        //    //listOfStates.Add("South Dakota");
        //    list.Add("Iowa");
        //    list.Add("North Dakota");
        //    list.Add("Nebraska");
        //    list.Add("Minnesota");
        //    list.Add("Kansas");
        //    return list;
        //}

        //private static List<BusinessModel> CreateBusinessModelList(List<string> states)
        //{
        //    var cityStateZipCodes = new ZipCodeService().GetCityStateZipCodes();
        //    var businesses = new List<BusinessModel>();
        //    foreach (var state in states)
        //    {

        //        var codes = cityStateZipCodes.Where(m => m.State.Equals(state, StringComparison.CurrentCultureIgnoreCase)).ToList();
        //        int count = 0;
        //        System.Console.Write(state + " ");
        //        using (var progress = new ProgressBar())
        //        {
        //            foreach (var code in codes)
        //            {
        //                var nextPageToken = "START";
        //                progress.Report((double)count / codes.Count);
        //                while (!string.IsNullOrEmpty(nextPageToken))
        //                {
        //                    var data = GetTattooShopsForState(code.City + " " + code.State, nextPageToken);
        //                    nextPageToken = "";
        //                    foreach (XmlNode node in data.DocumentElement.ChildNodes)
        //                    {
        //                        if (node.Name.Equals("next_page_token", StringComparison.CurrentCultureIgnoreCase))
        //                            nextPageToken = node.InnerText;

        //                        if (node.Name.Equals("result", StringComparison.CurrentCultureIgnoreCase))
        //                        {
        //                            var exists = businesses.Any(b => b.GoogleMapId.Equals(node["id"].InnerText, StringComparison.CurrentCultureIgnoreCase));
        //                            if (!exists)
        //                            {
        //                                count++;
        //                                var model = ConvertNodeToBusinessModel(node);
        //                                if (model != null)
        //                                    businesses.Add(model);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        System.Console.Write(" : Completed with " + count + " records.");
        //        System.Console.WriteLine();
        //    }

        //    return businesses;
        //}

        //private static void AzureSearch()
        //{
        //    try
        //    {
        //        var urlCalls = 0;
        //        var states = GetStates();
        //        foreach (var state in GetStates())
        //        {
        //            System.Console.WriteLine($"Getting shops for {state.Name} :: {state.ShortName}");
        //            var offset = 0;
        //            var count = 0;
        //            var total = 1;
        //            while (offset < total)
        //            {
        //                var url = $"https://atlas.microsoft.com/search/fuzzy/json?api-version=1.0&subscription-key=FoV18dkq6rob_Mb-5iZsDWOhcaQVWGJtp18zwOxLGcg&query=Tattoo {state.Name}&radius=20&limit=100&ofs={offset}";
        //                var webRequest = WebRequest.Create(url);
        //                using (var response = webRequest.GetResponse())
        //                {
        //                    using (var reader = new StreamReader(response.GetResponseStream()))
        //                    {
        //                        urlCalls++;
        //                        var data = JObject.Parse(reader.ReadToEnd());
        //                        total = Convert.ToInt32(data["summary"]["totalResults"]);
        //                        foreach (var result in data["results"].ToList())
        //                        {
        //                            if (result["address"]["countrySubdivision"] == null)
        //                                continue;

        //                            var stateAbr = result["address"]["countrySubdivision"].ToString();
        //                            if (!stateAbr.Equals(state.ShortName, StringComparison.CurrentCultureIgnoreCase))
        //                                continue;

        //                            var type = result["type"].ToString();
        //                            if (!type.ToUpper().Equals("POI"))
        //                                continue;

        //                            var businessModel = ConvertJSONToBusinessModel(result);
        //                            if (businessModel == null)
        //                                continue;

        //                            count++;
        //                            SaveBusiness(businessModel);
        //                            if (count != 0 && count % 100 == 0)
        //                                System.Console.WriteLine($"Total Calls {urlCalls} : {state.Name} : {count} records have been imported");
        //                        }

        //                        if (offset + 100 < total)
        //                            offset += 100;
        //                        else offset = total;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Console.WriteLine($"Error: {ex.Message}");
        //    }
        //    finally
        //    {
        //        System.Console.WriteLine("Completed");
        //        System.Console.ReadKey();
        //    }
        //}

        //private static void SaveBusiness(BusinessModel businessModel)
        //{
        //    try
        //    {
        //        DbInterception.Add(new TemporalTableCommandTreeInterceptor());
        //        using (var context = new InkPeddlerEntities())
        //        {
        //            var business = context.Businesses.FirstOrDefault(b => b.Name.Equals(businessModel.Name, StringComparison.CurrentCultureIgnoreCase) &&
        //                                                                  b.Address.City.Equals(businessModel.Address.City, StringComparison.CurrentCultureIgnoreCase));

        //            if (business != null)
        //            {
        //                if (string.IsNullOrEmpty(business.GoogleMapId))
        //                    business = context.Businesses.FirstOrDefault(b => b.AzureMapsSearchType.Equals(businessModel.AzureMapsSearchType, StringComparison.CurrentCultureIgnoreCase) &&
        //                                                                      b.AzureMapsSearchId.Equals(businessModel.AzureMapsSearchId, StringComparison.CurrentCultureIgnoreCase));

        //            }

        //            if (business == null)
        //            {
        //                business = new Business
        //                {
        //                    Id = Guid.NewGuid(),
        //                    GoogleMapId = "",
        //                    GoogleMapPlaceId = "",
        //                    AzureMapsSearchType = businessModel.AzureMapsSearchType,
        //                    AzureMapsSearchId = businessModel.AzureMapsSearchId,
        //                    DateCreated = businessModel.DateCreated
        //                };
        //                business.Address = new Address { Id = Guid.NewGuid(), DateCreated = businessModel.DateCreated };
        //                context.Businesses.Add(business);
        //            }

        //            business.AWSProfileImageId = businessModel.AWSProfileImageId;
        //            business.Name = businessModel.Name;
        //            business.RegistrationCode = "";
        //            business.AzureMapsSearchType = businessModel.AzureMapsSearchType;
        //            business.AzureMapsSearchId = businessModel.AzureMapsSearchId;
        //            business.PhoneNumber = businessModel.PhoneNumber;
        //            business.WebsiteUrl = businessModel.WebsiteUrl;
        //            business.FacebookUrl = businessModel.FacebookUrl;
        //            business.TwitterUrl = businessModel.TwitterUrl;
        //            business.InstagramUrl = businessModel.InstagramUrl;
        //            business.IsActive = businessModel.IsActive;
        //            business.ValidatedBy = "";

        //            business.Address.Address1 = businessModel.Address.Address1;
        //            business.Address.Address2 = businessModel.Address.Address2;
        //            business.Address.City = businessModel.Address.City;
        //            business.Address.State = businessModel.Address.State;
        //            business.Address.ZipCode = businessModel.Address.ZipCode;
        //            business.Address.Latitude = businessModel.Address.Latitude;
        //            business.Address.Longitude = businessModel.Address.Longitude;

        //            context.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Console.WriteLine(ex);
        //    }

        //}

        //private static BusinessModel ConvertJSONToBusinessModel(JToken result)
        //{
        //    try
        //    {
        //        var name = "";
        //        if (result["poi"]["name"] != null)
        //            name = result["poi"]["name"].ToString();

        //        var url = "";
        //        if (result["poi"]["url"] != null)
        //            url = result["poi"]["url"].ToString();

        //        var phone = "";
        //        if (result["poi"]["phone"] != null)
        //            phone = result["poi"]["phone"].ToString().Replace("+(1)", "").Replace("(", "").Replace(")", "").Replace("-", "");

        //        var id = result["id"].ToString();
        //        var newId = id.Remove(0, id.IndexOf('/', 8) + 1);

        //        var now = DateTime.Now;
        //        return new BusinessModel
        //        {
        //            Id = Guid.NewGuid(),
        //            AWSProfileImageId = null,
        //            Name = name,
        //            GoogleMapId = "",
        //            GoogleMapPlaceId = "",
        //            AzureMapsSearchType = result["type"].ToString(),
        //            AzureMapsSearchId = newId,
        //            FacebookUrl = "",
        //            WebsiteUrl = url,
        //            InstagramUrl = "",
        //            TwitterUrl = "",
        //            PhoneNumber = phone,
        //            Address = new AddressModel
        //            {
        //                Id = Guid.NewGuid(),
        //                Address1 = $"{result["address"]["streetNumber"]} {result["address"]["streetName"]}",
        //                Address2 = "",
        //                City = result["address"]["municipality"].ToString(),
        //                State = result["address"]["countrySubdivisionName"].ToString(),
        //                Latitude = Convert.ToDecimal(result["position"]["lat"]),
        //                Longitude = Convert.ToDecimal(result["position"]["lon"]),
        //                ZipCode = result["address"]["postalCode"].ToString().PadLeft(5, '0'),
        //                DateCreated = now
        //            },
        //            DateCreated = now,
        //            IsActive = true,
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Console.WriteLine(ex);
        //        return null;
        //    }

        //}

        //private static List<(int ZipCode, string State)> GetZipcodes()
        //{
        //    System.Console.WriteLine("Getting all zip codes");
        //    var zipcodes = new List<(int, string)>();
        //    var filePath = @"C:\Users\Development\Desktop\zipcodes.csv";
        //    using (var csvParser = new TextFieldParser(filePath))
        //    {
        //        csvParser.CommentTokens = new string[] { "#" };
        //        csvParser.SetDelimiters(new string[] { "," });
        //        csvParser.HasFieldsEnclosedInQuotes = true;

        //        // Skip the row with the column names
        //        csvParser.ReadLine();
        //        var states = GetStates();
        //        while (!csvParser.EndOfData)
        //        {
        //            // Read current line fields, pointer moves to the next line.
        //            string[] fields = csvParser.ReadFields();
        //            var zipcode = Convert.ToInt32(fields[1]);
        //            var state = fields[4];

        //            if (!states.Any(s => s.ShortName == state.ToUpper()))
        //                continue;

        //            if (!zipcodes.Any(z => z.Item1 == zipcode))
        //                zipcodes.Add((zipcode, state));
        //        }
        //    }

        //    return zipcodes;
        //}

        //private static List<(string Name, string ShortName)> GetStates()
        //{
        //    return new List<(string, string)>
        //    {
        //        ("Alabama", "AL"),
        //        ("Alaska", "AK"),
        //        ("Arizona", "AZ"),
        //        ("Arkansas", "AR"),
        //        ("California", "CA"),
        //        ("Colorado", "CO"),
        //        ("Connecticut", "CT"),
        //        ("Delaware", "DE"),
        //        ("District of Columbia", "DC"),
        //        ("Florida", "FL"),
        //        ("Georgia", "GA"),
        //        ("Hawaii", "HI"),
        //        ("Idaho", "ID"),
        //        ("Illinois", "IL"),
        //        ("Indiana", "IN"),
        //        ("Iowa", "IA"),
        //        ("Kansas", "KS"),
        //        ("Kentucky", "KY"),
        //        ("Louisiana", "LA"),
        //        ("Maine", "ME"),
        //        ("Maryland", "MD"),
        //        ("Massachusetts", "MA"),
        //        ("Michigan", "MI"),
        //        ("Minnesota", "MN"),
        //        ("Mississippi", "MS"),
        //        ("Missouri", "MO"),
        //        ("Montana", "MT"),
        //        ("Nebraska", "NE"),
        //        ("Nevada", "NV"),
        //        ("New Hampshire", "NH"),
        //        ("New Jersey", "NJ"),
        //        ("New Mexico", "NM"),
        //        ("New York", "NY"),
        //        ("North Carolina", "NC"),
        //        ("North Dakota", "ND"),
        //        ("Ohio", "OH"),
        //        ("Oklahoma", "OK"),
        //        ("Oregon", "OR"),
        //        ("Pennsylvania", "PA"),
        //        ("Rhode Island", "RI"),
        //        ("South Carolina", "SC"),
        //        ("South Dakota", "SD"),
        //        ("Tennessee", "TN"),
        //        ("Texas", "TX"),
        //        ("Utah", "UT"),
        //        ("Vermont", "VT"),
        //        ("Virginia", "VA"),
        //        ("Washington", "WA"),
        //        ("West Virginia", "WV"),
        //        ("Wisconsin", "WI"),
        //        ("Wyoming", "WY")
        //    };
        //}
    }
}
