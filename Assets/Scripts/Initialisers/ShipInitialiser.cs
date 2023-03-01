using Core.Controllers.Ship;
using Core.Models;
using Core.Views;
using MonoBehaviours;
using ScriptableObjects;
using UnityEngine;

namespace Initialisers
{
    public class ShipInitialiser : MonoBehaviour
    {
        [SerializeField] private ResourceConfigList _configs;
        [SerializeField] private RepairWindow _repairWindow;

        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            // models
            var shipRepairModel = new ShipRepairModel();

            //controllers
            var shipRepairController =
                new ShipRepairController(shipRepairModel, _repairWindow, _configs);

            //views
            var shipRepairView = (ShipRepairView)gameObject.GetComponent(typeof(ShipRepairView));
            shipRepairView.InitShipRepairController(shipRepairController, _repairWindow);
        }
    }
}