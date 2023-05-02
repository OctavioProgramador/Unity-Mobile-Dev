using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Responsible for moving the player automatically and
/// reciving input.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    /// <summary>
    /// A reference to the Rigidbody component
    /// </summary>
    private Rigidbody rb;
    [Tooltip("How fast the ball moves left/right")]
    public float dodgeSpeed = 5;
    [Tooltip("How fast the ball moves forwards automatically")]
    [Range(0, 10)]
    public float rollSpeed = 5;
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // Get access to our Rigidbody component
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 0, rollSpeed);
    }
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Check if we're moving to the side
        var horizontalSpeed = Input.GetAxis("Horizontal") *
                              dodgeSpeed;
        // If the mouse is held down (or the screen is tapped
        // on Mobile)
        if (Input.GetMouseButton(0))
        {
            // Converts to a 0 to 1 scale
            var worldPos =
            Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float xMove = 0;
            // If we press the right side of the screen
            if (worldPos.x < 0.5f)
            {
                xMove = -1;
            }
            else
            {
                // Otherwise we're on the left
                xMove = 1;
            }
            // replace horizontalSpeed with our own value
            horizontalSpeed = xMove * dodgeSpeed;
        }

            // Apply our auto-moving and movement forces
            //rb.AddForce(horizontalSpeed, 0, rollSpeed);

        if (rb.velocity.z < rollSpeed)
        {
            rb.AddForce(horizontalSpeed, 0, rollSpeed);
        }        
        rb.AddForce(horizontalSpeed, 0, 0);

    }
}