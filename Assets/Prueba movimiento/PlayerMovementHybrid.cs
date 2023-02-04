using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovementHybrid : MonoBehaviour
{

    PlayerInput playerInput;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;

    void Awake()
    {
        playerInput = new PlayerInput();

        playerInput.CharacterControls.Movement.started += context => 
        {

            currentMovementInput = context.ReadValue<Vector2>();
            currentMovement.x = currentMovementInput.x;
            currentMovement.z = currentMovementInput.y;

            isMovementPressed = currentMovement.x != 0 || currentMovement.z != 0;

        };
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    void Update()
    {
        if (isMovementPressed) { Move(); }
    }

    void Move()
    {
        transform.Translate(currentMovement * Time.deltaTime);
    }
}
