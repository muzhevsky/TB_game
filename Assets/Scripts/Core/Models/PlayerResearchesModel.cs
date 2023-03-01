using System;
using System.Collections.Generic;
using Dto;
using Enums;
using Interfaces;
using ScriptableObjects.Resources;

namespace Core.Models
{
    public class PlayerResearchesModel : Model
    {
        private ResearchableConfig _config;
        private readonly HashSet<ResearchableType> _researched = new();


        public ResearchableConfig Config
        {
            get => _config;
            set
            {
                if (value == null) throw new ArgumentException("Config can not be null");
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
    }
}