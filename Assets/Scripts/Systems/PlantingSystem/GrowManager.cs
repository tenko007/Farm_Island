using System.Collections.Generic;

namespace Systems.PlantingSystem
{
    public class GrowManager : IGrowManager
    {
        public List<IFarm> Farms { get; private set; }
    }
}