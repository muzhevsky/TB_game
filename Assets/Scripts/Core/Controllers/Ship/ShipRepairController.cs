using System;
using System.Collections.Generic;
using System.IO;
using Core.Models;
using Core.Views.Interfaces;
using Enums;
using MonoBehaviours;
using UnityEngine;

namespace Core.Controllers.Ship
{
    public class ShipRepairController
    {
        private ShipRepairModel _model;
        private WarningText _warningText;

        public ShipRepairController(ShipRepairModel model, WarningText warningText)
        {
            if (model == null) throw new ArgumentException ("model is null");
            if (warningText == null) throw new ArgumentException("warningText is null");
            
            _model = model;
            _warningText = warningText;
        }

        public void TryToRepair(GameObject obj)
        {
            IInventoryView view = null;
            if (obj.TryGetComponent<IInventoryView>(out view))
            {
                var resourcesToSpend = _model.TryToRepair(view.GetInventoryData());
                if (resourcesToSpend != null) view.SpendResources(resourcesToSpend);
                else 
                    _warningText.text = "недостаточно ресурсов";
            }
        }
    }
}