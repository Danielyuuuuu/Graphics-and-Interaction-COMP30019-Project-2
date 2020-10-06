using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  private float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    Vector3 currentPosition = this.transform.position;

    // Move in x and z direction
    /* Camera movement should be relative to where it is facing. */
    if (Input.GetKey("w") && !Input.GetKey("left shift"))
    {
      currentPosition += this.transform.forward * moveSpeed * Time.deltaTime;
    }
    if (Input.GetKey("s") && !Input.GetKey("left shift"))
    {
      currentPosition += this.transform.forward * -moveSpeed * Time.deltaTime;
    }
    if (Input.GetKey("a") && !Input.GetKey("left shift"))
    {
      currentPosition += this.transform.right * -moveSpeed * Time.deltaTime;
    }
    if (Input.GetKey("d") && !Input.GetKey("left shift"))
    {
      currentPosition += this.transform.right * moveSpeed * Time.deltaTime;
    }

    // Apply the new position
    this.transform.position = currentPosition;
  }
}
