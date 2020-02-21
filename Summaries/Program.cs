using System;
using System.Threading;
using System.Windows.Forms;

namespace Summaries
{
    static class Program
    {
        static Mutex mutex = new Mutex(true,  "{10b59a53-ac2c-4bc5-ac42-96e5f7cdd920}");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if(mutex.WaitOne(TimeSpan.Zero, true))
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    new loading().Show();
                    Application.Run();
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            else
            {
                MessageBox.Show("Only one instance of this application can be running at a time!", "Multiple Instances", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
