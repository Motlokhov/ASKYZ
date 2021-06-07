using System;
using System.Windows.Forms;
using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.CoreLib;

namespace StudentUI
{
    public partial class ChoseTestForm : AbstractForm
    {
        private IQueryResult _queryResult;
        public ChoseTestForm(IQueryResult queryResult)
        {
            _queryResult = queryResult;
            InitializeComponent();
        }

        private void ButtonSignIn_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBoxLogin.Text) && !string.IsNullOrEmpty(textBoxPassword.Text))
            {
                string id = textBoxLogin.Text;
                string password = textBoxPassword.Text;

                if(Core.CheckPassword(_queryResult, id, password))
                {
                    new TestingForm();
                    WindowState = FormWindowState.Minimized;
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Dispose();
        }

        private void ButtonRegistration_Click(object sender, EventArgs e)
            => new RegistrationForm(_queryResult).Show();

        private void ButtonChoseTrainingTest_Click(object sender, EventArgs e)
            => new ChoseDirectionForm(_queryResult);

        private void ButtonRecoveryPassword_Click(object sender, EventArgs e)
            => new RecoveryPasswordForm(_queryResult);

        private void ОтчетыToolStripMenuItem_Click(object sender, EventArgs e)
            => new ReportsForm(_queryResult);

        private void НастройкиToolStripMenuItem_Click(object sender, EventArgs e)
            => new OptionsForm();

        private void ОНасToolStripMenuItem_Click(object sender, EventArgs e)
            => new AboutForm();
    }
}
