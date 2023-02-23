using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuitModel : Model
{
    private float _acceleration = 35;
    private float _jumpForce = 10;
    private float _maxSpeed = 100;
    private float _maxHP = 100;

    public float Acceleration
    {
        get => _acceleration;
        set => _acceleration = value;
    }

    public float MaxSpeed
    {
        get => _maxSpeed;
        set => _maxSpeed = value;
    }

    public float JumpForce
    {
        get => _jumpForce;
        set => _jumpForce = value;
    }
}
