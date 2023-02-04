using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    Vector3 startPosition;
    [SerializeField] bool isMovementPressed, isDashing, dashAvailable = true;

    [SerializeField] float velocity, elapsedTime = 0f , dashDuration;
    [SerializeField] Vector3 pos, posint;

    float counter = 0;


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
        if (Input.GetKeyDown(KeyCode.F) && dashAvailable) { Dash(); }

        if(isDashing) 
        {
            elapsedTime += Time.deltaTime;

            float percentageTime = elapsedTime / dashDuration;

            transform.position = (Vector3.Lerp(startPosition, startPosition + Vector3.forward * 3 , percentageTime));

            if (percentageTime > 1)
            {
                pos = transform.position;
                elapsedTime= 0;
                isDashing= false;
            }

        }
    }

    void Move()
    {

        if (currentMovement.x != 0 || currentMovement.z != 0)
        {
            pos += new Vector3(currentMovement.x, 0, currentMovement.z) * velocity * Time.deltaTime;
        }

        //posint.x = Mathf.Floor(pos.x);
        //posint.z = Mathf.Floor(pos.z);
        pos.y = 1;
       // Debug.Log(currentMovement);
       
        transform.position = pos;
        CheckRotation();
    }

    void Dash()
    {
        startPosition = transform.position;
        isDashing = true;
       
        dashAvailable = false;

    }
    
    void CheckRotation()
    {
        if (currentMovement.z < 0 && currentMovement.x < 0)
        {
            transform.eulerAngles = new Vector3(0f, -135f, 0f);
        }
        else if (currentMovement.z > 0 && currentMovement.x > 0)
        {
            transform.eulerAngles = new Vector3(0f, 45f, 0f);
        }
        else if (currentMovement.z > 0 && currentMovement.x < 0)
        {
            transform.eulerAngles = new Vector3(0f, -45f, 0f);
        }
        else if (currentMovement.z < 0 && currentMovement.x > 0)
        {
            transform.eulerAngles = new Vector3(0f, 135f, 0f);
        }
        else if (currentMovement.z < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (currentMovement.z > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (currentMovement.x > 0)
        {
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        else if (currentMovement.x < 0)
        {
            transform.eulerAngles = new Vector3(0f, -90f, 0f);
        }
    }
}
