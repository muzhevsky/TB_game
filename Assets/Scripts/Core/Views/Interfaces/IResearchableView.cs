using Core.Controllers.Interfaces;
using Dto;
using Enums;

namespace Core.Views.Interfaces
{
    public interface IResearchableView
    {
        void Init(IResearchableController controller);
        ResearchActionDto Research(float value);
        void Visualize(float value);
    }
}