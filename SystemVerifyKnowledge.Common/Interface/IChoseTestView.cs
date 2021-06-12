using System;

namespace SystemVerifyKnowledge.Common.Interface
{
    public interface IChoseTestView : IView, IShowMessage
    {
        event Action<IUserSignIn> SingIn;
        event Action ShowRegistrationWindow;
        event Action ShowTrainingTestWindow;
        event Action ShowRecoveryPasswordWindow;
        event Action ShowReportsWindow;

        IUserSignIn UserSignIn { get; }
    }
}
