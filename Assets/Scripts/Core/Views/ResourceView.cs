using System;
using Core.Controllers.Interfaces;
using Core.Views.Interfaces;
using Dto;
using UnityEngine;

namespace Core.Views
{
    public class DefaultResourceView : MonoBehaviour, IResourceView
    {
        private IResourceController _resourceController;

        public void Init(IResourceController resourceController)
        {
            if (resourceController == null) throw new NullReferenceException("resourceController can not be null");
            _resourceController = resourceController;
        }

        public HarvestActionDto OnHarvest(float value)
        {
            return _resourceController.HarvestResource(value);
        }
    }
}