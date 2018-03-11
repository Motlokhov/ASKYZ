using System;
using System.Windows.Forms;
using System.Drawing;

namespace Testing_a_person
{

    using Core;
    using Core.Common;
    using Core.Testing;

    public partial class TestingForm : AbstractForm
    {
        private Form pictureForm;
        private CheckBox[] checkBoxes;
        public TestingForm()
        {
            InitializeComponent();
            richTextBoxQuestion.Text = string.Empty;
            Core.Test.testEnding += TestEnding;
            CheckManipulateButtons();
            Show();
        }

        private void CheckManipulateButtons()
        {
            TestType testType = Core.Test.GetType();
            if(testType == TestType.training)
            {
                buttonPassQuestion.Visible = false;
                CheckExerciseButtons();
                return;
            }
            buttonNextExercise.Visible = false;
            buttonPreviousExercise.Visible = false;
            ShowQuestion();
        }

        private void CheckExerciseButtons()
        {
            bool hasNextIndex = Core.Test.Exercises.HasNextIndex();
            if(hasNextIndex)
            {
                buttonNextExercise.Text = Core.Test.GetNextExerciseName();
            }
            bool hasPreviousIndex = Core.Test.Exercises.HasPreviousIndex();
            if( hasPreviousIndex )
            {
                buttonPreviousExercise.Text = Core.Test.GetPreviousExerciseName();
            }
            buttonPreviousExercise.Visible = hasPreviousIndex;
            buttonNextExercise.Visible = hasNextIndex;
            ShowQuestion();
        }

        private void TestEnding()
        {
            if( Core.Test.GetType() == TestType.control )
            {
                var resultForm = new ResultForm();
                resultForm.Show();
            }
            else
            {
                Program.MainForm.Show();
                MessageBox.Show("Обучающее тестирование завершено.");
            }
            Core.Test.testEnding -= TestEnding;
            Close();
        }

        private CheckBox CreateAnswerCheckBox(ulong answerId , int answerNumber)
        {
            CheckBox checkBox = new CheckBox
            {
                Name = "checkBoxAnswer"+ answerNumber ,
                Tag = answerId ,
                BackColor = Color.Navy ,
                ForeColor = Color.White ,
                Font = new Font("Arial" , 15F , FontStyle.Regular , GraphicsUnit.Point , 204) ,
                FlatStyle = FlatStyle.Flat ,
                Appearance = Appearance.Button ,
                Text = "Ответ № " + answerNumber ,
                Width = 120 ,
                Height = 30
            };

            checkBox.Click += new EventHandler(CheckBoxAnswer_Click);
            checkBox.FlatAppearance.CheckedBackColor = Color.Green;
            checkBox.FlatAppearance.MouseOverBackColor = Color.CornflowerBlue;
            return checkBox;
        }

        private void CheckBoxAnswer_Click(object sender , EventArgs e)
        {
           
            ExerciseType exerciseType = Core.Test.Exercise.Type;
            var checkBox = sender as CheckBox;
            if( exerciseType == ExerciseType.themen )
            {
               
                CheckCheckBoxForThemenTest(checkBox);
            }
            else
            {
                foreach(var item in checkBoxes )
                {
                    item.Checked = false;
                }
                checkBox.Checked = true;
            }
        }

        private void CheckCheckBoxForThemenTest(CheckBox checkbox)
        {
            int countChecked = 0;

            foreach( var item in checkBoxes )
            {
                if( item.Checked )
                {
                    countChecked++;
                }
            }
            if(countChecked > 2 )
            {
                checkbox.Checked = false;
            }
        }
        
        private void ShowQuestion()
        {
          
            var exercise = Core.Test.Exercise;
            int questionCurrentNumber = exercise.Questions.GetIndex() + 1;
            int questionCount = exercise.Questions.Count;
            string exerciseName = exercise.GetName();
            string descriptionString = exerciseName + ": " + questionCurrentNumber + " из " + questionCount + "\n\n";

            richTextBoxQuestion.Text = string.Empty;
            richTextBoxQuestion.SelectedText = descriptionString + "  " + exercise.Question.GetName()+"\n\n";
            richTextBoxQuestion.Tag = exercise.Question.GetID();
            ShowLinkLabelImage();
            ShowAnswers();
        }
        
        private void ClearFlowLayoutPanelAnswers()
        {
            flowLayoutPanelAnswers.Controls.Clear();
            checkBoxes = null;
        }

        private void ShowAnswers()
        {
            ClearFlowLayoutPanelAnswers();
            var question = Core.Test.Exercise.Question;
            int countAnswers = question.Answers.Count;
            checkBoxes = new CheckBox[countAnswers];
            for(var i = 0 ;i<question.Answers.Count ;i++ )
            {
                var answer = (Answer)question.Answers[i];
                var checkbox = CreateAnswerCheckBox(answer.GetID() , i + 1);
                flowLayoutPanelAnswers.Controls.Add(checkbox);
                checkBoxes[i] = checkbox;
                WriteAnswerIntoRichTextBox(answer);
            }
        }

        private void WriteAnswerIntoRichTextBox(Answer answer)
        {
            string newString = "Ответ ";
            richTextBoxQuestion.SelectedText = newString;
            richTextBoxQuestion.SelectionFont = new Font("Arial" , 16 , FontStyle.Bold);
            richTextBoxQuestion.AppendText("\n");
            newString = "  " + answer.GetName();
            richTextBoxQuestion.AppendText(newString);
            richTextBoxQuestion.AppendText("\n\n");
        }

        private void ShowLinkLabelImage()
        {
            if(Core.Test.Exercise.Question.GetImage() != null)
            {
                linkLabelImage.Visible = true;
                return;
            }
            linkLabelImage.Visible = false;
        }

        private void linkLabelImage_LinkClicked(object sender , LinkLabelLinkClickedEventArgs e)
        {
            if( pictureForm != null )
            {
                pictureForm.Close();
            }
            pictureForm = new Form
            {
                Size = new Size(800 , 600) ,
                Text = "Картинка к вопросу",
                Icon = this.Icon
            };

            PictureBox pictureOfQuestion = new PictureBox
            {
                Dock = DockStyle.Fill ,
                Image = Core.Test.Exercise.Question.GetImage() ,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            pictureForm.Controls.Add(pictureOfQuestion);
            pictureForm.Show();
       
        }

        private ulong[] CheckNumberMarking()
        {
            int countChecked = 0;
            for( var i = 0 ; i < checkBoxes.Length ; i++ )
            {
                if( checkBoxes[i].Checked )
                {
                    countChecked++;
                }
            }
            ulong[] answersID = new ulong[countChecked];
            int index = 0;
            for( var i = 0 ; i < checkBoxes.Length ; i++ )
            {
                if( checkBoxes[i].Checked )
                {
                    answersID[index] = Convert.ToUInt64(checkBoxes[i].Tag);
                    index++;
                }
            }
            return answersID;
        }

        private void UncheckCheckBoxes()
        {
            foreach(var checkbox in checkBoxes )
            {
                checkbox.Checked = false;
            }
        }

        private void buttonGiveAnswer_Click(object sender , EventArgs e)
        {
            ulong[] answersID = CheckNumberMarking();
            if(answersID.Length == 0)
            {
                MessageBox.Show("Выберите ответ");
                return;
            }
            var isAnswerTrue = Core.Test.VerifyQuestion(answersID);
            if( isAnswerTrue )
            {
                bool hasNextexercise = Core.Test.NextQuestion();
                if( !hasNextexercise )
                {
                    Core.Test.TestEnd();
                    return;
                }
                ShowQuestion();
                return;
            }
            UncheckCheckBoxes();
            MessageBox.Show("Ответ не правильный.");
        }

        private void buttonPassQuestion_Click(object sender , EventArgs e)
        {
            Core.Test.PassQuestion();
            ShowQuestion();
        }

        private void buttonPreviousExercise_Click(object sender , EventArgs e)
        {
            Core.Test.PreviousExercise();
            CheckExerciseButtons();
        }

        private void buttonNextExercise_Click(object sender , EventArgs e)
        {
            Core.Test.NextExercise();
            CheckExerciseButtons();
        }
    }
}
