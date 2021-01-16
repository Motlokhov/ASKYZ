using System;
using System.Windows.Forms;
using System.IO;
using CoreLib.Common;

namespace Testing_a_person
{
    public partial class OptionsForm : Form
    {
        string pathToConnTxt = @"connection.txt";
        string pathToDOEC = @"DataOfEC.xml";
        
        public OptionsForm()
        {
            InitializeComponent();
            Show();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            
            if( !File.Exists(pathToConnTxt) )
                File.Create(pathToConnTxt);
            textBoxConnectionString.Text = File.ReadAllText(pathToConnTxt);

            EducationalCenter EC = new EducationalCenter(pathToDOEC);
            textBoxAddres.Text = EC.Addres;
            textBoxDirector.Text = EC.Director;
            textBoxName.Text = EC.Name;
            textBoxEmail.Text = EC.Email;
            textBoxPhone.Text = EC.Phone;
            textBoxSite.Text = EC.Site;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                Dispose();   
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить изменения?", "Настройки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                File.WriteAllText(pathToConnTxt , textBoxConnectionString.Text);
                EducationalCenter EC = new EducationalCenter
                    (
                        textBoxName.Text,
                        textBoxAddres.Text,
                        textBoxPhone.Text,
                        textBoxSite.Text,
                        textBoxDirector.Text,
                        textBoxEmail.Text
                    );
                EC.SaveToXML(pathToDOEC);
                Dispose();
            }
        }
    }
}
