using System.Linq;
using Sources.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Inventory inventory;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 _velocity;
    private bool isGrounded;

    public LayerMask interactableLayer;

    public Camera playerCamera;

    private float _moveByXThisFrame = 0f;
    private float _moveByYThisFrame = 0f;

    private Vector3 _cumulativeTrainMovement = Vector3.zero;

    public AudioSource walkSfx;
    public AudioSource mainMusic;

    public bool displayDebugInfo;

    private void Start()
    {
        playerCamera = Camera.main;
        
        _velocity = new Vector3();
        if (playerCamera == null)
        {
            Debug.LogError("Missing camera reference on PlayerMovement");
        }

        if (Debug.isDebugBuild)
        {
            mainMusic.Stop();
        }
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        
        var localTransform = transform;
        Vector3 move = localTransform.right * _moveByXThisFrame + localTransform.forward * _moveByYThisFrame;
        
        controller.Move(move * speed * Time.deltaTime);
        
        _velocity.y += gravity * Time.deltaTime;
        controller.Move(_velocity * Time.deltaTime);

        controller.Move(GetCumulativeTrainMovement());
    }

    public void AccumulateTrainMovement(Vector3 movement)
    {
        _cumulativeTrainMovement += movement;
    }

    public Vector3 GetCumulativeTrainMovement()
    {
        var movement = _cumulativeTrainMovement;
        
        _cumulativeTrainMovement = Vector3.zero;

        return movement;
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 moveVec = context.ReadValue<Vector2>();
        _moveByXThisFrame = moveVec.x;
        _moveByYThisFrame = moveVec.y;
        if (context.performed)
        {
            if (!walkSfx.isPlaying)
            {
                walkSfx.Play();
            }
        }

        if (context.canceled)
        {
            walkSfx.Stop();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // if (!context.performed) return;

        if (context.performed)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
   
        }

       
    }

    public void OnWeaponSelection(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        
        var actionName = context.action.name.Last();
        DisplayDebugMessage("Selected weapon " + actionName);
        var weaponIndex = int.Parse(actionName.ToString());
        inventory.OnChangeWeapon(weaponIndex);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inventory.OnInteractWithWeapon();
        }
    }

    private void FixedUpdate()
    {
        Transform cameraTransform = playerCamera.transform;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward), out var hit, Mathf.Infinity, interactableLayer))
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                PlayerEventManager.TriggerEvent(PlayerEventManager.PlayerEvents.Hover, hit.collider.gameObject);
            }
        }
        else
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward) * 1000, Color.white);
            PlayerEventManager.TriggerEvent(PlayerEventManager.PlayerEvents.NotHover, gameObject);
        }
    }

    public void DisplayDebugMessage(string debugMsg)
    {
        if (!displayDebugInfo)
        {
            return;
        }
        
        DisplayDebugMessage("[PlayerMovement] " + debugMsg);
        
    }
}
