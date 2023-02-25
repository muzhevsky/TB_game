using DefaultNamespace;
using Internal.Models;

namespace Internal.Controllers
{
    public class DefaultResourceController : IResourceController
    {
        private ResourceModel _resourceModel;
        public ResourceType GetResourceType()
        {
            return _resourceModel.ResourceType;
        }

        public void SpendResource(float value)
        {
            _resourceModel.ValueLeft -= value;
        }
    }
}