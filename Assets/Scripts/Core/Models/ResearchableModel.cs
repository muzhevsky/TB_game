using System;
using System.IO;
using Enums;
using Interfaces;
using ScriptableObjects.Resources;

namespace Core.Models
{
    public class ResearchableModel : Model
    {
        private float _researchProgress;
        private float _researchNeed;
        
        private ResearchableConfig _researchConfig;

        private ResearchableType _researchableType;

        public ResearchableConfig ResearchConfig
        {
            get => _researchConfig;
            set
            {
                if (value == null) throw new ArgumentException ("ResearchableConfig can not be null");
                _researchConfig = value;
            }
        }

        public ResearchableType ResearchableType
        {
            get => _researchableType;
            set => _researchableType = value;
        }
        public float ResearchProgress
        {
            get => _researchProgress;
            set
            {
                if (value <= 0) throw new ArgumentException ("ResearchProgress should be greater then 0");
                _researchProgress = value;
            }
        }

        public float ResearchNeed
        {
            get => _researchNeed;
            set
            {
                if (value <= 0) throw new ArgumentException ("ResearchNeed should be greater then 0");
                _researchNeed = value;
            }
        }
    }
}