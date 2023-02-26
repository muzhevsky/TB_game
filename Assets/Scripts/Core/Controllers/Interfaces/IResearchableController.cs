using Enums;

namespace Core.Controllers.Interfaces
{
    public interface IResearchableController
    {
        bool Research(float value);
        ResearchableType GetResearchableType();
    }
}