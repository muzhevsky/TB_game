using System;
using System.Collections.Generic;
using System.IO;
using Core.Controllers;
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
        private PlayerInventoryController _controller;

        [SerializeField] private InventoryWindow _window;

        public InventoryWindow Window
        {
            get => _window;
            set
            {
                if (value == null) throw new ArgumentException ("Window cannot be null");
                _window = value;
            }
        }

        public void InitInventoryController(PlayerInventoryController controller)
        {
            _controller = controller;
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                _window.gameObject.SetActive(!_window.gameObject.activeSelf);
                
                if (_window.gameObject.activeSelf)
                {
                    _window.SetupInventory(_controller.GetInventoryData());
                    GameStateController.Pause();
                }
                else GameStateController.Unpause();
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
    }
}