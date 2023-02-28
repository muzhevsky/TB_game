using Core.Controllers.Interfaces;
using Core.Models;
using Core.Utils;
using Core.Views.Interfaces;
using Dto;
using Enums;
using MonoBehaviours;
using ScriptableObjects.Resources;
using UnityEngine;

namespace Core.Controllers.Default
{
    public class DefaultResearchableController : IResearchableController
    {
        private ResearchableModel _researchableModel;

        public DefaultResearchableController(ResearchableModel researchableModel)
        {
            _researchableModel = researchableModel;
        }

        private DefaultResearchableController()
        {
        }

        public ResearchActionDto Research(float value)
        {
            ResearchActionDto result = new ResearchActionDto();
            ResearchableDto researchableDto = new ResearchableDto();
            researchableDto.Type = _researchableModel.ResearchableType;
            researchableDto.Config = _researchableModel.ResearchConfig;
            result.ResearchableData = researchableDto;
            
            if (_researchableModel.ResearchProgress >= _researchableModel.ResearchNeed)
            {
                result.IsSucceed = false;
                result.IsFinished = false;
                return result;
            }
            
            _researchableModel.ResearchProgress += value;
            result.IsSucceed = true;
            if (_researchableModel.ResearchProgress >= _researchableModel.ResearchNeed)
                result.IsFinished = true;
            
            return result;
        }

        public ResearchableType GetResearchableType()
        {
            return _researchableModel.ResearchableType;
        }
    }
}