using System;
using Enums;
using ScriptableObjects.Resources;

namespace Core.Models
{
    public class ResourceModel
    {
        private float _valueLeft;
        private ResourceType _resourceType;
        private ResourceConfig _config;

        public ResourceConfig Config
        {
            get => _config;
            set
            {
                if (value == null) throw new ArgumentException("config is null");
                _config = value;
            }
        }
        
        public float ValueLeft
        {
            get => _valueLeft;
            set => _valueLeft = value;
        }

        public ResourceType ResourceType
        {
            get => _resourceType;
            set => _resourceType = value;
        }
    }
}