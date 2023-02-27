using System;
using Core.Controllers.Ship;
using Core.Models;
using Core.Views;
using UnityEngine;

namespace Initialisers
{
    public class ShipInitialiser : MonoBehaviour, IInitialiser
    {
        private void Start()
        {
            Init();
        }

        public void Init()
        {
            ShipRepairModel shipRepairModel = new ShipRepairModel();

            ShipRepairController shipRepairController = new ShipRepairController(shipRepairModel);

            ShipRepairView shipRepairView = (ShipRepairView)gameObject.AddComponent(typeof(ShipRepairView));
            shipRepairView.InitShipRepairController(shipRepairController);
        }
    }
}