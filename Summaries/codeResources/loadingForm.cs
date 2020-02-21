using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Summaries.codeResources
{
    public partial class loadingForm : Form
    {
        //https://www.youtube.com/watch?v=yZYAaScEsc0

        public Action Worker { get; set; }

        public loadingForm(Action worker)
        {
            InitializeComponent();
            if(worker == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                Worker = worker;
            }
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

    }
}
