using System.Collections.Generic;
using Dto;
using Enums;
using ScriptableObjects.Resources;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ResourceConfigList")]
    public class ResourceConfigList : ScriptableObject
    {
        [SerializeField] private List<ResourceConfig> _configs;

        public ResourceDto GetDtoByType(ResourceType type)
        {
            var result = new ResourceDto();
            foreach (var item in _configs)
                if (item.Type == type)
                {
                    result.Config = item;
                    result.Type = item.Type;
                    break;
                }

            return result;
        }
    }
}