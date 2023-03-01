using System.Collections.Generic;
using Core.Utils;
using Enums;
using ScriptableObjects;
using UnityEngine;

namespace MonoBehaviours
{
    public class InventoryWindow : PausableBehaviour
    {
        [SerializeField] private ResourceConfigList _configs;
        [SerializeField] private GameObject _inventoryItemViewPrefab;
        [SerializeField] private List<GameObject> _content;

        private void OnEnable()
        {
            OnPauseInvoke();
        }

        private void OnDisable()
        {
            OnUnpauseInvoke();
        }

        public void SetupInventory(Dictionary<ResourceType, float> inventory)
        {
            while (_content.Count > 0)
            {
                var last = _content.Count - 1;
                Destroy(_content[last]);
                _content.RemoveAt(last);
            }

            foreach (var key in inventory.Keys)
            {
                var item = Instantiate(_inventoryItemViewPrefab, transform).GetComponent<InventoryItem>();
                item.Init(_configs.GetDtoByType(key).Config.Title, inventory[key].ToString());
                _content.Add(item.gameObject);
            }
        }
    }
}