using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;
using System;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInput : MonoBehaviour
{
    private struct PlayerInputConstants
    {
        public const string Horizontal = "Horizontal";
        public const string Vertical = "Vertical";
        public const string Jump = "Jump";
        public const string Attack = "Attack";
    }
    public Vector2 GetMovementInput()
    {
        //Input Teclado
        float horizontalInput = Input.GetAxisRaw(PlayerInputConstants.Horizontal);

        //Se o unput do teclado for zero, tentamos ler o input do celular.
        if (Mathf.Approximately(horizontalInput, 0.0f))
        {
            horizontalInput = CrossPlatformInputManager.GetAxis(PlayerInputConstants.Horizontal);
        }    
        return new Vector2(horizontalInput, 0);
    }
    
    public bool IsJumpButtonDown()
    {
        bool isKeyboardButtonDown = Input.GetKeyDown(KeyCode.Space);
        bool isMobileButtonDown = CrossPlatformInputManager.GetButtonDown(PlayerInputConstants.Jump);
        return isKeyboardButtonDown || isMobileButtonDown;
    }

    public bool IsJumpButtonHeld()
    {
        bool isKeyboardButtonDown = Input.GetKey(KeyCode.Space);
        bool isMobileButtonDown = CrossPlatformInputManager.GetButton(PlayerInputConstants.Jump);
        return isKeyboardButtonDown || isMobileButtonDown;
    }
    public bool IsCrouchButtonDown()
    {
        bool isKeyboardButtonDown = Input.GetKeyDown(KeyCode.S);
        bool isMobileButtonDown = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Vertical) <0;        
        return isKeyboardButtonDown || isMobileButtonDown;
    }

    public bool IsCrouchButtonUp()
    {
        bool isKeyboardButtonDown = Input.GetKey(KeyCode.S) == false;
        bool isMobileButtonDown = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Vertical) >= 0;        
        return isKeyboardButtonDown && isMobileButtonDown;
    }

    public bool IsAttackButtonDown()
    {
        bool isKeyboardButtonDown = Input.GetKeyDown(KeyCode.K);
        bool isMobileButtonDown = CrossPlatformInputManager.GetButtonDown(PlayerInputConstants.Attack);
        return isKeyboardButtonDown || isMobileButtonDown;
    }

}
