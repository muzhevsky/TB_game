using System;
using Internal.Controllers;
using UnityEngine;

namespace Views
{
    public class PlayerMoveInputView : View
    {
        private IMoveController _moveController;
        private IJumpController _jumpController;

        public PlayerMoveInputView InitMoveController(IMoveController moveController)
        {
            if (moveController == null) throw new NullReferenceException("move controller can not be null");
            _moveController = moveController;
            return this;
        }
    
        public PlayerMoveInputView InitJumpController(IJumpController jumpController)
        {
            if (jumpController == null) throw new NullReferenceException("jump controller can not be null");
            _jumpController = jumpController;
            return this;
        }

        private void FixedUpdate()
        {
            MoveInput();
            JumpInput();
        }

        private void MoveInput()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            _moveController.Move(new Vector3(horizontal, vertical));
        }

        private void JumpInput()
        {
            if (Input.GetKey(KeyCode.Space))
                _jumpController.Jump(Vector3.up);
        }
    }
}