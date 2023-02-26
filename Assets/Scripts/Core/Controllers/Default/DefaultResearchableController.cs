using Core.Controllers.Interfaces;
using Core.Models;
using Core.Views.Interfaces;
using Enums;
using MonoBehaviours;

namespace Core.Controllers.Default
{
    public class DefaultResearchableController : IResearchableController
    {
        private ResearchableModel _researchableModel;

        public DefaultResearchableController(ResearchableModel researchableModel)
        {
            _researchableModel = researchableModel;
            _researchableModel.OnResearchValueChanged += OnResearchValueChanged;
        }

        public bool Research(float value)
        {
            if (_researchableModel.ResearchProgress >= _researchableModel.ResearchNeed) return false;
            _researchableModel.ResearchProgress += value;
            return true;
        }

        public ResearchableType GetResearchableType()
        {
            return _researchableModel.ResearchableType;
        }

        public void OnResearchValueChanged(float value)
        {
            if (value >= _researchableModel.ResearchNeed)
                GlobalEventManager.InvokeOnResearchEnd(_researchableModel.ResearchableType);
        }
    }
}