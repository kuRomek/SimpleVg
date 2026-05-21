using UnityEngine;

namespace kuRomek.SimpleVG
{
    public static class ContextLoaderInternal
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Load()
        {
            Utils.InstallerLoader.Load<AudioPlayer>(nameof(AudioPlayer));
            Utils.InstallerLoader.Load<GlobalVolumeInstaller>(nameof(GlobalVolumeInstaller));
            Utils.InstallerLoader.Load<EventSystemInstaller>(nameof(EventSystemInstaller));
            Utils.InstallerLoader.Load<ConfigsInstaller>(nameof(ConfigsInstaller));
            Utils.InstallerLoader.Load<InputController>(nameof(InputController));
        }
    }
}