using SystemVerifyKnowledge.ApplicationContainer.Interface;
using SystemVerifyKnowledge.Common.Interface;

namespace SystemVerifyKnowledge.Common.BaseClass
{
    public abstract class PresenterBase<TView, TModel>
        where TView : IView
        where TModel : IModel
    {
        protected readonly TView View;
        protected readonly TModel Model;
        protected readonly IApplicationContainer Container;

        public PresenterBase(IApplicationContainer container, TView view, TModel model)
        {
            View = view;
            Container = container;
            Model = model;
        }
    }
}
