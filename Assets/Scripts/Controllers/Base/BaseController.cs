using UnityEngine;

namespace TowerOfDeath
{
    public abstract class BaseController<TView, TModel> : MonoBehaviour, IController where TView : IView where TModel : IModel
    {
        protected TView view;
        protected TModel model;
        protected abstract void Bind();
        public void Bind(TView view, TModel model)
        {
            BindView(view);
            BindModel(model);
            Bind();
            model?.Binded();
        }

        private void BindView(TView view)
        {
            this.view = view;
        }

        private void BindModel(TModel model)
        {
            this.model = model;
        }

    }
}
