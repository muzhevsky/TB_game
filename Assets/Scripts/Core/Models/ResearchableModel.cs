using System;
using System.IO;
using DefaultNamespace;
using ScriptableObjects;

namespace Internal.Models
{
    public class ResearchableModel : Model
    {
        private float _researchProgress;
        private float _researchNeed;
        
        private ResearchableConfig _researchConfig;

        private ResearchableType _researchableType;

        public event Action<float> OnResearchValueChanged;

        public ResearchableConfig ResearchConfig
        {
            get => _researchConfig;
            set
            {
                if (value == null) throw new InvalidDataException("ResearchableConfig can not be null");
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
                if (value <= 0) throw new InvalidDataException("ResearchProgress should be greater then 0");
                _researchProgress = value;
                OnResearchValueChanged?.Invoke(value);
            }
        }

        public float ResearchNeed
        {
            get => _researchNeed;
            set
            {
                if (value <= 0) throw new InvalidDataException("ResearchNeed should be greater then 0");
                _researchNeed = value;
            }
        }
    }
}