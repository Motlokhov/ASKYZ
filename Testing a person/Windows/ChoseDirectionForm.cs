using CoreLib.Main;
using System;
using System.Windows.Forms;

namespace Testing_a_person
{
    public partial class ChoseDirectionForm : AbstractForm
    {
        public ChoseDirectionForm()
        {
            InitializeComponent();
            Show();
            CreateDirectionsButtons();
        }

        public void CreateDirectionsButtons()
        {
            var reader = Core.LoadDirections();
            int top = 250;
            int width = 500;
            int height = 60;
            int margin = height + 10;
            while( reader.Read() )
            {
                Button button = new Button
                {
                    Text = reader["Name"].ToString() ,
                    Tag = reader["ID"] ,
                    Width = width ,
                    Height = height ,
                    Left = Width / 2 - width / 2 ,
                    Top = top ,
                    Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left ,
                    Font = new System.Drawing.Font("Arial" , 18)
                };
                button.Click += (s , e) =>
                {
                    var but = s as Button;  
                    Core.SetDirection(Convert.ToByte(but.Tag),but.Text);
                    var form = new ChoseProgramGroup();
                    form.Show();
                    Close();
                };
                Controls.Add(button);
                top += margin;
            }
        }



        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }
    }
}
