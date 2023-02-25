using System;
using DefaultNamespace;
using Internal.Controllers;

namespace Views
{
    public class ResourceView : View
    {
        private IResourceController _resourceController;

        public ResourceView(IResourceController resourceController)
        {
            if (resourceController == null) throw new NullReferenceException("resourceController can not be null");
            _resourceController = resourceController;
        }

        public ResourceType GetResourceType()
        {
            return _resourceController.GetResourceType();
        }

        public void OnHarvest(float value)
        {
            _resourceController.SpendResource(value);
        }
    }
}