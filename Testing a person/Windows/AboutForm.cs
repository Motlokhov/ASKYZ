using System;
using System.Windows.Forms;

namespace Testing_a_person
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            Show();
        }

        private void linkLabelMail_Click(object sender, EventArgs e)
        {
            LinkLabel label = sender as LinkLabel;
            Clipboard.SetText(label.Text);
        }
    }
}
