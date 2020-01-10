using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Summaries.codeResources
{
    public class functions
    {
        /// <summary>
        /// Uses BASE64 to hash the given string
        /// </summary>
        /// <param name="text">String to hash</param>
        /// <returns></returns>
        public string HashPW(string text)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Checks if it is possible to reach the specified link
        /// </summary>
        /// <param name="link">The link to the website or page</param>
        /// <returns></returns>
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
    }
}
