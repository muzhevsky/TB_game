﻿using System.Collections.Generic;
using Enums;

namespace Core.Models
{
    public class InventoryModel
    {
        public Dictionary<ResourceType, float> _inventory = new Dictionary<ResourceType, float>();

        public void AddResource(ResourceType type, float amount)
        {
            if (!_inventory.ContainsKey(type)) _inventory.Add(type, amount);
            else _inventory[type] += amount;
        }

        public bool SpendResources(Dictionary<ResourceType, float> amounts)
        {
            foreach (var item in _inventory.Keys)
            {
                _inventory[item] -= amounts[item];
                if (_inventory[item] < 0)
                {
                    _inventory[item] += amounts[item];
                    return false;
                }
            }

            return true;
        }

        public void AddResources(Dictionary<ResourceType, float> amounts)
        {
            foreach (var item in _inventory.Keys)
            {
                _inventory[item] += amounts[item];
            }
        }

        public Dictionary<ResourceType, float> GetInventoryData()
        {
            return new Dictionary<ResourceType, float>(_inventory);
        }
    }
}