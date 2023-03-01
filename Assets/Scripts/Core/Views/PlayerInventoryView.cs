using System;
using System.Collections.Generic;
using Core.Controllers;
using Core.Controllers.Interfaces;
using Core.Controllers.Player;
using Core.Views.Interfaces;
using Enums;
using Interfaces;
using MonoBehaviours;
using UnityEngine;

namespace Core.Views
{
    public class PlayerInventoryView : View, IInventoryView
    {
        [SerializeField] private InventoryWindow _window;
        private IInventoryController _controller;

        public InventoryWindow Window
        {
            get => _window;
            set
            {
                if (value == null) throw new ArgumentException("Window cannot be null");
                _window = value;
            }
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                if (!_window.gameObject.activeSelf && GameStateController.UserInputIsLocked) return;
                _window.gameObject.SetActive(!_window.gameObject.activeSelf);

                if (_window.gameObject.activeSelf)
                    _window.SetupInventory(_controller.GetInventoryData());
            }
        }

        public Dictionary<ResourceType, float> GetInventoryData()
        {
            return _controller.GetInventoryData();
        }


        public bool SpendResources(Dictionary<ResourceType, float> amounts)
        {
            return _controller.SpendResource(amounts);
        }

        public void AddResources(Dictionary<ResourceType, float> amounts)
        {
            _controller.AddResources(amounts);
        }

        public void InitInventoryController(PlayerInventoryController controller)
        {
            _controller = controller;
        }
    }
}