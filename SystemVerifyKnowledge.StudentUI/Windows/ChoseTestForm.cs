using System;
using System.Windows.Forms;
using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.CoreLib.Model;

namespace StudentUI
{
    public partial class ChoseTestForm : AbstractForm, IChoseTestView
    {
        public event Action<IUserSignIn> SingIn;
        public event Action ShowRegistrationWindow;
        public event Action ShowTrainingTestWindow;
        public event Action ShowRecoveryPasswordWindow;
        public event Action ShowReportsWindow;

        private readonly IQueryResult _queryResult;

        public IUserSignIn UserSignIn  
        {
            get
            {
                return new UserSignIn
                {
                    Login = textBoxLogin.Text,
                    Password = textBoxPassword.Text
                };
            }
        }

        public ChoseTestForm()
        {
            InitializeComponent();
            buttonSignIn.Click += delegate { SingIn?.Invoke(UserSignIn); };
            buttonChoseTrainingTest.Click += delegate { ShowTrainingTestWindow?.Invoke(); };
            buttonRecoveryPassword.Click += delegate { ShowRecoveryPasswordWindow.Invoke(); };
            buttonRegistration.Click += delegate { ShowRegistrationWindow.Invoke(); };
            отчетыToolStripMenuItem.Click += delegate { ShowReportsWindow.Invoke(); };
        }

        public new void Show() => Application.Run(this);

        //Избавиться от реализаций ниже с зависимостью 
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

        public void ShowInfoMessage(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
