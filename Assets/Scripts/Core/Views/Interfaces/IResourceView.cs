using DefaultNamespace;
using Internal.Controllers;

namespace Internal.Views.Interfaces
{
    public interface IResourceView
    {
        void InitResourceController(IResourceController resourceController);
        ResourceType GetResourceType();
        void OnHarvest(float value);
    }
}