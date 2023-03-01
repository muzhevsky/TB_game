using System;
using System.Collections.Generic;
using Core.Controllers.Interfaces;
using Core.Models;
using Enums;
using Interfaces;

namespace Core.Controllers.Player
{
    public class PlayerInventoryController : Controller, IInventoryController
    {
        private readonly InventoryModel _model;

        public PlayerInventoryController(InventoryModel model)
        {
            if (model == null) throw new ArgumentException("model can not be null");
            _model = model;
        }

        private PlayerInventoryController()
        {
        }

        public bool SpendResource(Dictionary<ResourceType, float> amounts)
        {
            return _model.SpendResources(amounts);
        }

        public void AddResources(Dictionary<ResourceType, float> amounts)
        {
            AddResources(amounts);
        }

        public Dictionary<ResourceType, float> GetInventoryData()
        {
            return _model.GetInventoryData();
        }
    }
}