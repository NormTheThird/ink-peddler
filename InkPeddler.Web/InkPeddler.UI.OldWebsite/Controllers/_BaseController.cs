using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace InkPeddler.UI.Website.Controllers
{
    public class _BaseController : Controller
    {
        internal static T ServiceGet<T, U>(string _controller, U _request) where T : new()
        {
            try
            {
                var response = new T();
                var serviceUrl = ConfigurationManager.AppSettings["ServiceUrl"] + _controller;
                if (string.IsNullOrEmpty(serviceUrl)) throw new Exception("Service url is null or empty.");
                var url = serviceUrl + "?" + BuildParameterString(_request);

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
                request.Method = "Get";
                using (HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse())
                {
                    var dataStream = httpWebResponse.GetResponseStream();
                    var reader = new StreamReader(dataStream);
                    response = new JavaScriptSerializer().Deserialize<T>(reader.ReadToEnd());
                    reader.Close();
                    dataStream.Close();
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal static T ServicePost<T, U>(string _controller, U _request) where T : new()
        {
            try
            {
                var response = new T();
                var serviceUrl = ConfigurationManager.AppSettings["ServiceUrl"] + _controller;
                if (string.IsNullOrEmpty(serviceUrl)) throw new Exception("Service url is null or empty.");
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(serviceUrl));
                request.Method = "Post";
                request.AllowAutoRedirect = true;
                request.ContentType = "application/x-www-form-urlencoded";
                Stream datastream;
                var parameters = BuildParameterString(_request);
                if (!string.IsNullOrEmpty(parameters))
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(parameters);
                    datastream = request.GetRequestStream();
                    datastream.Write(byteArray, 0, byteArray.Length);
                    datastream.Close();
                }



                using (HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse())
                {
                    var dataStream = httpWebResponse.GetResponseStream();
                    var reader = new StreamReader(dataStream);
                    response = new JavaScriptSerializer().Deserialize<T>(reader.ReadToEnd());
                    reader.Close();
                    dataStream.Close();
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Converts the generic object into a url paramerte string
        /// </summary>
        /// <typeparam name="T">The type of object to convert</typeparam>
        /// <param name="_object">The object to convert</param>
        /// <returns></returns>
        private static string BuildParameterString<T>(T _object)
        {
            try
            {
                var result = "";
                var type = _object.GetType();
                var properties = type.GetProperties();
                foreach (var property in properties)
                {
                    var value = property.GetValue(_object, null);
                    if (value != null)
                    {
                        var strValue = Convert.ToString(value);
                        if (!string.IsNullOrEmpty(strValue))
                        {
                            if (property.Name.Equals("Email") || property.Name.Equals("Password") || property.Name.Equals("Login") || property.Name.Equals("Username")) 
                                result += property.Name + "=" + Common.Helpers.Security.EncryptString(strValue) + "&";
                            else result += property.Name + "=" + strValue + "&";
                        }
                    }
                }
                return result.Trim('&');
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}