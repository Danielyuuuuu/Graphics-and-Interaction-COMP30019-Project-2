using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlDemo : MonoBehaviour
{
    public Transform target;
    public int YAxisAway = 30;
    public int ZAxisAway = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerLocation = target.position;
        this.transform.position = new Vector3(playerLocation.x, playerLocation.y+YAxisAway, playerLocation.z+ZAxisAway);
        // this.transform.LookAt(target);
    }
}
