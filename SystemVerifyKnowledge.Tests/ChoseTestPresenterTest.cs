using Database.Result;
using Moq;
using SystemVerifyKnowledge.ApplicationContainer.Interface;
using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.Models;
using SystemVerifyKnowledge.Presenters;
using Xunit;

namespace SystemVerifyKnowledge.Tests
{
    [Collection(nameof(SystemVerifyKnowledgeFixture))]
    public class ChoseTestPresenterTest
    {
        private readonly SystemVerifyKnowledgeFixture _fixture;
        private readonly ChoseTestPresenter _sut;
        private readonly Mock<IApplicationContainer> _appContainer = new();
        private readonly Mock<IChoseTestView> _view = new();

        public ChoseTestPresenterTest(SystemVerifyKnowledgeFixture fixture)
        {
            _fixture = fixture;
            _sut = new ChoseTestPresenter(
                _appContainer.Object,
                _view.Object,
                new ChoseTestModel(new QueryResult(_fixture.Connection)));


        }

        private void SignInAction(Mock<IChoseTestView> view)
        {
            view.Raise(_ => _.SingIn += null);
        }

        private void SetupUserSignIn(Mock<IChoseTestView> view, string login, string password)
        {
            view.Setup(_ => _.Login.Text).Returns(login);
            view.Setup(_ => _.Password.Text).Returns(password);
        }

        [Fact]
        public void TestSignInSuccess()
        {
            SetupUserSignIn(_view, "login", "password");
            SignInAction(_view);
        }
    }
}
