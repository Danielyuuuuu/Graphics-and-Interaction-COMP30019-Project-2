using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public GameObject floor;
    
    [SerializeField] float moveSpeed = 5.0f;
    Animator animator;
    Rigidbody playerRigidbody;
    Transform cam;
    HealthManager healthManager;

    Vector3 movement;
    Vector3 lookPos;
    Vector3 camForward;
    Vector3 move;
    Vector3 floorSize;
    Vector2 floorBottomLeft;
    Vector2 floorTopRight;
    
    float forwardAmount;
    float turnAmount;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        cam = Camera.main.transform;
        healthManager = this.GetComponent<HealthManager>();
        // floorSize = floor.GetComponent<Collider>().bounds.size;
        // floorBottomLeft = new Vector2(floor.transform.position.x, floor.transform.position.z);
        // floorTopRight = new Vector2(floor.transform.position.x + floorSize.x, floor.transform.position.z + floorSize.z);

        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        if (cam != null)
        {
            // if camera exists, we know it must be a top-down view
            camForward = Vector3.Scale(cam.up, new Vector3(1,0,1)).normalized;
            move = v * camForward + h * cam.right;
        }
        else
        {
            // otherwise, use a normal setting
            move = v * Vector3.forward + h * Vector3.right;
        }

        if (move.magnitude > 1) 
        {
            // 
            move.Normalize ();  
        }

        if (healthManager.GetHealth() > 0)
        {
            Move(h, v, move);
        }
    }

    void Update()
    {
        if (healthManager.GetHealth() > 0)
        {
            Aim();
        }
    }

    void Move(float h, float v, Vector3 move)
    {
        // Move the player game object by `h` and `v` 
        // amount horizontally and vertically respectively
        movement.Set(h, 0f, v);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        Vector3 destination = transform.position + movement;

    // Limit the player movement within the game floor
    //float xPos = Mathf.Clamp(destination.x, floorBottomLeft.x, floorTopRight.x);
    //float zPos = Mathf.Clamp(destination.z, floorBottomLeft.y, floorTopRight.y);
    //destination.Set(xPos, destination.y, zPos);

    destination.Set(destination.x, destination.y, destination.z);

    playerRigidbody.MovePosition(destination);
        
        // Use the correct animation when the player is looking at a different position
        // E.g. should run the "Walk backward" animation when mouse is pointing down
        // and the key "W" is pressed, etc.
        ConvertMoveInput(move);
        UpdateAnimator();
    }

    void ConvertMoveInput(Vector3 moveInput)
    {
        Vector3 localMove = transform.InverseTransformDirection(moveInput);
        turnAmount = localMove.x;
        forwardAmount = localMove.z;
    }

    void UpdateAnimator()
    {
        animator.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
        animator.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
    }

    void Aim()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            lookPos = hit.point;
        }

        Vector3 lookDir = new Vector3(lookPos.x, lookPos.y, lookPos.z - 1.2f) - transform.position;
        lookDir.y = 0;

        transform.LookAt(transform.position + lookDir, Vector3.up);
    }

}
