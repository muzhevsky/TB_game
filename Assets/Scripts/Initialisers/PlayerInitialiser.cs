using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Initialisers;
using Internal.Controllers;
using Internal.Models;
using Internal.Utils;
using ScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Views;
using Views.Interfaces;

public class PlayerInitialiser : MonoBehaviour, IInitialiser
{
    [SerializeField] private Image _hpBar;
    [SerializeField] private Image _boosterBar;
    [SerializeField] private PlayerDefaultStateConfig _stateConfig;
    public void Init()
    {
        // models
        PlayerComponentsModel objectComponentsModel = new PlayerComponentsModel();
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
        IPlayerUIController uiController = new DefaultUIController(playerModel);
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
            .InitBoosterBar(_boosterBar);

        PlayerToolView toolView = (PlayerToolView)gameObject.AddComponent(typeof(PlayerToolView));
        toolView.InitPlayerToolView(toolController);
    }
}
