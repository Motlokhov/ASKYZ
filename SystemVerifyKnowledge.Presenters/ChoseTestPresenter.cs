using SystemVerifyKnowledge.ApplicationContainer.Interface;
using SystemVerifyKnowledge.Common;
using SystemVerifyKnowledge.Common.BaseClass;
using SystemVerifyKnowledge.Common.Interface;

namespace SystemVerifyKnowledge.Presenters
{
    public sealed class ChoseTestPresenter : PresenterBase<IChoseTestView, IChoseTestModel>, IPresenter
    {
        public ChoseTestPresenter(IApplicationContainer container, IChoseTestView view, IChoseTestModel model)
            : base(container, view, model)
        {
            view.SingIn += SingIn;
        }

        public void Run() => View.Show();

        private void SingIn()
        {
            if(string.IsNullOrEmpty(View.Password.Text) || string.IsNullOrEmpty(View.Login.Text))
            {
                View.ShowInfoMessage("Не все обязательные поля заполненны.");
                return;
            }

            if(!ulong.TryParse(View.Login.Text, out ulong login))
            {
                View.ShowInfoMessage("Логин должен быть положительным числом");
                return;
            }

            if(Model.TryValidateSignIn(new SignIn(login, View.Password.Text), out Student student))
            {
                Container.Run<GrandExercisePresenter, Student>(student);
                View.Login.Text = View.Password.Text = string.Empty;
            }
            else
                View.ShowInfoMessage("Пароль/логин не правильны.");

        }
    }
}
