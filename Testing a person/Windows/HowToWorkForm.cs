using System;
using System.Windows.Forms;

namespace Testing_a_person
{
    public partial class HowToWorkForm : AbstractForm
    {
        public Form test;

        public HowToWorkForm()
        {
            InitializeComponent();
            //textBox1.Focus();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void HowToWorkForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            test.Show();
        }
    }
}
