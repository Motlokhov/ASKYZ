using SystemVerifyKnowledge.ApplicationController.Interface;
using SystemVerifyKnowledge.Common.BaseClass;
using SystemVerifyKnowledge.Common.Interface;

namespace SystemVerifyKnowledge.Presenters
{
    class TestingPresenter : PresenterBase<ITestingView>
    {
        public TestingPresenter(IApplicationController controller, ITestingView view)
            :base(controller,view)
        {

        }
    }
}
