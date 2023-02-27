using System;
using System.Collections.Generic;
using System.IO;
using Core.Models;
using Core.Views.Interfaces;
using Enums;
using UnityEngine;

namespace Core.Controllers.Ship
{
    public class ShipRepairController
    {
        private ShipRepairModel _model;

        public ShipRepairController(ShipRepairModel model)
        {
            if (model == null) throw new ArgumentException ("model is null");
            _model = model;
        }

        public void TryToRepair(GameObject obj)
        {
            IInventoryView view = null;
            if (!obj.TryGetComponent<IInventoryView>(out view)) return;
            
            var resourcesToSpend = _model.TryToRepair(view.GetInventoryData());

            if (resourcesToSpend != null) view.SpendResources(resourcesToSpend);
        }
    }
}