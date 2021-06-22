using LightInject;
using SystemVerifyKnowledge.ApplicationContainer.Interface;
using SystemVerifyKnowledge.Common.Interface;

namespace SystemVerifyKnowledge.ApplicationContainer
{
    public class ApplicationContainer : IApplicationContainer
    {
        private readonly ServiceContainer _container;

        public ApplicationContainer()
        {
            _container = new ServiceContainer();
            _container.RegisterInstance<IApplicationContainer>(this);
        }

        public IApplicationContainer RegisterInstance<TInstance>(TInstance instance)
        {
            _container.RegisterInstance(instance);
            return this;
        }

        public IApplicationContainer RegisterService<TService, TImplementation>()
            where TImplementation : class, TService
        {
            _container.Register<TService, TImplementation>();
            return this;
        }

        public IApplicationContainer RegisterView<TView, TImplementation>()
            where TView : IView
            where TImplementation : class, TView
        {
            return RegisterService<TView, TImplementation>();
        }

        public void Run<TPresenter>()
            where TPresenter : class, IPresenter
        {
            if(!_container.CanGetInstance(typeof(TPresenter), string.Empty))
                _container.Register<TPresenter>();

            _container.GetInstance<TPresenter>()
                      .Run();
        }

        public void Run<TPresenter, TArgumnent>(TArgumnent argumnent)
            where TPresenter : class, IPresenter<TArgumnent>
        {
            if(!_container.CanGetInstance(typeof(TPresenter), string.Empty))
                _container.Register<TPresenter>();

            _container.GetInstance<TPresenter>()
                      .Run(argumnent);
        }

        public IQueryResult GetQueryResult()
        {
            return _container.GetInstance<IQueryResult>();
        }

        public IApplicationContainer RegisterModel<TModel, TImplementation>()
            where TModel : IModel
            where TImplementation : class, TModel
        {
            return RegisterService<TModel, TImplementation>();
        }
    }
}
