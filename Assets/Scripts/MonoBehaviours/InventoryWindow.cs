using System.Collections.Generic;
using Enums;
using ScriptableObjects;
using UnityEngine;

namespace MonoBehaviours
{
    public class InventoryWindow : MonoBehaviour
    {
        [SerializeField] private ResourceConfigList _configs;
        [SerializeField] private GameObject _inventoryItemViewPrefab;
        [SerializeField] private List<GameObject> _content;
        public void SetupInventory(Dictionary<ResourceType, float> inventory)
        {
            while(_content.Count > 0)
            {
                int last = _content.Count - 1;
                Destroy(_content[last]);
                _content.RemoveAt(last);
            }
            
            foreach (var key in inventory.Keys)
            {
                InventoryItem item = Instantiate(_inventoryItemViewPrefab, transform).GetComponent<InventoryItem>();
                item.Init(_configs.GetDtoByType(key), inventory[key]);
                _content.Add(item.gameObject);
            }
        }
    }
}