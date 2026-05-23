namespace kuRomek.SimpleVG
{
    public abstract class Presenter
    {
        protected Model Model { get; }
        protected View View { get; }

        public Presenter(View view, Model model)
        {
            View = view;
            Model = model;
        }
    }
}