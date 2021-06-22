using SystemVerifyKnowledge.ApplicationContainer.Interface;
using SystemVerifyKnowledge.Common;
using SystemVerifyKnowledge.Common.BaseClass;
using SystemVerifyKnowledge.Common.Interface;

namespace SystemVerifyKnowledge.Presenters
{
    internal sealed class TestingPresenter : PresenterBase<ITestingView, ITestingModel>, IPresenter<Student>
    {
        private Student Student { get; set; }

        public TestingPresenter(IApplicationContainer container, ITestingView view, ITestingModel model)
            : base(container, view, model)
        {

        }

        public void Run(Student argument)
        {
            Student = argument;
            View.Show();
        }
    }
}
