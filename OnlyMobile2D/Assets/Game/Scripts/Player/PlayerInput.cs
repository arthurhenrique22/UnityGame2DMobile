using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;
using System;

public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 GetMovementInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        return new Vector2(horizontalInput, 0);
    }
    
    public bool IsJumpButtonDown()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public bool IsJumpButtonHeld()
    {
        return Input.GetKey(KeyCode.Space);
    }
    public bool IsCrouchButtonDown()
    {
        return Input.GetKeyDown(KeyCode.S);
    }

    public bool IsCrouchButtonUp()
    {
        return Input.GetKeyUp(KeyCode.S);
    }

}
