using System;
using System.Windows.Forms;

namespace StudentUI
{
    public partial class HowToWorkForm : AbstractForm
    {
        public Form test;

        public HowToWorkForm()
        {
            InitializeComponent();
            //textBox1.Focus();
        }

        private void ButtonOk_Click(object sender, EventArgs e) => Dispose();

        private void HowToWorkForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            test.Show();
        }
    }
}
