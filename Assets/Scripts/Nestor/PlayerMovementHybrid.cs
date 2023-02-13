using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Timeline;

public class PlayerMovementHybrid : MonoBehaviour
{

    PlayerMovementHybrid PlayerReff;
     PlayerInput playerInput;
    public float velocidadNormalizada;
    public InputActionProperty movimiento;
    private  SFXPlaying Dashsfx;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 startPosition;
    [SerializeField] public bool isMovementPressed, isDashing, dashAvailable = true, dashCool;

    [SerializeField] float velocity, elapsedTime = 0f , dashDuration, dashCooldown;
    [SerializeField] public Vector3 pos, posint;

    public bool dead = false;

    Animator animator;


    void Awake()
    {
        Dashsfx = FindObjectOfType<SFXPlaying>();
        playerInput = new PlayerInput();

        playerInput.CharacterControls.Movement.started += OnMovementInput;
        playerInput.CharacterControls.Movement.canceled += OnMovementInput;
        playerInput.CharacterControls.Movement.performed += OnMovementInput;

        pos = transform.position;

        animator = GetComponentInChildren<Animator>();
        movimiento.action.Enable();
    }

    void OnMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();

        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void HandleAnimation()
    {
        bool Runnning = animator.GetBool("Running");
        bool IsDashing = animator.GetBool("IsDashing");

        if (isMovementPressed && !Runnning)
        {
            animator.SetBool("Running", true);
        }
        else if (!isMovementPressed && Runnning)
        {
            animator.SetBool("Running", false);
        }

        if (isDashing && !IsDashing)
        {
            animator.SetBool("IsDashing", true);
        }
        else if (!isDashing && IsDashing)
        {
            animator.SetBool("IsDashing", false);
        }


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
        velocidadNormalizada = Mathf.Lerp(velocidadNormalizada, movimiento.action.ReadValue<Vector2>().magnitude,0.2f);
        HandleAnimation();

        if (isMovementPressed && !dead) { Move(); }
        if (Input.GetKeyDown(KeyCode.F) && dashAvailable && !isDashing && !dead) { Dash(); }

        if(isDashing) 
        {
            ParticleSystem ps = GetComponentInChildren<ParticleSystem>();
            ps.Play();

            elapsedTime += Time.deltaTime;

            float percentageTime = elapsedTime / dashDuration;

            

            transform.position = (Vector3.Lerp(startPosition, startPosition + transform.forward * 3 , percentageTime));
            

            if (percentageTime > 1)
            {
                dashCool = true;
                pos = transform.position;
                elapsedTime = 0;
                percentageTime = 0;
                isDashing = false;
            }
        }

        if (dashCool)
        {
            dashCooldown += Time.deltaTime;

            if (dashCooldown > 5)
            {
                dashAvailable = true;
                dashCooldown = 0;
                dashCool = false;
            }

        }
        {

        }

    }

    void Move()
    {

        
        if ((currentMovement.x != 0 || currentMovement.z != 0) && !isDashing)
        {
            pos += new Vector3(currentMovement.x, 0, currentMovement.z) * velocity * Time.deltaTime;
            //changeAudio.Switcheroo();

        }

        //posint.x = Mathf.Floor(pos.x);
        //posint.z = Mathf.Floor(pos.z);
        pos.y = transform.position.y;
       // Debug.Log(currentMovement);
       
        transform.position = pos;

        CheckRotation();
    }

    void Dash()
    {
        startPosition = transform.position;
        isDashing = true;
        if(Dashsfx != null)
        {
            Dashsfx.PlayDashSFX();
        }
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
