using System.Collections.Generic;
using Config;

namespace Placeables
{
    public interface IPlaceableManager
    {
        List<IPlaceableController> PlacedObjects { get; }
        
        GameConfig Config { get; }
    }
}