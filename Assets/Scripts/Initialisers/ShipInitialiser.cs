using System;
using Core.Controllers.Ship;
using Core.Models;
using Core.Utils;
using Core.Views;
using MonoBehaviours;
using Unity.VisualScripting;
using UnityEngine;

namespace Initialisers
{
    public class ShipInitialiser : MonoBehaviour, IInitialiser
    {
        [SerializeField] private WarningText _warningText;
        private void Start()
        {
            Init();
        }

        public void Init()
        {
            // models
            ShipRepairModel shipRepairModel = new ShipRepairModel();

            //controllers
            ShipRepairController shipRepairController = new ShipRepairController(shipRepairModel, _warningText);
            
            //views
            ShipRepairView shipRepairView = (ShipRepairView)gameObject.AddComponent(typeof(ShipRepairView));
            shipRepairView.InitShipRepairController(shipRepairController);
        }
    }
}