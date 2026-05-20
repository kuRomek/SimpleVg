using UnityEngine;

namespace kuRomek.SimpleVG
{
    public abstract class View : MonoBehaviour
    {
        private Presenter _presenter;

        protected abstract Model CreateModel();

        protected abstract Presenter CreatePresenter(Model model);

        private void Awake()
        {
            _presenter = CreatePresenter(CreateModel());
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