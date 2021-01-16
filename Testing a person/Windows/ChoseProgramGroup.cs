using System;
using System.Drawing;
using System.Windows.Forms;
using CoreLib.Main;
using CoreLib.Common;

namespace Testing_a_person
{
    public partial class ChoseProgramGroup : AbstractForm
    {

        public ChoseProgramGroup()
        {
            InitializeComponent();
            CreateProgramGroupButtons();
        }

        private void CreateProgramGroupButtons()
        {
            var reader = Core.LoadPrograms(Core.DirectionID,TestType.training);
            int top = 10;
            int width = 1000;
            int height = 100;
            int margin = height + 10;
            while( reader.Read() )
            {
                var button = new Button
                {
                    Text = "Программа №" + reader["Number"] + ": " + reader["Name"] ,
                    Tag = reader["ID"] ,
                    Width = width ,
                    Height = height ,
                    Left = Width / 2 - width / 2 ,
                    Top = top ,
                    Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left ,
                    Font = new Font("Arial" , 18)
                };
                button.Click += Button_Click;
                Controls.Add(button);
                top += margin;
            }
        }

        private void Button_Click(object sender , EventArgs e)
        {
            var but = sender as Button;
            Core.SetProgramGroupID(Convert.ToByte(but.Tag));
            Core.CreateTrainingTest(Core.ProgramGroupID);
            var form = new TestingForm();
            Close();
        }

    }
}
