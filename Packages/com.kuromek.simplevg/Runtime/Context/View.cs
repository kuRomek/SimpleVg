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

        private void LateUpdate()
        {
            if (Presenter is ILateUpdatable lateUpdatable)
                lateUpdatable.LateUpdate(Time.deltaTime);

            OnLateUpdate();
        }

        private void FixedUpdate()
        {
            if (Presenter is IFixedUpdatable fixedUpdatable)
                fixedUpdatable.FixedUpdate(Time.fixedDeltaTime);

            OnFixedUpdate();
        }

        public void AttachPresenter(Presenter presenter)
        {
            Presenter = presenter;
        }

        protected virtual void OnUpdate()
        {
        }

        protected virtual void OnLateUpdate()
        {
        }

        protected virtual void OnFixedUpdate()
        {
        }
    }
}