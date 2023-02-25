using DefaultNamespace;
using Internal.Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ResourceConfig")]
    public class ResourceConfig : ScriptableObject
    {
        [SerializeField] private ResourceType _type;
        [SerializeField] private float _startValue;
        public ResourceModel GetResourceModel()
        {
            var result = new ResourceModel();
            result.ResourceType = _type;
            result.ValueLeft = _startValue;
            return result;
        }
    }
}