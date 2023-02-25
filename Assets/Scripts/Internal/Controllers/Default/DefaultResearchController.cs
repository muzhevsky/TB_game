using DefaultNamespace;
using Internal.Models;
using Views.Interfaces;

namespace Internal.Controllers
{
    public class DefaultResearchController : IResearchController
    {
        private ResearchableModel _researchableModel;

        public DefaultResearchController(ResearchableModel researchableModel)
        {
            _researchableModel = researchableModel;
        }

        public void Research(float value)
        {
            _researchableModel.ResearchProgress += value;
        }
    }
}