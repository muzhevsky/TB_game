using DefaultNamespace;

namespace Internal.Controllers
{
    public interface IResearchableController
    {
        void InitReserchableView(IResearchableView view);
        void Research(float value);
    }
}