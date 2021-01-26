using System;
using System.Windows.Forms;
using System.Collections.Generic;
using CoreLib.Main;
using CoreLib.Common;
using CoreLib.Testing;
using Database.Result;

namespace Testing_a_person
{
    public partial class RegistrationForm 
    {
        List<byte> directions;
        List<byte> programs;
        byte programId;
        public RegistrationForm()
        {
            InitializeComponent();
            
        }
        

        private void buttonShowPassword_MouseEnter(object sender , EventArgs e)
        {
            textBoxPassword.PasswordChar = char.MinValue;
            textBoxRepeatPassword.PasswordChar = char.MinValue;
        }

        private void buttonShowPassword_MouseLeave(object sender , EventArgs e)
        {
            textBoxPassword.PasswordChar = Convert.ToChar("*");
            textBoxRepeatPassword.PasswordChar = Convert.ToChar("*");
        }

        private void RegistrationForm_Load(object sender , EventArgs e)
        {
            directions = new List<byte>();

            (byte id, string name)[] result = QueryResult.LoadAllDirections();
            for( int i = 0; i < result.Length; i++ )
            {
                directions.Add(result[i].id);
                comboBoxDirection.Items.Add(result[i].name);
            }
        }

        private void comboBoxDirection_SelectedValueChanged(object sender , EventArgs e)
        {
            comboBoxGroup.Text = string.Empty;
            comboBoxGroup.Items.Clear();
            
            int selected = comboBoxDirection.SelectedIndex;
            byte id = directions[selected];

            var reader = Core.LoadPrograms(id,TestType.control);
            
            if(!reader.HasRows)
            {
                comboBoxGroup.Visible = false;
                label12.Visible = false;
                MessageBox.Show("Программы контрольного тестирования не доступны");
                return;
                
            }
            
            programs = new List<byte>();
            while( reader.Read() )
            {
                byte programID = Convert.ToByte(reader["ID"]);
                byte programNumber = Convert.ToByte(reader["Number"]);
                string programName = Convert.ToString(reader["Name"]);
                programs.Add(programID);
                comboBoxGroup.Items.Add("Группа № " + programNumber.ToString() + ": " + programName);
            }
            comboBoxGroup.Visible = true;
            label12.Visible = true;
        }

        private void comboBoxGroup_SelectedValueChanged(object sender , EventArgs e)
        {
            int index = comboBoxGroup.SelectedIndex;
            programId = programs[index];
        }

        private void buttonSave_Click(object sender , EventArgs e)
        {
            if(textBoxPassword.Text != textBoxRepeatPassword.Text )
            {
                MessageBox.Show("Пароли не совпадают.");
                return;
            }

            bool isRegOK = User.Registration
                (
                textBoxFirstname.Text ,
                textBoxSurname.Text ,
                textBoxLastname.Text ,
                Convert.ToUInt16(numericSeriePassport.Value) ,
                Convert.ToUInt32(numericNumberPassport.Value) ,
                dateStartTest.Value ,
                dateEndTest.Value ,
                textBoxPassword.Text ,
                programId
                );
            if( isRegOK )
            {
                MessageBox.Show("Регистрация прошла успешно.");
                return;
            }
        }

        private void buttonClearForm_Click(object sender , EventArgs e)
        {
            foreach( Control control in Controls )
            {
                TextBox textbox = control as TextBox;
                DateTimePicker dataTimePicker = control as DateTimePicker;
                NumericUpDown numericUpDown = control as NumericUpDown;

                if( textbox != null )
                    textbox.Text = "";
                if( dataTimePicker != null )
                    dataTimePicker.Value = DateTime.Today;
                if( numericUpDown != null )
                    numericUpDown.Value = 0;
            }
        }
    }
}
