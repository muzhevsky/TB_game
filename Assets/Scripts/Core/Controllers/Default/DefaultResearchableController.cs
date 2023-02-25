using DefaultNamespace;
using Internal.Models;
using Views.Interfaces;

namespace Internal.Controllers
{
    public class DefaultResearchableController : IResearchableController
    {
        private ResearchableModel _researchableModel;
        private IResearchableView _researchableView;

        public DefaultResearchableController(ResearchableModel researchableModel)
        {
            _researchableModel = researchableModel;
        }

        public void InitReserchableView(IResearchableView view)
        {
            _researchableView = view;
            _researchableModel.OnResearchValueChanged += OnResearchValueChanged;
        }

        public void Research(float value)
        {
            _researchableModel.ResearchProgress += value;
        }

        public void OnResearchValueChanged(float value)
        {
            if (value >= _researchableModel.ResearchNeed)
                GlobalEventManager.InvokeOnResearchEnd(_researchableModel.ResearchConfig);
        }
    }
}