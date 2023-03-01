using Core.Views.Interfaces;

namespace Core.Controllers.Interfaces
{
    public interface IBatteryChargerController
    {
        void Charge(IChargableToolView view);
        void StopCharge(IChargableToolView view);
    }
}