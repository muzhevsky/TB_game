using DefaultNamespace;
using Internal.Controllers;
using Internal.Models;
using UnityEngine;

namespace Views
{
    public class CommonOreView : ResourceView, IReserchable
    {
        private IResourceController _resourceController;
        private IResearchController _researchController;

        public CommonOreView(IResourceController resourceController, IResearchController researchController)
            : base(resourceController)
        {
            _researchController = researchController;
        }

        public ResearchableType? Research(float value)
        {
            // TODO: визуальный эффект
            return _researchController.Research(value);
        }
    }
}