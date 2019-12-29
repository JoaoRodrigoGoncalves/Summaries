using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summaries
{
    /// <summary>
    /// Stores the user information sent by the server
    /// </summary>
    public class UserSession
    {
        public int userID { get; set; }
        public string user { get; set; }
        public string displayName { get; set; }
    }
}
