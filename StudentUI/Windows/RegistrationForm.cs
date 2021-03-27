using System;
using System.Windows.Forms;
using System.Collections.Generic;
using CoreLib.Common;
using Database.Result;
using System.Linq;

namespace StudentUI
{
    public partial class RegistrationForm 
    {
        private readonly QueryResult _queryResult = new QueryResult(CustomDependencyInjection.DbConnection);
        private List<byte> directions;
        private (byte id, string name, byte number)[] programs;
        private byte programId;

        public RegistrationForm()
        {
            InitializeComponent();
            
        }

        private void ButtonShowPassword_MouseEnter(object sender , EventArgs e)
        {
            textBoxPassword.PasswordChar = char.MinValue;
            textBoxRepeatPassword.PasswordChar = char.MinValue;
        }

        private void ButtonShowPassword_MouseLeave(object sender , EventArgs e)
        {
            textBoxPassword.PasswordChar = Convert.ToChar("*");
            textBoxRepeatPassword.PasswordChar = Convert.ToChar("*");
        }

        private void RegistrationForm_Load(object sender , EventArgs e)
        {
            directions = new List<byte>();

            (byte id, string name)[] result = _queryResult.LoadAllDirections();
            for( int i = 0; i < result.Length; i++ )
            {
                directions.Add(result[i].id);
                comboBoxDirection.Items.Add(result[i].name);
            }
        }

        private void ComboBoxDirection_SelectedValueChanged(object sender , EventArgs e)
        {
            int selected = comboBoxDirection.SelectedIndex;
            byte id = directions[selected];
            programs = _queryResult.LoadProgramsByDirecionAndType(id, (int)ExerciseSetType.Grand);

            bool AreProgramsAccesable = programs.Any();

            comboBoxGroup.Text = string.Empty;
            comboBoxGroup.Items.Clear();
            comboBoxGroup.Visible = AreProgramsAccesable;
            label12.Visible = AreProgramsAccesable;

            if(!AreProgramsAccesable)
            {
                MessageBox.Show("Программы контрольного тестирования не доступны");
                return;
            }

            for(int i = 0; i < programs.Length; i++)             
                comboBoxGroup.Items.Add(string.Concat("Группа № ", programs[i].number, ": ", programs[i].name));
        }

        private void ComboBoxGroup_SelectedValueChanged(object sender , EventArgs e)
        {
            int index = comboBoxGroup.SelectedIndex;
            programId = programs[index].id;
        }

        private void ButtonSave_Click(object sender , EventArgs e)
        {
            if(textBoxPassword.Text != textBoxRepeatPassword.Text )
            {
                MessageBox.Show("Пароли не совпадают.");
                return;
            }

            bool isRegOK = _queryResult.InsertNewUser
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
                MessageBox.Show("Регистрация прошла успешно.");
            else
                MessageBox.Show("Регистрация не удалась.");
        }

        private void ButtonClearForm_Click(object sender , EventArgs e)
        {
            foreach( Control control in Controls )
            {
                if(control is TextBox textbox)
                    textbox.Text = "";
                if( control is DateTimePicker dataTimePicker )
                    dataTimePicker.Value = DateTime.Today;
                if( control is NumericUpDown numericUpDown )
                    numericUpDown.Value = 0;
            }
        }
    }
}
