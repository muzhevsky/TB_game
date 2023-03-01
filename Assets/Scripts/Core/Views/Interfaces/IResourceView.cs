using Core.Controllers.Interfaces;
using Dto;

namespace Core.Views.Interfaces
{
    public interface IResourceView
    {
        void Init(IResourceController resourceController);
        HarvestActionDto OnHarvest(float value);
    }
}