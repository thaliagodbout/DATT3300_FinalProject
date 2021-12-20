using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    private bool playerControlsEnabled = true;

    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
        
        if (ProgressManager.isSpawnInOverworld) { // Set spawnpoint in overworld
            gameObject.transform.position = ProgressManager.overworldSpawnPoint;
            ProgressManager.isSpawnInOverworld = false;
        }
    }

    void FixedUpdate()
    {
        if (playerControlsEnabled) {
            // Update IsRunning from input.
            IsRunning = canRun && Input.GetKey(runningKey);

            // Get targetMovingSpeed.
            float targetMovingSpeed = IsRunning ? runSpeed : speed;
            if (speedOverrides.Count > 0)
            {
                targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
            }

            // Get targetVelocity from input.
            Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

            // Apply movement.
            rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);

        }
        
    }

    public void enableControls() {
        playerControlsEnabled = true;

        Jump jumpScript = GetComponent<Jump>();
        jumpScript.enableControls();

        rigidbody.useGravity = true;

    }
 
    public void disableControls() {
        playerControlsEnabled = false;

        Jump jumpScript = GetComponent<Jump>();
        jumpScript.disableControls();
        
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.useGravity = false;
    }
}