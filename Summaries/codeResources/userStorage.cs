namespace Summaries
{
    public class userStorage
    {
        public static int userID;
        public static string username;
        //public static string Class;
        public static string displayName;
        public static bool adminControl;
        public static string inUseDomain;

    }

    public class simpleServerResponse
    {
        public bool status { get; set; }
        public string errors { get; set; }
    }
}
