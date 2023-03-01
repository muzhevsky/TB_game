using Core.Controllers.Ship;
using Core.Models;
using Core.Utils;
using Core.Views;
using UnityEngine;

namespace Initialisers
{
    public class BatteryChargerInitialiser : MonoBehaviour
    {
        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            var batteryChargerModel = new BatteryChargerModel();
            batteryChargerModel.Efficiency = 1;

            var batteryChargerController = new BatteryChargerController(batteryChargerModel);
            Updater.AddFixedUpdatable(batteryChargerController);
            ((IFixedUpdatable)batteryChargerController).ActivateFixedUpdate();

            var batteryChargerView =
                (BatteryChargerView)gameObject.AddComponent(typeof(BatteryChargerView));
            batteryChargerView.InitBatteryChargerController(batteryChargerController);
        }
    }
}