using System;

namespace SystemVerifyKnowledge.Common.Interface
{
    public interface IChoseTestView : IView, IShowMessage
    {
        event Action SingIn;
        event Action ShowRegistrationWindow;
        event Action ShowTrainingTestWindow;
        event Action ShowRecoveryPasswordWindow;
        event Action ShowReportsWindow;

        ITextIO Password { get; }
        ITextIO Login { get; }
    }
}
