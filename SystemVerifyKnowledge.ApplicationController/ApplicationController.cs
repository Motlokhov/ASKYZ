using LightInject;
using SystemVerifyKnowledge.ApplicationController.Interface;
using SystemVerifyKnowledge.Common.Interface;

namespace SystemVerifyKnowledge.ApplicationController
{
    public class ApplicationController : IApplicationController
    {
        private readonly ServiceContainer _container;

        public ApplicationController()
        {
            _container = new ServiceContainer();
            _container.RegisterInstance<IApplicationController>(this);
        }

        public IApplicationController RegisterInstance<TInstance>(TInstance instance)
        {
            _container.RegisterInstance(instance);
            return this;
        }

        public IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService
        {
            _container.Register<TService, TImplementation>();
            return this;
        }

        public IApplicationController RegisterView<TView, TImplementation>()
            where TView : IView
            where TImplementation : class, TView
        {
            _container.Register<TView, TImplementation>();
            return this;
        }

        public void Run<TPresenter>() 
            where TPresenter : class, IPresenter
        {
            if (!_container.CanGetInstance(typeof(TPresenter), string.Empty))
                _container.Register<TPresenter>();

            _container.GetInstance<TPresenter>()
                      .Run();
        }

        public void Run<TPresenter, TArgumnent>(TArgumnent argumnent) 
            where TPresenter : class, IPresenter<TArgumnent>
        {
            if (!_container.CanGetInstance(typeof(TPresenter), string.Empty))
                _container.Register<TPresenter>();

            _container.GetInstance<TPresenter>()
                      .Run(argumnent);
        }
    }
}
