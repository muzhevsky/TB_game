using System.Collections.Generic;
using Core.Utils;
using Dto;
using UnityEngine;

namespace MonoBehaviours
{
    public class RepairWindow : PausableBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _resourceViewPrefab;
        [SerializeField] private List<GameObject> _content;


        private void OnEnable()
        {
            OnPauseInvoke();
        }

        private void OnDisable()
        {
            OnUnpauseInvoke();
        }

        public void DisplayResources(List<RepairViewDto> datas)
        {
            while (_content.Count > 0)
            {
                var last = _content.Count - 1;
                Destroy(_content[last]);
                _content.RemoveAt(last);
            }

            foreach (var i in datas)
            {
                var item = Instantiate(_resourceViewPrefab, _container).GetComponent<InventoryItem>();
                item.Init(i.Title, i.Availability);
                _content.Add(item.gameObject);
            }
        }
    }
}