using UnityEngine;

namespace kuRomek.SimpleVG
{
    public class GlobalVolumeInstaller : Installer
    {
        private static GlobalVolumeInstaller _instance;

        protected override void Install()
        {
            if (_instance != null)
            {
                Debug.LogError($"Multiple instances of {nameof(GlobalVolumeInstaller)} detected. Leaving the last instantiated one.");
                Destroy(_instance.gameObject);
            }

            _instance = this;

            _instance.gameObject.name = nameof(GlobalVolumeInstaller);
        }
    }
}