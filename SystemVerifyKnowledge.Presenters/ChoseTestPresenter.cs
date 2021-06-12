using SystemVerifyKnowledge.ApplicationController.Interface;
using SystemVerifyKnowledge.Common.BaseClass;
using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.CoreLib;

namespace SystemVerifyKnowledge.Presenters
{
    public sealed class ChoseTestPresenter : PresenterBase<IChoseTestView>
    {
        private readonly IQueryResult _queryResult;

        public ChoseTestPresenter(IApplicationController controller, IChoseTestView view, IQueryResult queryResult) 
            : base(controller,view)
        {
            _queryResult = queryResult;
            view.SingIn += ValidateSingIn;
        }

        public void ValidateSingIn(IUserSignIn userSignIn)
        {
            if (string.IsNullOrEmpty(userSignIn.Login) || string.IsNullOrEmpty(userSignIn.Password))
            {
                View.ShowInfoMessage("Не все обязательные поля заполненны.");
                return;
            }

            if (Core.CheckPassword(_queryResult, userSignIn))
                Controller.Run<TestingPresenter>();
            else
                View.ShowInfoMessage("Пароль/логин не правильны.");
        }
    }
}
