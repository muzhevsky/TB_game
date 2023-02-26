using Core.Controllers.Interfaces;
using Core.Models;
using Enums;
using UnityEngine;

namespace Core.Controllers.Default
{
    public class DefaultResourceController : IResourceController
    {
        private ResourceModel _resourceModel;
        private ObjectComponentsModel _objectComponentsModel;

        public DefaultResourceController(ResourceModel resourceModel, ObjectComponentsModel objectComponentModel)
        {
            _objectComponentsModel = objectComponentModel;
            _resourceModel = resourceModel;
            _resourceModel.OnValueLeftChanged += OnResourceValueChanged;
        }

        public ResourceType GetResourceType()
        {
            return _resourceModel.ResourceType;
        }

        public void SpendResource(float value)
        {
            _resourceModel.ValueLeft -= value;
        }

        public void OnResourceValueChanged(float value)
        {
            //TODO: визуальный эффект
            if (value <= 0)
                GameObject.Destroy(_objectComponentsModel.GameObject);
        }
    }
}