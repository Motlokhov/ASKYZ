using CoreLib.Main;
using Database.Result;
using System;
using System.Windows.Forms;

namespace StudentUI
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
            (byte id, string name)[] result = QueryResult.LoadAllDirections();
            int top = 250;
            int width = 500;
            int height = 60;
            int margin = height + 10;
            for( int i = 0; i < result.Length; i++ )
                        {
                Button button = new Button
                {
                    Text = result[i].name,
                    Tag = result[i].id,
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
