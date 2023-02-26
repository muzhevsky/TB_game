using Core.Controllers.Interfaces;
using Enums;

namespace Core.Views.Interfaces
{
    public interface IResourceView
    {
        void Init(IResourceController resourceController);
        ResourceType GetResourceType();
        void OnHarvest(float value);
    }
}