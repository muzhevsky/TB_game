using System;
using System.Collections.Generic;
using System.IO;
using Core.Controllers.Ship;
using Core.Views.Interfaces;
using Enums;
using Interfaces;
using UnityEngine;

namespace Core.Views
{
    public class ShipRepairView : View, IInteractableView
    {
        private ShipRepairController _controller;

        public void InitShipRepairController(ShipRepairController controller)
        {
            if (controller == null) throw new ArgumentException("");
        }
        
        public void Interact(GameObject interactCaller)
        {
            _controller.TryToRepair(interactCaller);
        }
    }
}