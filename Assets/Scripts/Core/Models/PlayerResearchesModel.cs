using System;
using System.Collections.Generic;
using System.IO;
using Core.Views.Interfaces;
using Dto;
using Enums;
using Interfaces;
using MonoBehaviours;
using ScriptableObjects.Resources;
using UnityEngine;

namespace Core.Models
{
    public class PlayerResearchesModel : Model
    {
        private HashSet<ResearchableType> _researched = new HashSet<ResearchableType>();
        private ResearchableConfig _config;

        public PlayerResearchesModel()
        {
            GlobalEventManager.OnResearchEnd += AddResearchedResource;
        }

        public event Action OnResearchNeedEvent;
        
        
        public ResearchableConfig Config
        {
            get => _config;
            set
            {
                if (value == null) throw new ArgumentException ("Config can not be null");
                _config = value;
            }
        }

        public void AddResearchedResource(ResearchableDto dto)
        {
            _researched.Add(dto.Type);
        }

        public bool IsResearched(ResearchableType type)
        {
            return _researched.Contains(type);
        }

        public void OnResearchNeed()
        {
            OnResearchNeedEvent?.Invoke();
        }
    }
}