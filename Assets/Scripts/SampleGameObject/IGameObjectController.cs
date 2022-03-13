using Zenject;

namespace SampleGameObject
{
    public interface IGameObjectController
    {
        object SampleProperty { get; }

        void Construct(SignalBus signalBus, object sampleProperty);
    }
}