using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    
    // Torque and speed
    [SerializeField] float torqueAmount = 3f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] float slowSpeed = 10f;

    // Jump Mechanic
    [SerializeField] float jumpForce = 7f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;

    // Objects
    Rigidbody2D rb;
    SurfaceEffector2D surfaceEffector;
    
    //Input for actions
    InputAction moveAction;
    Vector2 moveInput;

    // Variables
    bool canControlPlayer = true; // Flag to control player input
    float baseSpeed;

    void Start(){
        // Initialize
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector = FindAnyObjectByType<SurfaceEffector2D>();

        // Shows the previously selected character
        transform.GetChild(0).GetChild(PlayerPrefs.GetInt("SelectedCharacter")).gameObject.SetActive(true);

        moveAction = InputSystem.actions.FindAction("Move");
        baseSpeed = surfaceEffector.speed;
    }

    void Update(){
        if (!canControlPlayer) return; // If player control is disabled, exit the method
        PlayerTorque();
        ControlSpeedPlayer();
        Jump();
    }

    // Get and set for the canControlPlayer flag
    public bool CanControlPlayer { get => canControlPlayer; set => canControlPlayer = value; }

    /// <summary>
    /// Applies torque base on the input received
    /// </summary>
    private void PlayerTorque(){
        moveInput = moveAction.ReadValue<Vector2>();

        if (moveInput.x < 0){
            rb.AddTorque(torqueAmount);
        }else if (moveInput.x > 0){
            rb.AddTorque(-torqueAmount);
        }
    }

    /// <summary>
    /// Adds more speed when W is pressed and less when S is pressed
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void ControlSpeedPlayer(){
        if (moveInput.y > 0){
            // W : More speed
            surfaceEffector.speed = boostSpeed;
        }else if (moveInput.y < 0){
            // S : Less speed
            surfaceEffector.speed = slowSpeed;
        }else{
            // Nothing pressed
            surfaceEffector.speed = baseSpeed;
        }
    }

    /// <summary>
    /// Jump when Space Bar is pressed
    /// </summary>
    private void Jump(){
        // Check if the player is on the floor
        bool isGrounded = Physics2D.OverlapCircle(
            groundCheck.position, 
            groundRadius,
            groundLayer
        );
        
        // If the player is on the floor and Space bar is pressed do the jump
        if (isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame){
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
