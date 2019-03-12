using System;
using System.Windows.Forms;

namespace DotnetWinform
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
