using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Summaries.codeResources
{
    public class functions
    {
        public class simpleServerResponse
        {
            public bool status { get; set; }
            public string errors { get; set; }
        }

        /// <summary>
        /// Uses BASE64 to hash the given string
        /// </summary>
        /// <param name="text">String to hash</param>
        /// <returns>The string in BASE64</returns>
        public string Hash(string text)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Checks if it is possible to reach the specified link
        /// </summary>
        /// <param name="link">The link to the website or page</param>
        /// <returns>True if there is an internet connection</returns>
        public bool CheckForInternetConnection(string link)
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead(link))
                    return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Returns a 3-digit version-like string
        /// </summary>
        /// https://stackoverflow.com/questions/31863551/truncating-a-version-number-c-sharp
        /// <returns>3-digit version</returns>
        public string GetSoftwareVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location);
            String[] versionArray = fileVersion.ProductVersion.ToString().Split('.');
            return string.Join(".", versionArray.Take(3));
        }

        /// <summary>
        /// Calls the given function on the API with the provided POST data
        /// </summary>
        /// <param name="POSTdata">The Information required to send to the web server</param>
        /// <param name="operation">The operation (eg. "sumary/update")</param>
        /// <returns>Returns a JSON string with que server response</returns>
        public string APIRequest(string POSTdata, string operation)
        {
            List<String> GETendpoints = new List<string> {"login/logout", "user/list", "class/list", "workspace/list", "summary/list"};
            string finalData = "";
            try
            {
                if (GETendpoints.Contains(operation))
                {
                    WebRequest request = WebRequest.CreateHttp(Properties.Settings.Default.inUseDomain + "/summaries/api/" + GetSoftwareVersion() + "/" + operation + ".php?" + POSTdata);

                    request.Headers.Add("X-API-KEY", Properties.Settings.Default.AccessToken);

                    using(WebResponse response = (WebResponse)request.GetResponse())
                    using(Stream stream = response.GetResponseStream())
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
                else
                {
                    var data = Encoding.UTF8.GetBytes(POSTdata);
                    var request = WebRequest.CreateHttp(Properties.Settings.Default.inUseDomain + "/summaries/api/" + GetSoftwareVersion() + "/" + operation + ".php");
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;
                    request.UserAgent = "app";
                    request.Headers.Add("X-API-KEY", Properties.Settings.Default.AccessToken);
                    //writes the post data to the stream
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                        stream.Close();
                    }
                    //ler a resposta
                    using (var response = request.GetResponse())
                    {
                        var dataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(dataStream);
                        finalData = reader.ReadToEnd();
                        dataStream.Close();
                        response.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                if (CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
                {
                    finalData = "{\"status\":\"false\", \"errors\":\"" + ex.Message + "\n" + operation + "\"}";  
                }else{
                    finalData = "{\"status\":\"false\", \"errors\":\"Lost Connection to the Server\"}";
                }
            }
            return finalData;
        }
    }
}
