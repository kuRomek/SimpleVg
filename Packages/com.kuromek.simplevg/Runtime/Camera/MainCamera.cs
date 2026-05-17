using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MainCamera : MonoBehaviour
{
    public static MainCamera Instance { get; private set; }
    public static Camera Camera { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(Instance.gameObject);

        Instance = this;

        Camera = GetComponent<Camera>();
    }
}
