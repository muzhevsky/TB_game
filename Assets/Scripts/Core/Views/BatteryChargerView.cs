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
        public void InitBatteryChargerController(IBatteryChargerController controller)
        {
            if (controller == null) throw new ArgumentException("controller is null");
            _controller = controller;
        }

        void OnTriggerEnter(Collider other)
        {
            IChargableToolView toolView = null;
            if (other.TryGetComponent<IChargableToolView>(out toolView))
            {
                _controller.Charge(toolView);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            IChargableToolView toolView = null;
            if (other.TryGetComponent<IChargableToolView>(out toolView))
            {
                _controller.StopCharge(toolView);
            }
        }
    }
}