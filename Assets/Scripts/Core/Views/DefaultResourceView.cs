using System;
using DefaultNamespace;
using Internal.Controllers;
using Internal.Views.Interfaces;
using UnityEngine;

namespace Views
{
    public class DefaultResourceView : MonoBehaviour, IResourceView
    {
        private IResourceController _resourceController;

        public void InitResourceController(IResourceController resourceController)
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