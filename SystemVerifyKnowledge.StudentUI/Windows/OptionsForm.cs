using System;
using System.Windows.Forms;
using System.IO;
using SystemVerifyKnowledge.CoreLib.Common;

namespace StudentUI
{
    public partial class OptionsForm : Form
    {
        private readonly string _pathToConnTxt = @"connection.txt";
        private readonly string _pathToDOEC = @"DataOfEC.xml";
        
        public OptionsForm()
        {
            InitializeComponent();
            Show();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            
            if( !File.Exists(_pathToConnTxt) )
                File.Create(_pathToConnTxt);
            textBoxConnectionString.Text = File.ReadAllText(_pathToConnTxt);

            EducationalCenter EC = new EducationalCenter(_pathToDOEC);
            textBoxAddres.Text = EC.Addres;
            textBoxDirector.Text = EC.Director;
            textBoxName.Text = EC.Name;
            textBoxEmail.Text = EC.Email;
            textBoxPhone.Text = EC.Phone;
            textBoxSite.Text = EC.Site;
        }

        private void Button1_Click(object sender, EventArgs e) => Dispose();

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить изменения?", "Настройки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                File.WriteAllText(_pathToConnTxt , textBoxConnectionString.Text);
                EducationalCenter EC = new EducationalCenter
                    (
                        textBoxName.Text,
                        textBoxAddres.Text,
                        textBoxPhone.Text,
                        textBoxSite.Text,
                        textBoxDirector.Text,
                        textBoxEmail.Text
                    );
                EC.SaveToXML(_pathToDOEC);
                Dispose();
            }
        }
    }
}
