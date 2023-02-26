using Enums;
using Interfaces;

namespace Core.Controllers.Interfaces
{
    public interface IResourceController : Controller
    {
        ResourceType GetResourceType();
        void SpendResource(float value);
    }
}