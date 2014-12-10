using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class PlayerNavigationController : MonoBehaviour
{
    //-------------------------------------------------
    // Public Variables
    public InputManager inputManager;

    public float speed = 10.0f;
    public float maxVelocityChange = 10.0f;

    public float gravity = 10.0f;

    public float rotationSpeed = 3.0f;

    //-------------------------------------------------
    // Private Variables
    private IsometricCameraController isoCamController;

    private bool grounded = false;

    private Vector3 moveVector;
    private int moveX;
    private int moveZ;

    private Vector3 velocityVector;

    private float lookAtHeight;

    //-------------------------------------------------

    void Awake()
    {
        isoCamController = Camera.main.GetComponent<IsometricCameraController>();

        rigidbody.freezeRotation = true;
        rigidbody.useGravity = false;

        lookAtHeight = this.rigidbody.collider.bounds.center.y;
    }

    void FixedUpdate()
    {
        updateMovement();
        updateGravity();
        updateRotationDirection();
    }

    //-------------------------------------------------

    #region Player Logic

    void OnCollisionStay()
    {
        grounded = true;
    }

    private void updateMovement()
    {
        updateMovementInput();

        if (grounded)
        {
            // Calculate how fast we should be moving
            moveVector = moveVector.normalized * speed;

            // Apply a force that attempts to reach our target velocity
            velocityVector = rigidbody.velocity;

            Vector3 velocityChange = (moveVector - velocityVector);

            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;

            rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
        }
    }

    private void updateGravity()
    {
        // Apply gravity manually for more tuning control
        rigidbody.AddForce(new Vector3(0, -gravity * rigidbody.mass, 0));
        grounded = false;
    }

    private void updateRotationDirection()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, 100))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            rigidbody.MoveRotation(newRotation);
        }
    }

    #endregion

    //-------------------------------------------------

    #region Player Input

    private void updateMovementInput()
    {
        if (inputManager.GetInput(InputManager.InputActions.UP, true))
        {
            moveX = 1;
        }
        else if (inputManager.GetInput(InputManager.InputActions.DOWN, true))
        {
            moveX = -1;
        }
        else
        {
            moveX = 0;
        }

        if (inputManager.GetInput(InputManager.InputActions.RIGHT, true))
        {
            moveZ = 1;
        }
        else if (inputManager.GetInput(InputManager.InputActions.LEFT, true))
        {
            moveZ = -1;
        }
        else
        {
            moveZ = 0;
        }

        moveVector = new Vector3(moveZ, 0, moveX);
    }

    #endregion

    //-------------------------------------------------
}
