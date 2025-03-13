using System.Threading;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
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

    public float drainTime = 10f;
    public float currentDrainTime = 2f;

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
        PlaneisDestroy = true;
    }

    private void Update()
    {
        ReadInput();
        HandleThrottle();
        HandleFlightControls();

        readyToDrain = (pitchRollInput.x != 0 || pitchRollInput.y != 0);
        // alteration to the original script
        if (readyToDrain ) // If the player presses the W, A, S, or D key
        {
            currentDrainTime -= 1 * Time.deltaTime; // Decrease the current drain time
            if (currentDrainTime <= 0f)
            {
                fuelDrain(6);// Drain 6 fuel
                currentDrainTime = drainTime; // Reset the drain time
                Fuelbar.slider.value = currentFuel; // Update the fuel bar
                
            }
        }
        Debug.Log(Fuelbar.slider.value.ToString());
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
    public bool PlaneisDestroy;
    public int maxFuel = 100;   // Maximum fuel capacity
    public int currentFuel;  // Current fuel level
    public bool readyToDrain; // Boolean to check if the fuel can be drained
    

    public TextMeshPro Text;
    public Fuelbar Fuelbar; // Reference to the Fuelbar script
    private void Start() // Called before the first frame update
    {
        currentFuel = maxFuel;  // Set the current fuel to the maximum fuel
        Fuelbar.SetMaxFuel(maxFuel);// Set the maximum fuel level
        readyToDrain = false; // Set readyToDrain to false
    }
    
   public void fuelDrain(int fuelLoss)  // Method to drain fuel
    {         
        currentFuel -= fuelLoss;  // Decrease the current fuel level
        
        Fuelbar.SetHealth(currentFuel);  // Update the fuel bar
        readyToDrain = true; // Set readyToDrain to true
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
