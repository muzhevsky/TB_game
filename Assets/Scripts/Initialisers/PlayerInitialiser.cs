using System;
using Core.Controllers.Default;
using Core.Controllers.Interfaces;
using Core.Controllers.Player;
using Core.Models;
using Core.Utils;
using Core.Views;
using MonoBehaviours;
using ScriptableObjects.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Initialisers
{
    public class PlayerInitialiser : MonoBehaviour
    {
        [Header("Config")] [SerializeField] private PlayerDefaultStateConfig _stateConfig;

        [Header("UI elements")] [SerializeField]
        private Image _hpBar;

        [SerializeField] private Image _boosterBar;
        [SerializeField] private Image _batteryBar;
        [SerializeField] private WarningText _warningText;
        [SerializeField] private InventoryWindow _inventoryWindow;

        [Header("StartStats")] [SerializeField]
        private float _startHealth;

        [SerializeField] private float _interactionDistance;

        public InventoryWindow InventoryWindow
        {
            get => _inventoryWindow;
            set
            {
                if (value == null) throw new ArgumentException("InventoryWindow can not be null");
                _inventoryWindow = value;
            }
        }

        public Image BoosterBar
        {
            get => _boosterBar;
            set
            {
                if (value == null) throw new ArgumentException("BoosterBar can not be null");
                _boosterBar = value;
            }
        }

        public Image HpBar
        {
            get => _hpBar;
            set
            {
                if (value == null) throw new ArgumentException("HpBar can not be null");
                _hpBar = value;
            }
        }

        public Image BatteryBar
        {
            get => _batteryBar;
            set
            {
                if (value == null) throw new ArgumentException("BatteryBar can not be null");
                _batteryBar = value;
            }
        }

        public WarningText WarningText
        {
            get => _warningText;
            set
            {
                if (value == null) throw new ArgumentException("WarningText can not be null");
                _warningText = value;
            }
        }

        public void Init()
        {
            // models
            var objectComponentsModel = new PlayerComponentsModel();
            objectComponentsModel.GameObject = gameObject;
            objectComponentsModel.Rigidbody = GetComponent<Rigidbody>();
            objectComponentsModel.Transform = transform;
            objectComponentsModel.Camera = Camera.main;

            var playerSettingsModel = new PlayerSettingsModel();
            playerSettingsModel.MouseSensitivity = 5f;

            var playerModel = _stateConfig.GetPlayerStatsModel();
            playerModel.Hp = _startHealth;

            var playerToolModel = _stateConfig.GetPlayerToolModel();

            var playerResearchesModel = new PlayerResearchesModel();
            var inventoryModel = new InventoryModel();

            // controllers
            var jumpController =
                new PlayerJumpController(new DefaultJumpController(objectComponentsModel), playerModel);
            var moveController = new PlayerMoveController(new DefaultMoveController(objectComponentsModel, playerModel),
                objectComponentsModel);
            var rotationController = new PlayerRotationController(new DefaultRotationController(objectComponentsModel),
                objectComponentsModel, playerSettingsModel);
            var toolController = new PlayerToolController(objectComponentsModel, playerToolModel,
                playerResearchesModel, inventoryModel);
            var inventoryController = new PlayerInventoryController(inventoryModel);
            IChargableToolController chargableToolController = toolController;

            IFixedUpdatable hpRecoveryController = new DefaultHpRecoveryController(playerModel);
            IFixedUpdatable boosterRecoveryController = new DefaultBoosterRecoveryController(playerModel);
            Updater.AddFixedUpdatable(hpRecoveryController);
            Updater.AddFixedUpdatable(boosterRecoveryController);
            Updater.StartFixedUpdateAll();

            // views
            var moveInputView = (PlayerMoveInputView)gameObject.AddComponent(typeof(PlayerMoveInputView));
            moveInputView.InitMoveController(moveController)
                .InitJumpController(jumpController);

            var rotateInputView = (PlayerRotateInputView)gameObject.AddComponent(typeof(PlayerRotateInputView));
            rotateInputView.InitRotateInputView(rotationController);

            var playerView = (DefaultPlayerView)gameObject.AddComponent(typeof(DefaultPlayerView));
            playerView.Init(playerModel);
            playerView.SetHPBar(_hpBar)
                .SetBoosterBar(_boosterBar);

            var toolView = (PlayerToolView)gameObject.AddComponent(typeof(PlayerToolView));
            toolView.Init(toolController, chargableToolController);
            toolView.SetBatteryBar(_batteryBar)
                .SetWarningText(_warningText);

            var inventoryView = (PlayerInventoryView)gameObject.AddComponent(typeof(PlayerInventoryView));
            inventoryView.Window = _inventoryWindow;
            inventoryView.InitInventoryController(inventoryController);

            var interactionView = (PlayerInteractionView)gameObject.AddComponent(typeof(PlayerInteractionView));
            interactionView.InteractionDistance = _interactionDistance;
        }
    }
}