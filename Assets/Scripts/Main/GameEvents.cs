using SampleGameObject;

namespace Main
{
    public class SampleObjectChangedSignal
    {
        public IGameObjectController GameObjectController { get; private set; }

        public SampleObjectChangedSignal(IGameObjectController gameObjectController)
        {
            GameObjectController = gameObjectController;
        }
    }
}