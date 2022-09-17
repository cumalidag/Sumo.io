using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This particular class controls the player's movement
public class PlayerController : MonoBehaviour
{

    // This is a variable that will be used to move the player
    [SerializeField] private float movementSpeed;
    // This is a variable that will be used to rotate the player
    [SerializeField] private float rotationSpeed = 500;

    // This _touch object will be used to store the touch input
    private Touch _touch;
    // This Vector3 object will be used to store the touch down position
    private Vector3 _touchDown;
    // This Vector3 object will be used to store the touch up position
    private Vector3 _touchUp;
    // This is a variable that will be used to store whether the touch is dragging or not
    private bool _dragStarted;

    void Update()
    {
        // This method will be used to move the player
        TouchController();

    }

    // This method will be return the calculated angle between the touch down and touch up positions
    Quaternion CalculateRotation()
    {
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
        return temp;
    }

    // This method will be used to calculate the direction between the touch down and touch up positions
    Vector3 CalculateDirection()
    {
        
        Vector3 temp = (_touchDown - _touchUp).normalized;
        // Normally, the touch down and touch up positions will be in the range of x and y
        // but we want the direction to be in the range of x and z
        // so we will set the y value of the touch down and touch up positions to 0
        temp.z = temp.y;
        temp.y = 0;
        return temp;
    }

    // This method will be used to move the player
    private void TouchController()
    {
        // Player movement z direction (forward)
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        // If the screen is touched
        if (Input.touchCount > 0)
        {
            // Get the touch input
            _touch = Input.GetTouch(0);
            // If the touch is began
            if (_touch.phase == TouchPhase.Began)
            {
                _dragStarted = true;
                _touchDown = _touch.position;
                _touchUp = _touch.position;
            }
        }
        // This will check if the player is touching the screen
        if (_dragStarted)
        {
            // If the touch is moved
            // _touchDown will be set to the touch position
            if (_touch.phase == TouchPhase.Moved)
            {
                _touchDown = _touch.position;

            }
            // If the touch is ended
            // _toucUp will be set to the touch position
            if (_touch.phase == TouchPhase.Ended)
            {
                _touchUp = _touch.position;
                _dragStarted = false;

            }
            // Player rotates according to the touch input
            transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotation(), rotationSpeed * Time.deltaTime);

        }
    }

}
