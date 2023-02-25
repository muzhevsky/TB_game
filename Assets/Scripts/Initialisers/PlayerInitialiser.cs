using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DefaultNamespace.Initialisers;
using DefaultNamespaceasd;
using Internal.Controllers;
using Internal.Models;
using Internal.Utils;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;
using Views;

public class PlayerInitialiser : MonoBehaviour, IInitialiser
{
    [SerializeField] private Image _hpBar;
    [SerializeField] private Image _boosterBar;
    [SerializeField] private Image _batteryBar;
    [SerializeField] private Text _warningText;

    [SerializeField] private PlayerDefaultStateConfig _stateConfig;

    public Image BoosterBar
    {
        get => _boosterBar;
        set
        {
            if (value == null) throw new InvalidDataException("BoosterBar can not be null");
            _boosterBar = value;
        }
    }

    public Image HpBar
    {
        get => _hpBar;
        set
        {
            if (value == null) throw new InvalidDataException("HpBar can not be null");
            _hpBar = value;
        } 
    }
    
    public Image BatteryBar
    {
        get => _batteryBar;
        set
        {
            if (value == null) throw new InvalidDataException("BatteryBar can not be null");
            _batteryBar = value;
        }
    }
    
    public Text WarningText
    {
        get => _warningText;
        set
        {
            if (value == null) throw new InvalidDataException("WarningText can not be null");
            _warningText = value;
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
        
        // controllers
        IJumpController jumpController = new PlayerJumpController(new DefaultJumpController(objectComponentsModel), playerModel);
        IMoveController moveController = new PlayerMoveController(new DefaultMoveController(objectComponentsModel, playerModel), objectComponentsModel);
        IRotationController rotationController = new PlayerRotationController(new DefaultRotationController(objectComponentsModel), objectComponentsModel, playerSettingsModel);
        IPlayerUIController uiController = new DefaultUIController(playerModel, playerToolModel);
        IPlayerToolController toolController = new DefaultPlayerToolController(objectComponentsModel, playerToolModel, playerResearchesModel);
        
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

        DefaultPlayerUIView uiView = (DefaultPlayerUIView)gameObject.AddComponent(typeof(DefaultPlayerUIView));
        uiView.InitSuitController(uiController)
            .InitHPBar(_hpBar)
            .InitBoosterBar(_boosterBar)
            .InitBatteryBar(_batteryBar)
            .InitWarningText(_warningText);

        PlayerToolView toolView = (PlayerToolView)gameObject.AddComponent(typeof(PlayerToolView));
        toolView.InitPlayerToolController(toolController);
        toolView.InitPlayerUiView(uiView);
    }
}
