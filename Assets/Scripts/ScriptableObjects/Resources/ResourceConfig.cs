using Core.Models;
using Enums;
using UnityEngine;

namespace ScriptableObjects.Resources
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ResourceConfig")]
    public class ResourceConfig : ScriptableObject
    {
        [SerializeField] private ResourceType _type;
        [SerializeField] private float _startValue;
        [SerializeField] private string _title;

        public string Title
        {
            get => _title;
            private set => _title = value;
        }

        public ResourceType Type
        {
            get => _type;
            private set => _type = value;
        }

        public float StartValue
        {
            get => _startValue;
            private set => _startValue = value;
        }

        public ResourceModel GetResourceModel()
        {
            var result = new ResourceModel();
            result.ResourceType = _type;
            result.ValueLeft = _startValue + Random.Range(-0.2f * _startValue, 0.2f * _startValue);
            return result;
        }
    }
}