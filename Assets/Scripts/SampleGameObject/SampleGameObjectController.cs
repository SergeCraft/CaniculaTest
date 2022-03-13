using Zenject;

namespace SampleGameObject
{
    public class SampleGameObjectController : IGameObjectController
    {
        public object SampleProperty { get; }
        
        public void Construct(SignalBus signalBus, object sampleProperty)
        {
           
        }
    }
}