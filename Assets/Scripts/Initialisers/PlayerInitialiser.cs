using System;
using System.IO;
using Core.Controllers;
using Core.Controllers.Default;
using Core.Controllers.Interfaces;
using Core.Controllers.Player;
using Core.Models;
using Core.Utils;
using Core.Views;
using MonoBehaviours;
using ScriptableObjects.Player;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Initialisers
{
    public class PlayerInitialiser : MonoBehaviour, IInitialiser
    {
        [Header("Config")]
        [SerializeField] private PlayerDefaultStateConfig _stateConfig;
    
        [Header("UI elements")]
        [SerializeField] private Image _hpBar;
        [SerializeField] private Image _boosterBar;
        [SerializeField] private Image _batteryBar;
        [SerializeField] private Text _warningText;
        [FormerlySerializedAs("_alertView")] [SerializeField] private Alert alert;
        [SerializeField] private InventoryWindow _inventoryWindow;

        public InventoryWindow InventoryWindow
        {
            get => _inventoryWindow;
            set
            {
                if (value == null) throw new ArgumentException ("InventoryWindow can not be null");
                _inventoryWindow = value;
            }
        }

        public Image BoosterBar
        {
            get => _boosterBar;
            set
            {
                if (value == null) throw new ArgumentException ("BoosterBar can not be null");
                _boosterBar = value;
            }
        }

        public Image HpBar
        {
            get => _hpBar;
            set
            {
                if (value == null) throw new ArgumentException ("HpBar can not be null");
                _hpBar = value;
            } 
        }
    
        public Image BatteryBar
        {
            get => _batteryBar;
            set
            {
                if (value == null) throw new ArgumentException ("BatteryBar can not be null");
                _batteryBar = value;
            }
        }
    
        public Text WarningText
        {
            get => _warningText;
            set
            {
                if (value == null) throw new ArgumentException ("WarningText can not be null");
                _warningText = value;
            }
        }

        public Alert Alert
        {
            get => alert;
            set
            {
                if (value == null) throw new ArgumentException ("Alert can not be null");
                alert = value;
            }
        }

        public void Init()
        {
            // models
            PlayerComponentsModel objectComponentsModel = new PlayerComponentsModel();
            objectComponentsModel.GameObject = gameObject;
            objectComponentsModel.Rigidbody = GetComponent<Rigidbody>();
            objectComponentsModel.Transform = transform;
            objectComponentsModel.Camera = Camera.main;
        
            PlayerSettingsModel playerSettingsModel = new PlayerSettingsModel();
            playerSettingsModel.MouseSensitivity = 5f;
        
            PlayerModel playerModel = _stateConfig.GetPlayerStatsModel();
            PlayerToolModel playerToolModel = _stateConfig.GetPlayerToolModel();
            PlayerResearchesModel playerResearchesModel = new PlayerResearchesModel();
            InventoryModel inventoryModel = new InventoryModel();
        
            // controllers
            IJumpController jumpController = new PlayerJumpController(new DefaultJumpController(objectComponentsModel), playerModel);
            IMoveController moveController = new PlayerMoveController(new DefaultMoveController(objectComponentsModel, playerModel), objectComponentsModel);
            IRotationController rotationController = new PlayerRotationController(new DefaultRotationController(objectComponentsModel), objectComponentsModel, playerSettingsModel);
            IPlayerToolController toolController = new PlayerToolController(objectComponentsModel, playerToolModel, 
                playerResearchesModel, inventoryModel);
            PlayerInventoryController inventoryController = new PlayerInventoryController(inventoryModel);
            
            IFixedUpdatable hpRecoveryController = new DefaultHpRecoveryController(playerModel);
            IFixedUpdatable boosterRecoveryController = new DefaultBoosterRecoveryController(playerModel);
            Updater.AddFixedUpdatable(hpRecoveryController);
            Updater.AddFixedUpdatable(boosterRecoveryController);
            Updater.StartFixedUpdateAll();
        
            // views
            PlayerMoveInputView moveInputView = (PlayerMoveInputView)gameObject.AddComponent(typeof(PlayerMoveInputView));
            moveInputView.InitMoveController(moveController)
                .InitJumpController(jumpController);
        
            PlayerRotateInputView rotateInputView = (PlayerRotateInputView)gameObject.AddComponent(typeof(PlayerRotateInputView));
            rotateInputView.InitRotateInputView(rotationController);

            DefaultPlayerView playerView = (DefaultPlayerView)gameObject.AddComponent(typeof(DefaultPlayerView));
            playerView.Init(playerModel);
            playerView.SetHPBar(_hpBar)
                .SetBoosterBar(_boosterBar);

            PlayerToolView toolView = (PlayerToolView)gameObject.AddComponent(typeof(PlayerToolView));
            toolView.Init(playerToolModel, playerResearchesModel, toolController);
            toolView.SetBatteryBar(_batteryBar)
                .SetWarningText(_warningText)
                .SetAlertView(alert);

            PlayerInventoryView inventoryView = (PlayerInventoryView)gameObject.AddComponent(typeof(PlayerInventoryView));
            inventoryView.Window = _inventoryWindow;
            inventoryView.InitInventoryController(inventoryController);
        }
    }
}
