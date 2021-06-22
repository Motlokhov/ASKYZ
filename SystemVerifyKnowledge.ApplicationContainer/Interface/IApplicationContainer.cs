using SystemVerifyKnowledge.Common.Interface;

namespace SystemVerifyKnowledge.ApplicationContainer.Interface
{
    public interface IApplicationContainer
    {
        IApplicationContainer RegisterView<TView, TImplementation>()
           where TImplementation : class, TView
           where TView : IView;

        IApplicationContainer RegisterModel<TModel, TImplementation>()
            where TImplementation : class, TModel
            where TModel : IModel;

        IApplicationContainer RegisterInstance<TInstance>(TInstance instance);

        IApplicationContainer RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;

        void Run<TPresenter>()
            where TPresenter : class, IPresenter;

        void Run<TPresenter, TArgumnent>(TArgumnent argumnent)
            where TPresenter : class, IPresenter<TArgumnent>;
    }
}
