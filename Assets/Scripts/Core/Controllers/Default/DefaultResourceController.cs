using Core.Controllers.Interfaces;
using Core.Models;
using Dto;

namespace Core.Controllers.Default
{
    public class DefaultResourceController : IResourceController
    {
        private ObjectComponentsModel _objectComponentsModel;
        private readonly ResourceModel _resourceModel;

        private DefaultResourceController()
        {
        }

        public DefaultResourceController(ResourceModel resourceModel, ObjectComponentsModel objectComponentModel)
        {
            _objectComponentsModel = objectComponentModel;
            _resourceModel = resourceModel;
        }


        public HarvestActionDto HarvestResource(float value)
        {
            var result = new HarvestActionDto();
            var resourceDto = new ResourceDto();
            resourceDto.Type = _resourceModel.ResourceType;
            resourceDto.Config = _resourceModel.Config;
            result.ResourceDto = resourceDto;

            if (_resourceModel.ValueLeft <= 0)
            {
                result.IsSucceed = false;
                result.IsFinished = false;
                return result;
            }

            _resourceModel.ValueLeft -= value;
            result.IsSucceed = true;
            if (_resourceModel.ValueLeft <= 0)
                result.IsFinished = true;

            return result;
        }
    }
}