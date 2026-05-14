using UnityEngine;

public static class Utils
{
    public static class InstallerLoader
    {
        public static I Load<I>(string pathName) where I : Installer
        {
            I installer = Object.Instantiate(Resources.Load<I>(pathName));
            installer.Initialize();
            return installer;
        }
    }
}
