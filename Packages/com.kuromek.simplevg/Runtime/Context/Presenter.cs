namespace kuRomek.SimpleVG
{
    public abstract class Presenter
    {
        protected Model Model { get; }
        protected View View { get; }

        private IUpdatable _updatable;

        public Presenter(View view, Model model)
        {
            View = view;
            Model = model;

            _updatable = View is IUpdatable updatable ? updatable : null;
        }

        public void Update(float deltaTime)
        {
            if (this is IUpdatable updatable)
                updatable.Update(deltaTime);

            _updatable?.Update(deltaTime);
        }
    }
}