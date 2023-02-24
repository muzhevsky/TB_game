using Internal.Controllers;

namespace Views.Interfaces
{
    public interface IPlayerUIView
    {
        void InitUIController(IPlayerUIController controller);
        void DrawHP(float value);
        void DrawBoosterCap(float value);
    }
}