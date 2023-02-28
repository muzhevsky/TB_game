using Core.Controllers.Interfaces;
using Core.Models;
using Dto;
using Enums;
using UnityEngine;

namespace Core.Controllers.Default
{
    public class DefaultResourceController : IResourceController
    {
        private ResourceModel _resourceModel;
        private ObjectComponentsModel _objectComponentsModel;

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
            HarvestActionDto result = new HarvestActionDto();
            ResourceDto resourceDto = new ResourceDto();
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