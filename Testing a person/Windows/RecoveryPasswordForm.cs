using System;
using System.Data;
using System.Windows.Forms;

namespace Testing_a_person
{
    using Query;
    public partial class RecoveryPasswordForm : AbstractForm
    {
        public RecoveryPasswordForm()
        {
            InitializeComponent();
            Show();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            uint serialOfPassport =(uint)numericUpDownSerialOfPassport.Value;
            uint numberOfPassport = (uint)numericUpDownNumberOfPassport.Value;
            string commandString = "SELECT Id,Password FROM [User] ";
            commandString += "WHERE PassportSerie = "+ serialOfPassport+ " and PassportNumber = "+ numberOfPassport;
            Query query = new Query();
            var reader = query.ReadData(commandString);
            reader.Read();
            if (reader.HasRows)
            {
                ulong id =Convert.ToUInt64(reader["Id"]);
                string password = reader["Password"].ToString();
                labelRecoveredPassword.Visible = true;
                textBoxRecoveredPassword.Visible = true;
                textBoxRecoveredPassword.Text = password;
            }
            else
            {
                textBoxRecoveredPassword.Text = string.Empty;
                labelRecoveredPassword.Visible = false;
                textBoxRecoveredPassword.Visible = false;
                MessageBox.Show("Пользователь не найден, проверте введенные данные.");
            }
                
            query = null;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
