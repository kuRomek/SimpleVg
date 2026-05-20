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

        public Presenter(View view, Model model)
        {
            _view = view;
            _model = model;

            _updatable = _model is IUpdatable updatable ? updatable : null;
        }

        public void Update(float deltaTime)
        {
            _updatable?.Update(deltaTime);
        }
    }
}