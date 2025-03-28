using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    private PlayerInputActions playerInputAction;
    [NonSerialized]

    private CharacterController controller;
    [NonSerialized]
    public Vector3 playerVelocity;
    [NonSerialized]
    public bool groundedPlayer;
    [NonSerialized]
    public float playerSpeed = 2.0f;
    [NonSerialized]
    public float jumpHeight = 1.0f;
    [NonSerialized]
    public float gravityValue = -9.81f;
    [NonSerialized]
    public Vector3 vectorMovement ;
    public float smoothTime = 0.05f;

    public float currentVelocity;

    private void Awake()
    {
        playerInputAction = new PlayerInputActions();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        playerInputAction.Enable();
    }

    private void OnDisable()
    {
        playerInputAction.Disable();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        Vector2 vectorInput = playerInputAction.PlayerMovement.Movement.ReadValue<Vector2>();

        vectorMovement = new Vector3(vectorInput.x, 0.0f, vectorInput.y);
        controller.Move(vectorMovement * Time.deltaTime * playerSpeed);

        if (vectorMovement != Vector3.zero)
        {
            var targetAngle = Mathf.Atan2(vectorMovement.x, vectorMovement.z) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        }
        

    }
}

