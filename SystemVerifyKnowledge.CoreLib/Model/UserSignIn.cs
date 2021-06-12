using SystemVerifyKnowledge.Common.Interface;

namespace SystemVerifyKnowledge.CoreLib.Model
{
    public sealed record UserSignIn : IUserSignIn
    {
        public string Login { get; init; }
        public string Password {get; init;}
    }
}
