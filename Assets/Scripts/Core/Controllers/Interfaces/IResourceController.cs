using Dto;
using Interfaces;

namespace Core.Controllers.Interfaces
{
    public interface IResourceController : Controller
    {
        HarvestActionDto HarvestResource(float value);
    }
}