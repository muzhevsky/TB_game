﻿using Core.Models;
using Enums;
using UnityEngine;

namespace ScriptableObjects.Resources
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
            result.ValueLeft = _startValue + Random.Range(-0.2f * _startValue, 0.2f * _startValue);
            return result;
        }
    }
}