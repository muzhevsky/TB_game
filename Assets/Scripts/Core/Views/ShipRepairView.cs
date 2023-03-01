using System;
using Core.Controllers.Ship;
using Core.Views.Interfaces;
using Interfaces;
using MonoBehaviours;
using UnityEngine;

namespace Core.Views
{
    public class ShipRepairView : View, IInteractableView
    {
        private ShipRepairController _controller;
        private RepairWindow _repairWindow;

        public void Interact(GameObject interactCaller)
        {
            if (_repairWindow != null)
                _controller.OnInteraction(interactCaller);
        }

        public void InitShipRepairController(ShipRepairController controller, RepairWindow repairWindow)
        {
            if (controller == null) throw new ArgumentException("ship repair controller is null");
            if (repairWindow == null) throw new ArgumentException("repairWindow in null");

            _repairWindow = repairWindow;
            _controller = controller;
        }

        public void TryToRepair()
        {
            _controller.TryToRepair();
        }
    }
}