using UnityEngine;

public class EventSystemInstaller : Installer
{
    private static EventSystemInstaller _instance;

    protected override void Install()
    {
        if (_instance != null)
        {
            Debug.LogError($"Multiple instances of {nameof(EventSystemInstaller)} detected. Leaving the last instantiated one.");
            Destroy(_instance.gameObject);
        }

        _instance = this;

        _instance.gameObject.name = nameof(EventSystemInstaller);
    }
}
