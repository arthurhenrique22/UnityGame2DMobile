using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;


[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerController : MonoBehaviour
{
    CharacterMovement2D playerMovement;
    SpriteRenderer spriteRenderer;
    PlayerInput playerInput;
    public Sprite crouchedSprite;
    public Sprite idleSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<CharacterMovement2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();

    
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = playerInput.GetMovementInput();
        playerMovement.ProcessMovementInput(movementInput);
        
        //virarLado
        if (movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        ///Pulo
        if (playerInput.IsJumpButtonDown())
        {
           playerMovement.Jump();
        }
        if(playerInput.IsJumpButtonHeld() == false)
        {
            playerMovement.UpdateJumpAbort();
        }
        
        //Agachar
        if(playerInput.IsCrouchButtonDown())
        {
            playerMovement.Crouch();

            spriteRenderer.sprite = crouchedSprite;
        }
        else if (playerInput.IsCrouchButtonUp())
        {
            playerMovement.UnCrouch();

            spriteRenderer.sprite = idleSprite;
        }

    }
}
