using System.Threading;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneController : MonoBehaviour
{
    [Header("Flight Settings")]
    public float pitchSpeed = 50f;
    public float rollSpeed = 50f;
    public float yawSpeed = 20f;
    public float throttleSpeed = 10f;
    public float maxSpeed = 100f;
    public float minSpeed = 10f;

    private float throttleInput = 0f;
    private Vector2 pitchRollInput; // Left Thumbstick or WASD
    private float yawInput;         // Right Thumbstick or Q/E
    private float throttleDelta;    // Right Trigger or R/F

    [Header("Input Actions")]
    public InputActionReference pitchRollAction; // Vector2 for pitch and roll
    public InputActionReference yawAction;      // Axis for yaw
    public InputActionReference throttleAction; // Axis for throttle

    private void OnEnable()
    {
        pitchRollAction.action.Enable();
        yawAction.action.Enable();
        throttleAction.action.Enable();
    }

    private void OnDisable()
    {
        pitchRollAction.action.Disable();
        yawAction.action.Disable();
        throttleAction.action.Disable();
    }

    private void Update()
    {
        ReadInput();
        HandleThrottle();
        HandleFlightControls();

        // alteration to the original script
        if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.D)) // If the player presses the W, A, S, or D key
        {
            fuelDrain(1);// Drain 1 fuel
        }
        if (Fuelbar.slider.value <= 0) // If the fuel bar value is less than or equal to 0
        {
            emptyTank(); // Call the emptyTank method
        }
    }

    private void ReadInput()
    {
        pitchRollInput = pitchRollAction.action.ReadValue<Vector2>(); // Left Thumbstick or WASD
        yawInput = yawAction.action.ReadValue<float>();               // Right Thumbstick or Q/E
        throttleDelta = throttleAction.action.ReadValue<float>();     // Left Thumbstick or R/F
    }

    private void HandleThrottle() 
    {
        throttleInput += throttleDelta * throttleSpeed * Time.deltaTime;
        throttleInput = Mathf.Clamp(throttleInput, minSpeed, maxSpeed);
    }

    private void HandleFlightControls()
    {
        float pitch = pitchRollInput.y * pitchSpeed * Time.deltaTime;
        float roll = pitchRollInput.x * rollSpeed * Time.deltaTime;
        float yaw = yawInput * yawSpeed * Time.deltaTime;

        transform.Rotate(Vector3.right, pitch);
        transform.Rotate(Vector3.up, yaw);
        transform.Rotate(Vector3.forward, -roll);

        transform.position += transform.forward * throttleInput * Time.deltaTime;
    }
    // alteration to the original script

    public int maxFuel = 100;   // Maximum fuel capacity
    public int currentFuel;  // Current fuel level 

    public Fuelbar Fuelbar; // Reference to the Fuelbar script
    private void Start() // Called before the first frame update
    {
        currentFuel = maxFuel;  // Set the current fuel to the maximum fuel
        Fuelbar.SetMaxFuel(maxFuel);    // Set the maximum fuel level
    }
    
    void fuelDrain(int fuelLoss)  // Method to drain fuel
    {         
        currentFuel -= fuelLoss;  // Decrease the current fuel level

        Fuelbar.SetHealth(currentFuel);  // Update the fuel bar
    }
    
    void emptyTank()
    {
        if(currentFuel <= 0) // If the current fuel level is less than or equal to 0
        {
         gameObject.SetActive(false); // Deactivate the game object
            print("Game Over!"); // Print "Game Over!" to the console

        }
    }






}
