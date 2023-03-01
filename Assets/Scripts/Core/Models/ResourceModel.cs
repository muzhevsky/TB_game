using System;
using Enums;
using ScriptableObjects.Resources;

namespace Core.Models
{
    public class ResourceModel
    {
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

        public float ValueLeft { get; set; }

        public ResourceType ResourceType { get; set; }
    }
}