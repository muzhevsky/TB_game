using DefaultNamespace;

namespace Internal.Controllers
{
    public interface IResourceController : Controller
    {
        ResourceType GetResourceType();
        void SpendResource(float value);
    }
}