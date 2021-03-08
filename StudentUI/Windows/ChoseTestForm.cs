using CoreLib.Main;
using Database.Result;
using System;
using System.Windows.Forms;
using StudentUI;

namespace StudentUI
{
    public partial class ChoseTestForm : AbstractForm
    {
        public ChoseTestForm()
        {
            InitializeComponent();
            //Question.ParseQuestionDocument(@"C:\Users\Hiruko\Desktop\Вопросы\Тестовые вопросы\7 категория.txt");
        }
       
        private void buttonSignIn_Click(object sender , EventArgs e)
        {
            if( !string.IsNullOrEmpty(textBoxLogin.Text) && !string.IsNullOrEmpty(textBoxPassword.Text))
            {
                string id = textBoxLogin.Text;
                string password = textBoxPassword.Text;
               
                if( Core.CheckPassword(new QueryResult(CustomDependencyInjection.DbConnection), id, password) )
                {
                    var testingForm = new TestingForm();
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

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
        }

        private void buttonChoseTrainingTest_Click(object sender , EventArgs e)
        {
            var form = new ChoseDirectionForm();
            WindowState = FormWindowState.Minimized;
        }

        private void buttonRecoveryPassword_Click(object sender , EventArgs e)
        {
            var recoveryForm = new RecoveryPasswordForm();
        }

        private void отчетыToolStripMenuItem_Click(object sender , EventArgs e)
        {
            var form = new ReportsForm();
        }

        private void настройкиToolStripMenuItem_Click(object sender , EventArgs e)
        {
            var form = new OptionsForm();
        }

        private void оНасToolStripMenuItem_Click(object sender , EventArgs e)
        {
            var form = new AboutForm();
        }
    }
}
