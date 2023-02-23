using System;
using System.Collections;
using System.Collections.Generic;
using Internal.Controllers;
using Internal.Models;
using UnityEngine;
using Views;

public class PlayerBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private void Start()
    {
        GameObject player = Instantiate(_prefab, Vector3.zero, Quaternion.identity);

        // models
        ObjectComponentsModel objectComponentsModel = new ObjectComponentsModel();
        objectComponentsModel.Rigidbody = player.GetComponent<Rigidbody>();
        objectComponentsModel.Transform = player.transform;
        
        PlayerSettingsModel playerSettingsModel = new PlayerSettingsModel();
        playerSettingsModel.MouseSensitivity = 0.5f;
        playerSettingsModel.Volume = 1f;
        
        PlayerSuitModel playerSuitModel = new PlayerSuitModel();
        PlayerToolModel playerToolModel = new PlayerToolModel();
        
        // controllers
        IMoveController moveController = new DefaultMoveController(objectComponentsModel, playerSuitModel);
        IJumpController jumpController = new DefaultJumpController(objectComponentsModel, playerSuitModel);
        IRotationController rotationController = new DefaultPlayerRotationController(objectComponentsModel, playerSettingsModel);
        
        // views
        PlayerMoveInputView moveInputView = (PlayerMoveInputView)player.AddComponent(typeof(PlayerMoveInputView));
        moveInputView.InitMoveController(moveController)
                     .InitJumpController(jumpController);
        
        PlayerRotateInputView rotateInputView = (PlayerRotateInputView)player.AddComponent(typeof(PlayerRotateInputView));
        rotateInputView.InitRotateInputView(rotationController);
    }
}
