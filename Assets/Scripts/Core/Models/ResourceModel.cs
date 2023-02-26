using System;
using Enums;

namespace Core.Models
{
    public class ResourceModel
    {
        private float _valueLeft;
        private ResourceType _resourceType;

        public event Action<float> OnValueLeftChanged; 
        
        public float ValueLeft
        {
            get => _valueLeft;
            set
            {
                _valueLeft = value;
                OnValueLeftChanged?.Invoke(value);
            }
        }

        public ResourceType ResourceType
        {
            get => _resourceType;
            set => _resourceType = value;
        }
    }
}