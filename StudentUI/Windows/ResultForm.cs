using CoreLib.Main;
using CoreLib.Model;
using System;

namespace StudentUI
{
    public partial class ResultForm : AbstractForm
    {
        public ResultForm()
        {
            User user = Core.User;
            ExerciseSet exercises = Core.Exercises;


            InitializeComponent();
            groupBoxResult.Text += DateTime.Today.ToString("d");
            labelUser.Text += user.Name;
            labelGroup.Text += Core.DirectionName;
            labelTestNumber.Text += Core.ProgramNumber.ToString();
            labelAllPoints.Text += exercises.GetAllPoints().ToString();

            Exercise exercise = exercises[0];
            labelCountPoints1.Text += exercise.Result.Points.ToString();
            labelCountQuestions1.Text += exercise.RequiredNumberQuestions.ToString();
            labelCountTrueAnswers1.Text += exercise.Result.TrueAnswers.ToString();
            labelCountFalseAnswers1.Text += exercise.Result.FalseAnswers.ToString();

            exercise = exercises[1];
            labelCountPoints2.Text += exercise.Result.Points.ToString();
            labelCountQuestions2.Text += exercise.RequiredNumberQuestions.ToString();
            labelCountTrueAnswers2.Text += exercise.Result.TrueAnswers.ToString();
            labelCountFalseAnswers2.Text += exercise.Result.FalseAnswers.ToString();

            exercise = exercises[2];
            labelCountPoints3.Text += exercise.Result.Points.ToString();
            labelCountQuestions3.Text += exercise.RequiredNumberQuestions.ToString();
            labelCountTrueAnswers3.Text += exercise.Result.TrueAnswers.ToString();
            labelCountFalseAnswers3.Text += exercise.Result.FalseAnswers.ToString();
        }


    }
}
