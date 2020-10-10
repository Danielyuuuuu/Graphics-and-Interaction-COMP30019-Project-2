using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDemo : MonoBehaviour
{
    Vector3 movement;
    float moveSpeed = 10f;
    Rigidbody playerRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
    }

    void Move (float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     WASDMovement();
    //     Turning();
    // }

    // void WASDMovement()
    // {
    //     Vector3 currentPosition = this.transform.position;

    //     // Move in x and z direction
    //     /* Camera movement should NOT be relative to where it is facing. */
    //     if (Input.GetKey("w"))
    //     {
    //         currentPosition += Vector3.forward * moveSpeed * Time.deltaTime;
    //     }
    //     if (Input.GetKey("s"))
    //     {
    //         currentPosition += Vector3.forward * -moveSpeed * Time.deltaTime;
    //     }
    //     if (Input.GetKey("a"))
    //     {
    //         currentPosition += Vector3.left * moveSpeed * Time.deltaTime;
    //     }
    //     if (Input.GetKey("d"))
    //     {
    //         currentPosition += Vector3.right * moveSpeed * Time.deltaTime;
    //     }

    //     // Apply the new position
    //     this.transform.position = currentPosition;
    // }

    /**
     * Using Raycase has a problem.
     * If mouse cursor move outside of the map, no detection found.
     * Thus cant turn around.
     * Need to come up a new solution in the future.
     */
    void Turning ()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    
        if(Physics.Raycast(ray, out hit, 100))
        {
            // transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

}
