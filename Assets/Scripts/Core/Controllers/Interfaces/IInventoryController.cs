using System.Collections.Generic;
using Enums;

namespace Core.Controllers.Interfaces
{
    public interface IInventoryController
    {
        bool SpendResource(Dictionary<ResourceType, float> amounts);
        void AddResources(Dictionary<ResourceType, float> amounts);
    }
}