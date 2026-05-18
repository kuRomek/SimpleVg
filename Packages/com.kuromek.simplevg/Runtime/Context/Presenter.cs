using UnityEngine;

namespace kuRomek.SimpleVG
{
    public abstract class Presenter
    {
        private readonly Model _model;
        private readonly View _view;

        protected Model Model => _model;
        protected View View => _view;

        private IUpdatable _updatable;

        public Presenter(View view)
        {
            _view = view;
            _model = CreateModel(view.transform);

            _updatable = _model is IUpdatable updatable ? updatable : null;
        }

        public void Update(float deltaTime)
        {
            _updatable?.Update(deltaTime);
        }

        protected abstract Model CreateModel(Transform transform);
    }
}