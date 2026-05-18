using UnityEngine;

namespace kuRomek.SimpleVG
{
    public class Model
    {
        private readonly Transform _transform;

        protected Transform Transform => _transform;

        public Model(Transform transform)
        {
            _transform = transform;
        }
    }
}
