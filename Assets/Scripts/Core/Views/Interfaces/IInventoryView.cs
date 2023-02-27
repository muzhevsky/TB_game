using System.Collections.Generic;
using Enums;

namespace Core.Views.Interfaces
{
    public interface IInventoryView
    {
        bool SpendResources(Dictionary<ResourceType, int> amounts);
        void AddResources(Dictionary<ResourceType, int> amounts);
        Dictionary<ResourceType, int> GetInventoryData();
    }
}