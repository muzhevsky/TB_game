using System;

namespace Core.Controllers.Interfaces
{
    public interface IChargableToolController
    {
        void ChargeBattery(float value);
        event Action<float> OnBatteryChange;
    }
}