using Core.Controllers.Interfaces;
using Enums;

namespace Core.Views.Interfaces
{
    public interface IResearchableView
    {
        void Init(IResearchableController controller);
        bool Research(float value);
        void Visualize(float value);
        ResearchableType GetResearchableType();
    }
}