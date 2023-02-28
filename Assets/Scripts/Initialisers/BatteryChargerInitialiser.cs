using System;
using Core.Controllers.Ship;
using Core.Models;
using Core.Utils;
using Core.Views;
using UnityEngine;

namespace Initialisers
{
    public class BatteryChargerInitialiser : MonoBehaviour, IInitialiser
    {
        private void Start()
        {
            Init();
        }

        public void Init()
        {
            BatteryChargerModel batteryChargerModel = new BatteryChargerModel();
            batteryChargerModel.Efficiency = 1;
            
            BatteryChargerController batteryChargerController = new BatteryChargerController(batteryChargerModel);
            Updater.AddFixedUpdatable(batteryChargerController);
            ((IFixedUpdatable)(batteryChargerController)).ActivateFixedUpdate();
            
            BatteryChargerView batteryChargerView = 
                (BatteryChargerView)gameObject.AddComponent(typeof(BatteryChargerView));
            batteryChargerView.InitBatteryChargerController(batteryChargerController);
        }
    }
}