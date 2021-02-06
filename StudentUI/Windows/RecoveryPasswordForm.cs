using Database.Result;
using System;
using System.Windows.Forms;

namespace StudentUI
{
    public partial class RecoveryPasswordForm : AbstractForm
    {
        private readonly QueryResult _queryResult = new QueryResult(CustomDependencyInjection.DbConnection);

        public RecoveryPasswordForm()
        {
            InitializeComponent();
            Show();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            (ulong id, string password)? result = _queryResult.FindPassword((uint)numericUpDownSerialOfPassport.Value, (uint)numericUpDownNumberOfPassport.Value);

            textBoxRecoveredPassword.Text = result.HasValue ? result.Value.password : string.Empty;
            labelRecoveredPassword.Visible = result.HasValue;
            textBoxRecoveredPassword.Visible = result.HasValue;

            if(!result.HasValue)
                MessageBox.Show("Пользователь не найден, проверте введенные данные.");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
