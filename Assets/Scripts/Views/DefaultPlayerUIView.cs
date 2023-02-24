using Internal.Controllers;
using Views.Interfaces;

namespace Views
{
    public class DefaultPlayerUIView : IPlayerUIView
    {
        public void InitUIController(IPlayerUIController controller)
        {
            controller.Init(this);
        }

        public void DrawHP(float value)
        {
            throw new System.NotImplementedException();
        }

        public void DrawBoosterCap(float value)
        {
            throw new System.NotImplementedException();
        }
    }
}