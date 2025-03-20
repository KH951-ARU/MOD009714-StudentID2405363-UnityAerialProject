using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoblieButtonManager : MonoBehaviour
{
    public PlaneController playerPlane;
    public Rigidbody rb;
    public float ForewardSpeed = 10f;
    public float RotationSpeed = 1000f;
    private bool isRotatingRight = false; 
    private bool isRotatingLeft = false;
    private bool isRotatingUp = false;
    private bool isRotatingDown = false;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update() // Update is called once per frame
    {
        if (isRotatingRight) // if the right arrow is pressed
        {
            RightArrow(); // call the right arrow function
            
        }
        if (isRotatingLeft) // if the left arrow is pressed
        {
            LeftArrow();   // call the left arrow function
        }
        if (isRotatingUp) // if the up arrow is pressed
        {
            UpArrow(); // call the up arrow function
        }
        if (isRotatingDown) // if the down arrow is pressed
        {
            DownArrow(); // if the down arrow is pressed
        }
    }

   
    // Arrow functions
    public void UpArrow()
    {
        transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
    }
    public void DownArrow()
    {
        transform.Rotate(Vector3.right * -RotationSpeed * Time.deltaTime);
    }

    public void LeftArrow()
    {
        transform.Rotate(Vector3.up * -RotationSpeed * Time.deltaTime);
    }
    public void RightArrow()
    {
     transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
    }
    // right roation on/off
    public void StartRoatingRight()
    {
        isRotatingRight = true;
    }
    public void StopRoatingRight()
    {
        isRotatingRight = false;
    }
    // left roation on/off 
    public void StartRoatingLeft()
    {
        isRotatingLeft = true;
    }

    public void StopRoatingLeft()
    {
        isRotatingLeft = false;
    }
   // up roation on/off 
    public void StartRoatingUp()
    {
        isRotatingUp = true;
    }

    public void StopRoatingUp()
    {
        isRotatingUp = false;
    }
    // down roation on/off
    public void StartRoatingDown()
    {
        isRotatingDown = true;
    }
    public void StopRoatingDown()
    {
        isRotatingDown = false;
    }
}

