using UnityEngine;

namespace kuRomek.SimpleVG
{
    public class Model
    {
        public Transform Transform { get; }

        public Model(Transform transform)
        {
            Transform = transform;
        }
    }
}
