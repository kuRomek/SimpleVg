namespace kuRomek.SimpleVG
{
    public class Presenter
    {
        private readonly Model _model;
        private readonly View _view;

        protected Model Model => _model;
        protected View View => _view;

        private IUpdatable _updatable;

        public Presenter(View view)
        {
            _view = view;
            _model = new(view.transform);

            _updatable = _model is IUpdatable updatable ? updatable : null;
        }

        public void Update(float deltaTime)
        {
            _updatable?.Update(deltaTime);
        }
    }
}