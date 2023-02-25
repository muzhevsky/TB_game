using Views.Interfaces;

namespace Internal.Controllers
{
    public interface IPlayerToolController
    {
        void SecondaryAction();
        void PrimaryAction();
        void InitPlayerToolView(IPlayerToolView view);
    }
}