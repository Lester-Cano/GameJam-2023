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

        //posint.x = Mathf.Floor(pos.x);
        //posint.z = Mathf.Floor(pos.z);
        Debug.Log(currentMovement);

        transform.position = Vector3.Lerp(transform.position, pos, 0.1f);



        CheckRotation();

       // LerpMovement(posint,1);
        



    }
    /*
    IEnumerator LerpMovement(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
    */
    void CheckRotation()
    {
        if (currentMovement.z < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (currentMovement.x < 0)
        {
            transform.eulerAngles = new Vector3(0f, -90f, 0f);
        }
        else if (currentMovement.z > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (currentMovement.x > 0)
        {
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
    }
}
