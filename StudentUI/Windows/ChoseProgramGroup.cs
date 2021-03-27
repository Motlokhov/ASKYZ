using System;
using System.Drawing;
using System.Windows.Forms;
using CoreLib.Main;
using CoreLib.Common;
using Database.Result;
using System.Linq;

namespace StudentUI
{
    public partial class ChoseProgramGroup : AbstractForm
    {
        private readonly QueryResult _queryResult = new QueryResult(CustomDependencyInjection.DbConnection);

        public ChoseProgramGroup()
        {
            InitializeComponent();
            CreateProgramGroupButtons();
        }

        private void CreateProgramGroupButtons()
        {
            (byte id, string name, byte number)[] programs = _queryResult.LoadProgramsByDirecionAndType(Core.DirectionID, (int)ExerciseSetType.Training);

            if(!programs.Any())
            {
                MessageBox.Show("Программы тестирования не доступны.");
                return;
            }

            int top = 10;
            int width = 1000;
            int height = 100;
            int margin = height + 10;

            for(int i = 0; i < programs.Length; i++)
            {
                var button = new Button
                {
                    Text = string.Concat("Программа №", programs[i].number + ": " + programs[i].name) ,
                    Tag = programs[i].id ,
                    Width = width ,
                    Height = height ,
                    Left = Width / 2 - width / 2 ,
                    Top = top ,
                    Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left ,
                    Font = new Font("Arial" , 18)
                };
                button.Click += StartProgram_Click;
                Controls.Add(button);
                top += margin;
            }
        }

        private void StartProgram_Click(object sender , EventArgs e)
        {
            var but = sender as Button;
            Core.SetProgramGroupID(Convert.ToByte(but.Tag));
            Core.CreateTrainingTest(_queryResult, Core.ProgramGroupID);
            new TestingForm();
            Close();
        }

    }
}
