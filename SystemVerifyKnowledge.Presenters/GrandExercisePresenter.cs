using SystemVerifyKnowledge.ApplicationContainer.Interface;
using SystemVerifyKnowledge.Common;
using SystemVerifyKnowledge.Common.BaseClass;
using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.CoreLib.Model;

namespace SystemVerifyKnowledge.Presenters
{
    internal sealed class GrandExercisePresenter : PresenterBase<ITestingView, IGrandExerciseModel>, IPresenter<Student>
    { 

        public GrandExercisePresenter(IApplicationContainer container, ITestingView view, IGrandExerciseModel model)
            : base(container, view, model)
        {

        }

        public void Run(Student student)
        {
            Model.LoadFor(student);
            View.Show();
        }
    }
}
