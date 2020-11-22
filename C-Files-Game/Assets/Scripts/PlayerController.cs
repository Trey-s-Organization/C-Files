using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] bool lockCursor = true;
    [SerializeField] float walkSpeed = 8.0f;
    [SerializeField] private float moveSmoothTime = 0.1f;
    [SerializeField] private float mouseSmoothTime = 0.02f;
    private float gravity = 0.0f;
    private float slopeForce = 5f;
    private float slopeForceRayLength = 1.5f;
    CharacterController controller = null;
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;
    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    bool interact;
    bool steps;
    bool death;


    // Start is called before the first frame update
    void Start()
    {
        lockCursor = true;
        controller = GetComponent<CharacterController>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        interact = false;
        death = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!interact)
        {
            UpdateMouseLook();
            if (death) mouseSensitivity = 0.1f;
            UpdateMovement();
        }


        if (!death)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) steps = true;
            else steps = false;
            GetComponent<AudioSource>().enabled = steps;
        }
        else GetComponent<AudioSource>().enabled = false;






    }

    public void playerSen()
    {
        mouseSensitivity = 3.5f;
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    public void Interact()
    {
        lockCursor = false;
        interact = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        lockCursor = true;
        interact = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();
        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);
        //if (controller.isGrounded) velocityY = 0;
        //velocityY += gravity * Time.deltaTime;
        //Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed;
        controller.Move(velocity * Time.deltaTime);
        if((currentDir.x != 0 || currentDir.y != 0) && !OnSlope())
        {
            controller.Move(Vector3.down * controller.height / 2 * slopeForce * Time.deltaTime);
        }
    }

    private bool OnSlope()
    {
        if (!controller.isGrounded) return false;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, controller.height / 2 * slopeForceRayLength))
        {
            if (hit.normal != Vector3.up) return true;
        }
        return false;
    }

    public void Death()
    {
        death = true;
        
    }

}
