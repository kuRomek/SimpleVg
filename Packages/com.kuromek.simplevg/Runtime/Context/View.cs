using UnityEngine;

namespace kuRomek.SimpleVG
{
    public class View : MonoBehaviour
    {
        private Presenter _presenter;

        private void Update()
        {
            if (_presenter is IUpdatable updatable)
                updatable.Update(Time.deltaTime);

            OnUpdate();
        }

        public void AttachPresenter(Presenter presenter)
        {
            _presenter = presenter;
        }

        protected virtual void OnUpdate()
        {
        }
    }
}