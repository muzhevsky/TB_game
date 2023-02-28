using System.Collections.Generic;
using Enums;

namespace Core.Views.Interfaces
{
    public interface IInventoryView
    {
        bool SpendResources(Dictionary<ResourceType, float> amounts);
        void AddResources(Dictionary<ResourceType, float> amounts);
        Dictionary<ResourceType, float> GetInventoryData();
    }
}