using UnityEngine;
using Zenject;

namespace SampleGameObject
{
    public class SampleGameObjectView : GameObjectViewBase
    {
        public class Factory : PlaceholderFactory<InitArgs, SampleGameObjectView>{}
    }
}