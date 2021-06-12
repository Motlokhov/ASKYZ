using SystemVerifyKnowledge.Common.Interface;

namespace SystemVerifyKnowledge.ApplicationController.Interface
{
    public interface IApplicationController
    {
        IApplicationController RegisterView<TView, TImplementation>()
           where TImplementation : class, TView
           where TView : IView;

        IApplicationController RegisterInstance<TInstance>(TInstance instance);

        IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;

        void Run<TPresenter>()
            where TPresenter : class, IPresenter;

        void Run<TPresenter, TArgumnent>(TArgumnent argumnent)
            where TPresenter : class, IPresenter<TArgumnent>;
    }
}
