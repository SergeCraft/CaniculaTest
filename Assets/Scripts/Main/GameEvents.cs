using UnityEngine;

namespace Main
{
    public class CreatePlaceableRequestSignal
    {
        public Vector2 InitialPosition { get; private set; }
        public GameObject ParentRegion { get; private set; }

        public CreatePlaceableRequestSignal(Vector2 initposition, GameObject parent)
        {
            InitialPosition = initposition;
            ParentRegion = parent;
        }
    }
}