using System;
using System.Collections;
using System.Collections.Generic;
using Internal.Models;
using Unity.VisualScripting;
using UnityEngine;

public class DefaultMoveController : IMoveController
{
    private PlayerSuitModel _playerSuitModel;
    private ObjectComponentsModel _objectComponentsModel;

    private Vector3 _direction;

    public DefaultMoveController(ObjectComponentsModel objectComponentsModel, PlayerSuitModel playerSuitModel)
    {
        _objectComponentsModel = objectComponentsModel;
        _playerSuitModel = playerSuitModel;
    }

    public void Move(Vector3 value)
    {
        _objectComponentsModel.Rigidbody.AddForce(value.normalized * _playerSuitModel.Acceleration);
        if (_objectComponentsModel.Rigidbody.velocity.magnitude > _playerSuitModel.MaxSpeed)
        {
            _objectComponentsModel.Rigidbody.velocity = _objectComponentsModel.Rigidbody.velocity.normalized;
            _objectComponentsModel.Rigidbody.velocity *= _playerSuitModel.MaxSpeed;
        }
    }

    public void Stop()
    {
    }

    public void Jump(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
}