using SystemVerifyKnowledge.Common;
using SystemVerifyKnowledge.Common.Interface;

namespace SystemVerifyKnowledge.Models
{
    public class ChoseTestModel : IChoseTestModel
    {
        private readonly IQueryResult _queryResult;
        public ChoseTestModel(IQueryResult queryResult)
        {
            _queryResult = queryResult;
        }

        public bool TryValidateSignIn(SignIn signIn, out Student? student)
        {
            student = _queryResult.GetStudent(signIn);
            return student is not null;
        }
    }
}
