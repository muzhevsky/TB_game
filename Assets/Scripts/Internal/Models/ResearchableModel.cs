using System;
using System.IO;
using DefaultNamespace;

namespace Internal.Models
{
    public class ResearchableModel : Model
    {
        private float _researchProgress;
        private float _researchNeed;
        
        private ResearchableType _researchableType;

        public event Action OnResearchDone;
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
                
                if (_researchProgress >= _researchNeed) OnResearchDone?.Invoke();
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