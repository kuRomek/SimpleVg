using UnityEngine;

namespace kuRomek.SimpleVG
{
    public abstract class Installer : MonoBehaviour
    {
        public void Initialize()
        {
            DontDestroyOnLoad(gameObject);
            Install();
        }

        protected abstract void Install();
    }
}