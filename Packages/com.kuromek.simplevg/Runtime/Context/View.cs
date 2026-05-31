using UnityEngine;

namespace kuRomek.SimpleVG
{
    public class View : MonoBehaviour
    {
        protected Presenter Presenter { get; private set; }

        private void Update()
        {
            if (Presenter is IUpdatable updatable)
                updatable.Update(Time.deltaTime);

            OnUpdate();
        }

        public void AttachPresenter(Presenter presenter)
        {
            Presenter = presenter;
        }

        protected virtual void OnUpdate()
        {
        }
    }
}