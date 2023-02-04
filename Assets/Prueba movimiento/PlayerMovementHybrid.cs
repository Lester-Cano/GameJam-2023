using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Timeline;

public class PlayerMovementHybrid : MonoBehaviour
{

    PlayerInput playerInput;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;

    [SerializeField] float velocity;
    [SerializeField] Vector3 pos, posint;

    

    void Awake()
    {
        playerInput = new PlayerInput();

        playerInput.CharacterControls.Movement.started += OnMovementInput;
        playerInput.CharacterControls.Movement.canceled += OnMovementInput;
        playerInput.CharacterControls.Movement.performed += OnMovementInput;

        pos = transform.position;
    }

    void OnMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();

        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
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
        if (currentMovement.x == 0 || currentMovement.z != 0)
        {
            pos += new Vector3(0, 0, currentMovement.z) * velocity * Time.deltaTime;
        }
        else if (currentMovement.x != 0 || currentMovement.z == 0)
        {
            pos += new Vector3(currentMovement.x, 0, 0) * velocity * Time.deltaTime;
        }

        posint.x = Mathf.Floor(pos.x);
        posint.z = Mathf.Floor(pos.z);

        transform.position = posint;
        
        
    }
}
