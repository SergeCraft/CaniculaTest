using UnityEngine;
using Zenject;

namespace SampleGameObject
{
    public class GameObjectViewBase : MonoBehaviour
    {
        public object SampleProperty { get; private set; }

        [Inject]
        public void Construct(SignalBus _signalBus, InitArgs args)
        {
            SampleProperty = args.SampleProperty;
        }

        public class Factory : PlaceholderFactory<InitArgs, GameObjectViewBase>
        {
            
        }

        public class InitArgs
        {
            public object SampleProperty { get; }

            public InitArgs( object sampleProperty)
            {
                SampleProperty = sampleProperty;
            }
        }
    }
}