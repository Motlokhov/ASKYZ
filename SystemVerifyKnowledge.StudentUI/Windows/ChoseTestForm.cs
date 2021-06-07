using Database.Result;
using System;
using System.Windows.Forms;
using SystemVerifyKnowledge.CoreLib;

namespace StudentUI
{
    public partial class ChoseTestForm : AbstractForm
    {
        public ChoseTestForm()
        {
            InitializeComponent();
            //Question.ParseQuestionDocument(@"C:\Users\Hiruko\Desktop\Вопросы\Тестовые вопросы\7 категория.txt");
        }

        private void ButtonSignIn_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBoxLogin.Text) && !string.IsNullOrEmpty(textBoxPassword.Text))
            {
                string id = textBoxLogin.Text;
                string password = textBoxPassword.Text;

                if(Core.CheckPassword(new QueryResult(CustomDependencyInjection.DbConnection), id, password))
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
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
        }

        private void ButtonChoseTrainingTest_Click(object sender, EventArgs e)
            => new ChoseDirectionForm();

        private void ButtonRecoveryPassword_Click(object sender, EventArgs e)
            => new RecoveryPasswordForm();

        private void ОтчетыToolStripMenuItem_Click(object sender, EventArgs e)
            => new ReportsForm();

        private void НастройкиToolStripMenuItem_Click(object sender, EventArgs e)
            => new OptionsForm();

        private void ОНасToolStripMenuItem_Click(object sender, EventArgs e)
            => new AboutForm();
    }
}
