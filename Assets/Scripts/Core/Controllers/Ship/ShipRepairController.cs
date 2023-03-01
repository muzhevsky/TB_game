using System;
using System.Collections.Generic;
using Core.Controllers.Interfaces;
using Core.Models;
using Core.Views.Interfaces;
using Dto;
using Enums;
using MonoBehaviours;
using ScriptableObjects;
using UnityEngine;

namespace Core.Controllers.Ship
{
    public class ShipRepairController : IInveractionController
    {
        private IInventoryView _cachedCaller;
        private readonly ResourceConfigList _configs;
        private readonly ShipRepairModel _model;
        private readonly RepairWindow _repairWindow;
        private WarningText _warningText;

        public ShipRepairController(ShipRepairModel model, RepairWindow repairWindow, ResourceConfigList configs)
        {
            if (model == null) throw new ArgumentException("model is null");
            if (repairWindow == null) throw new ArgumentException("repairWindow is null");
            if (configs == null) throw new ArgumentException("configs is null");

            _configs = configs;
            _model = model;
            _repairWindow = repairWindow;
            _model.OnReadyToFly += () => { GameStateController.PlayerWins(); };
        }

        public void OnInteraction(GameObject obj)
        {
            _cachedCaller = (IInventoryView)obj.GetComponent(typeof(IInventoryView));
            if (_cachedCaller == null) return;

            UpdateRepairWindow(_cachedCaller);
        }

        public void TryToRepair()
        {
            var inventory = _cachedCaller.GetInventoryData();
            var resourcesToSpend = _model.TryToRepair(inventory);
            if (resourcesToSpend != null) _cachedCaller.SpendResources(resourcesToSpend);

            if (_model.ReadyToFly) return;
            UpdateRepairWindow(_cachedCaller);
        }

        private List<RepairViewDto> GetRepairViewDto(Dictionary<ResourceType, float> inventory,
            Dictionary<ResourceType, float> resourceToSpend)
        {
            var datas = new List<RepairViewDto>();
            foreach (var item in resourceToSpend.Keys)
            {
                var newDto = new RepairViewDto();
                var resource = _configs.GetDtoByType(item);
                newDto.Title = resource.Config.Title;

                var availableAmount = "0";
                if (inventory.ContainsKey(item)) availableAmount = inventory[item].ToString();
                newDto.Availability = availableAmount + "/" + resourceToSpend[item];

                datas.Add(newDto);
            }

            return datas;
        }

        private void UpdateRepairWindow(IInventoryView view)
        {
            var inventory = view.GetInventoryData();
            var datas = GetRepairViewDto(inventory, _model.GetResourceAmount());
            _repairWindow.gameObject.SetActive(true);
            _repairWindow.DisplayResources(datas);
        }
    }
}