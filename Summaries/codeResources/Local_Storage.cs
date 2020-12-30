namespace Summaries.codeResources
{
    class Local_Storage
    {
        private static Local_Storage singleton;

        private static readonly object padlock = new object();

        public static Local_Storage Retrieve
        {
            get
            {
                lock (padlock)
                {
                    if(singleton == null)
                    {
                        singleton = new Local_Storage();
                    }
                    return singleton;
                }
            }
        }

        //******* Fields **********//


        public string inUseDomain;
        public string username;
        public string displayName;
        public string userImageLocation;
        public int userID = 0;
        public bool isAdmin = false;
        public string AccessToken;
        public int currentWorkspaceID = 0;

        public bool typeTestSuccessfull = false;
    }
}
