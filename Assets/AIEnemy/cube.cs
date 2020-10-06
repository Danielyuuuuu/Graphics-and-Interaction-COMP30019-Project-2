using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
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
    if (Input.GetKey("w"))
    {
      currentPosition += this.transform.forward * moveSpeed * Time.deltaTime;
    }
    if (Input.GetKey("s"))
    {
      currentPosition += this.transform.forward * -moveSpeed * Time.deltaTime;
    }
    if (Input.GetKey("a"))
    {
      currentPosition += this.transform.right * -moveSpeed * Time.deltaTime;
    }
    if (Input.GetKey("d"))
    {
      currentPosition += this.transform.right * moveSpeed * Time.deltaTime;
    }

    // Apply the new position
    this.transform.position = currentPosition;
  }
}
