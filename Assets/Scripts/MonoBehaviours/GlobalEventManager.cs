using System;
using Dto;
using Internal.Models;
using ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace
{
    public class GlobalEventManager : MonoBehaviour
    {
        public static event Action<TipDto> OnResearchEnd;

        public static void InvokeOnResearchEnd(ResearchableConfig config)
        {
            OnResearchEnd?.Invoke(new TipDto()
            {
                Sprite = config.DescriptionSprite,
                Text = config.Description
            });
        }
    }
}