using System.Collections.Generic;
using Enums;

namespace Core.Models
{
    public class InventoryModel
    {
        public Dictionary<ResourceType, float> _inventory = new();

        public void AddResource(ResourceType type, float amount)
        {
            if (!_inventory.ContainsKey(type)) _inventory.Add(type, amount);
            else _inventory[type] += amount;
        }

        public bool SpendResources(Dictionary<ResourceType, float> amounts)
        {
            var newInventory = new Dictionary<ResourceType, float>(_inventory);

            foreach (var item in amounts.Keys)
            {
                if (!_inventory.ContainsKey(item)) return false;
                newInventory[item] -= amounts[item];
                if (newInventory[item] < 0) return false;
            }

            foreach (var item in newInventory.Keys) _inventory[item] = newInventory[item];
            return true;
        }

        public void AddResources(Dictionary<ResourceType, float> amounts)
        {
            foreach (var item in _inventory.Keys) _inventory[item] += amounts[item];
        }

        public Dictionary<ResourceType, float> GetInventoryData()
        {
            return new Dictionary<ResourceType, float>(_inventory);
        }
    }
}