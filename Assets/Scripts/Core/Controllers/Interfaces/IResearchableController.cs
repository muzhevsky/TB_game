using Dto;

namespace Core.Controllers.Interfaces
{
    public interface IResearchableController
    {
        ResearchActionDto Research(float value);
    }
}