using Internal.Controllers;

namespace DefaultNamespace
{
    public interface IResearchableView
    {
        void InitResearchableController(IResearchableController controller);
        void Research(float value);
        void Visualize(float value);
    }
}