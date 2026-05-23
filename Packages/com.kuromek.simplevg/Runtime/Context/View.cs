using UnityEngine;

namespace kuRomek.SimpleVG
{
    public class View : MonoBehaviour
    {
        private Presenter _presenter;

        private void Update()
        {
            _presenter.Update(Time.deltaTime);
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