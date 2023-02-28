using Core.Controllers.Interfaces;
using Dto;
using Enums;

namespace Core.Views.Interfaces
{
    public interface IResourceView
    {
        void Init(IResourceController resourceController);
        HarvestActionDto OnHarvest(float value);
    }
}