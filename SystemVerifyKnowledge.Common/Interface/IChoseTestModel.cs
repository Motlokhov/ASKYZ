namespace SystemVerifyKnowledge.Common.Interface
{
    public interface IChoseTestModel : IModel
    {
        bool TryValidateSignIn(SignIn signIn, out Student student);
    }
}
