using Core.Controllers.Interfaces;
using Core.Models;
using Core.Utils;
using Core.Views;
using Core.Views.Interfaces;
using UnityEngine;

namespace Core.Controllers.Ship
{
    public class BatteryChargerController : IBatteryChargerController, IFixedUpdatable
    {
        private BatteryChargerModel _model;

        private BatteryChargerController()
        {
            
        }

        public BatteryChargerController(BatteryChargerModel model)
        {
            _model = model;
        }

        public void Charge(IChargableToolView view)
        {
            _model.ToolsNearby.AddFirst(view);
        }

        public void StopCharge(IChargableToolView view)
        {
            _model.ToolsNearby.Remove(view);
        }

        public void ActivateFixedUpdate()
        {
            _model.ChargeAvailable = true;
        }

        public void FixedUpdate()
        {
            if (_model.ChargeAvailable)
            {
                foreach (var item in _model.ToolsNearby)
                {
                    item.Charge(_model.Efficiency);
                }
            }
        }

        public void StopFixedUpdate()
        {
            _model.ChargeAvailable = false;
        }
    }
}