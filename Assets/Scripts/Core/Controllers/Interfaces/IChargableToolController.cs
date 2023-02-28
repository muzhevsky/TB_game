using System;
using Unity.VisualScripting;

namespace Core.Controllers.Interfaces
{
    public interface IChargableToolController
    {
        void ChargeBattery(float value);
        event Action<float> OnBatteryChange;
    }
}