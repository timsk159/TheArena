using UnityEngine;
using System.Collections;

public class IsometricCameraController : MonoBehaviour
{
    //-------------------------------------------------
    // Public Variables

    public Transform Player;

    public float cameraCurrentDistance;

    public float orthographicSize;

    public float nearClipPlane;
    public float farClipPlane;

    public float positionDampening;
    public float distanceDampening;

    public float xCameraOffset;
    public float zCameraOffset;

    //-------------------------------------------------
    // Private Variables

    private Vector3 cameraDesiredPosition;
    private Vector3 cameraCurrentPosition;

    private float cameraDesiredDistance;

    private float xVel;
    private float yVel;
    private float zVel;

    //-------------------------------------------------

    void Awake()
    {
        SetCameraDefaultValues();
    }

    void FixedUpdate()
    {
        UpdateCameraPosition();
    }

    //-------------------------------------------------

    #region Basic Camera Functions

    public void SetCameraDefaultValues()
    {
        cameraCurrentDistance = 15;
        cameraDesiredDistance = cameraCurrentDistance;
        orthographicSize = 5;
        nearClipPlane = 0.3f;
        farClipPlane = 1000f;
        positionDampening = 0.1f;
        distanceDampening = 0.2f;
        xCameraOffset = 2;
        zCameraOffset = 8;
    }

    private void UpdateCameraPosition()
    {
        // Always look at the player
        Camera.main.transform.LookAt(Player);

        // Update the desired position
        cameraDesiredPosition = new Vector3(Player.position.x - xCameraOffset, cameraDesiredDistance, Player.position.z - zCameraOffset);

        // Smooth camera's current pos towards the desired pos
        smoothCameraMovement();

        Camera.main.transform.position = cameraCurrentPosition;
    }

    private void smoothCameraMovement()
    {
        // Movement
        float xPos = Mathf.SmoothDamp(cameraCurrentPosition.x, cameraDesiredPosition.x, ref xVel, positionDampening);
        float zPos = Mathf.SmoothDamp(cameraCurrentPosition.z, cameraDesiredPosition.z, ref zVel, positionDampening);
        
        // Zoom level
        float yPos = Mathf.SmoothDamp(cameraCurrentDistance, cameraDesiredDistance, ref yVel, distanceDampening);

        cameraCurrentPosition = new Vector3(xPos, yPos, zPos);    
    }


    #endregion

    //-------------------------------------------------

    #region Gameplay Camera Functions

    public void ShakeCamera()
    {

    }

    #endregion

    //-------------------------------------------------
}
