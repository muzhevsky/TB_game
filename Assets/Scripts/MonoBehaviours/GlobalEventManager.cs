using System;
using System.IO;
using Dto;
using Enums;
using ScriptableObjects;
using ScriptableObjects.Resources;
using UnityEngine;

namespace MonoBehaviours
{
    public static class GlobalEventManager
    {
        private static ResearchableConfigList _researchableConfigList;

        public static void Init(ResearchableConfigList list)
        {
            if (list == null) throw new InvalidDataException("list can not be null");
            _researchableConfigList = list;
        }
        public static event Action<ResearchableDto> OnResearchEnd;

        public static void InvokeOnResearchEnd(ResearchableType type)
        {
            OnResearchEnd?.Invoke(_researchableConfigList.GetDtoByType(type));
        }
    }
}