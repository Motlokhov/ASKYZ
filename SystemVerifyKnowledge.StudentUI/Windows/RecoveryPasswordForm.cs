using System;
using System.Windows.Forms;
using SystemVerifyKnowledge.Common.Interface;

namespace StudentUI
{
    public partial class RecoveryPasswordForm : AbstractForm
    {
        private readonly IQueryResult _queryResult;

        public RecoveryPasswordForm(IQueryResult queryResult)
        {
            _queryResult = queryResult;
            InitializeComponent();
            Show();
        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            (ulong id, string password)? result = _queryResult.FindPassword((uint)numericUpDownSerialOfPassport.Value, (uint)numericUpDownNumberOfPassport.Value);

            textBoxRecoveredPassword.Text = result.HasValue ? result.Value.password : string.Empty;
            labelRecoveredPassword.Visible = result.HasValue;
            textBoxRecoveredPassword.Visible = result.HasValue;

            if(!result.HasValue)
                MessageBox.Show("Пользователь не найден, проверте введенные данные.");
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
