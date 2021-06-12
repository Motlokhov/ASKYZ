using SystemVerifyKnowledge.ApplicationController.Interface;
using SystemVerifyKnowledge.Common.Interface;

namespace SystemVerifyKnowledge.Common.BaseClass
{
    public abstract class PresenterBase<TView> : IPresenter
        where TView : IView
    {
        protected readonly TView View;
        protected IApplicationController Controller;

        public PresenterBase(IApplicationController controller, TView view)
        {
            View = view;
            Controller = controller;
        }

        public virtual void Run()
        {
            View.Show();
        }
    }
}
