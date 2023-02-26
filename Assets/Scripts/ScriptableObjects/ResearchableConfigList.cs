using System.Collections.Generic;
using Dto;
using Enums;
using ScriptableObjects.Resources;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ResearchableConfigList")]
    public class ResearchableConfigList : ScriptableObject
    {
        [SerializeField] private List<ResearchableConfig> _configs;

        public ResearchableDto GetDtoByType(ResearchableType type)
        {
            ResearchableDto result = new ResearchableDto();
            foreach (var item in _configs)
            {
                
                if (item.Type == type)
                {
                    result.Sprite = item.DescriptionSprite;
                    result.Text = item.Description;
                    result.Type = item.Type;
                    break;
                }
            }
            return result;
        }
    }
}