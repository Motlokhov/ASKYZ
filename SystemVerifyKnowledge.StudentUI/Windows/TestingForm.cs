using System;
using System.Windows.Forms;
using System.Drawing;
using SystemVerifyKnowledge.CoreLib.Common;
using SystemVerifyKnowledge.CoreLib.Model;
using SystemVerifyKnowledge.CoreLib;
using SystemVerifyKnowledge.Presenters;
using SystemVerifyKnowledge.Common.Interface;

namespace StudentUI
{
    public partial class TestingForm : AbstractForm, ITestingView
    {
        private Form pictureForm;
        private CheckBox[] checkBoxes;
        public TestingForm()
        {
            InitializeComponent();
            richTextBoxQuestion.Text = string.Empty;
            Core.Exercises.KnowledgeVerifyingEnded += KnowledgeVerifyingEnded;
            CheckManipulateButtons();
        }

        private void CheckManipulateButtons()
        {
            ExerciseSetType testType = Core.Exercises.Type;
            if(testType == ExerciseSetType.Training)
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
            bool hasNextExercise = buttonNextExercise.Visible = Core.Exercises.HasNextExercise;
            if(hasNextExercise)
            {
                buttonNextExercise.Text = Core.Exercises.GetNextExerciseName;
            }

            bool hasPreviousExercise = buttonPreviousExercise.Visible = Core.Exercises.HasPreviousExercise;
            if( hasPreviousExercise )
            {
                buttonPreviousExercise.Text = Core.Exercises.GetPreviousExerciseName;
            }

            ShowQuestion();
        }

        private void KnowledgeVerifyingEnded()
        {
            if( Core.Exercises.Type == ExerciseSetType.Grand )
            {
                ResultForm resultForm = new();
                resultForm.Show();
            }
            else
            {
                Program.AppController.Run<ChoseTestPresenter>();
                MessageBox.Show("Обучающее тестирование завершено.");
            }
            Core.Exercises.KnowledgeVerifyingEnded -= KnowledgeVerifyingEnded;
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
           
            ExerciseType exerciseType = Core.Exercises.Exercise.Type;
            CheckBox checkBox = sender as CheckBox;
            if( exerciseType == ExerciseType.themen )
            {
               
                CheckCheckBoxForThemenTest(checkBox);
            }
            else
            {
                foreach(CheckBox item in checkBoxes )
                {
                    item.Checked = false;
                }
                checkBox.Checked = true;
            }
        }

        private void CheckCheckBoxForThemenTest(CheckBox checkbox)
        {
            int countChecked = 0;

            foreach(CheckBox item in checkBoxes )
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

            Exercise exercise = Core.Exercises.Exercise;
            int questionCurrentNumber = exercise.Questions.Index + 1;
            int questionCount = exercise.Questions.Count;
            string exerciseName = exercise.Name;
            string descriptionString = exerciseName + ": " + questionCurrentNumber + " из " + questionCount + "\n\n";

            richTextBoxQuestion.Text = string.Empty;
            richTextBoxQuestion.SelectedText = descriptionString + "  " + exercise.Question.Name+"\n\n";
            richTextBoxQuestion.Tag = exercise.Question.Id;
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
            Question question = Core.Exercises.Exercise.Question;
            int countAnswers = question.Answers.Count;
            checkBoxes = new CheckBox[countAnswers];
            for(int i = 0 ;i<question.Answers.Count ;i++ )
            {
                Answer answer = question.Answers[i];
                CheckBox checkbox = CreateAnswerCheckBox(answer.Id , i + 1);
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
            newString = "  " + answer.Name;
            richTextBoxQuestion.AppendText(newString);
            richTextBoxQuestion.AppendText("\n\n");
        }

        private void ShowLinkLabelImage()
        {
            linkLabelImage.Visible = Core.Exercises.Exercise.Question.GetImage() != null;
        }

        private void LinkLabelImage_LinkClicked(object sender , LinkLabelLinkClickedEventArgs e)
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
                Image = Core.Exercises.Exercise.Question.GetImage() ,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            pictureForm.Controls.Add(pictureOfQuestion);
            pictureForm.Show();
       
        }

        private ulong[] CheckNumberMarking()
        {
            int countChecked = 0;
            for(int i = 0 ; i < checkBoxes.Length ; i++ )
            {
                if( checkBoxes[i].Checked )
                {
                    countChecked++;
                }
            }
            ulong[] answersID = new ulong[countChecked];
            int index = 0;
            for(int i = 0 ; i < checkBoxes.Length ; i++ )
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
            foreach(CheckBox checkbox in checkBoxes )
            {
                checkbox.Checked = false;
            }
        }

        private void ButtonGiveAnswer_Click(object sender, EventArgs e)
        {
            ulong[] answersID = CheckNumberMarking();
            if(answersID.Length == 0)
            {
                MessageBox.Show("Выберите ответ");
                return;
            }

            if(Core.Exercises.IsNextQuestionAvailable(answersID))
            {
                if(!Core.Exercises.NextQuestion())
                {
                    Core.Exercises.TestEnd();
                    return;
                }
                ShowQuestion();
                return;
            }
            UncheckCheckBoxes();
            MessageBox.Show("Ответ не правильный.");
        }

        private void ButtonPassQuestion_Click(object sender , EventArgs e)
        {
            Core.Exercises.PassQuestion();
            ShowQuestion();
        }

        private void ButtonPreviousExercise_Click(object sender , EventArgs e)
        {
            Core.Exercises.PreviousExercise();
            CheckExerciseButtons();
        }

        private void ButtonNextExercise_Click(object sender , EventArgs e)
        {
            Core.Exercises.NextExercise();
            CheckExerciseButtons();
        }
    }
}
