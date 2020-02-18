using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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
        /// Calls the given function on the API with the provided POST data
        /// </summary>
        /// <param name="POSTdata">The Information required to send to the web server</param>
        /// <param name="APIFile">The API File on the web server to get the info from</param>
        /// <returns>Returns a JSON string with que server response</returns>
        public string APIRequest(string POSTdata, string APIFile)
        {
            string finalData = "";
            try
            {
                var data = Encoding.UTF8.GetBytes(POSTdata);
                var request = WebRequest.CreateHttp(Properties.Settings.Default.inUseDomain + "/summaries/api/" + APIFile);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = "app";
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
            catch(Exception ex)
            {
                if (CheckForInternetConnection(Properties.Settings.Default.inUseDomain))
                {
                    finalData = "{\"status\":\"false\", \"errors\":\"" + ex.Message + "\"}";  
                }else{
                    finalData = "{\"status\":\"false\", \"errors\":\"Lost Connection to the Server\"}";
                }
            }
            return finalData;
        }
    }
}
