using System;
using Core.Controllers.Interfaces;
using Core.Views.Interfaces;
using Interfaces;
using UnityEngine;

namespace Core.Views
{
    public class BatteryChargerView : View
    {
        private IBatteryChargerController _controller;

        private void OnTriggerEnter(Collider other)
        {
            IChargableToolView toolView = null;
            if (other.TryGetComponent(out toolView)) _controller.Charge(toolView);
        }

        private void OnTriggerExit(Collider other)
        {
            IChargableToolView toolView = null;
            if (other.TryGetComponent(out toolView)) _controller.StopCharge(toolView);
        }

        public void InitBatteryChargerController(IBatteryChargerController controller)
        {
            if (controller == null) throw new ArgumentException("controller is null");
            _controller = controller;
        }
    }
}