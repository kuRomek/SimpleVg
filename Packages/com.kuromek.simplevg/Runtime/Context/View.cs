using UnityEngine;

namespace kuRomek.SimpleVG
{
    public abstract class View : MonoBehaviour
    {
        private Presenter _presenter;

        protected abstract Presenter CreatePresenter();

        private void Awake()
        {
            _presenter = CreatePresenter();
            OnAwake();
        }

        private void Update()
        {
            _presenter.Update(Time.deltaTime);
            OnUpdate();
        }

        protected virtual void OnAwake()
        {
        }

        protected virtual void OnUpdate()
        {
        }
    }
}