using System;
using System.Collections;
using System.Collections.Generic;
using Internal.Controllers;
using Internal.Models;
using Unity.VisualScripting;
using UnityEngine;
using Views;
using Views.Interfaces;

public class PlayerBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private void Start()
    {
        GameObject player = Instantiate(_prefab, Vector3.zero, Quaternion.identity);

        // models
        PlayerComponentsModel objectComponentsModel = new PlayerComponentsModel();
        objectComponentsModel.Rigidbody = player.GetComponent<Rigidbody>();
        objectComponentsModel.Transform = player.transform;
        objectComponentsModel.Camera = Camera.main;
        
        PlayerSettingsModel playerSettingsModel = new PlayerSettingsModel();
        playerSettingsModel.MouseSensitivity = 5f;
        
        PlayerSuitModel playerSuitModel = new PlayerSuitModel();
        PlayerToolModel playerToolModel = new PlayerToolModel();
        
        // controllers
        IJumpController jumpController = new DefaultPlayerJumpController(new DefaultJumpController(objectComponentsModel), playerSuitModel);
        IMoveController moveController = new DefaultPlayerMoveController(new DefaultMoveController(objectComponentsModel, playerSuitModel), objectComponentsModel);
        IRotationController rotationController = new DefaultPlayerRotationController(new DefaultRotationController(objectComponentsModel), objectComponentsModel, playerSettingsModel);
        IPlayerUIController uiController = new DefaultUIController(); 
        
        // views
        PlayerMoveInputView moveInputView = (PlayerMoveInputView)player.AddComponent(typeof(PlayerMoveInputView));
        moveInputView.InitMoveController(moveController)
                     .InitJumpController(jumpController);
        
        PlayerRotateInputView rotateInputView = (PlayerRotateInputView)player.AddComponent(typeof(PlayerRotateInputView));
        rotateInputView.InitRotateInputView(rotationController);

        IPlayerUIView uiView = (IPlayerUIView)player.AddComponent(typeof(DefaultPlayerUIView));
        uiView.InitUIController(uiController);
    }
}
