using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfOffscreen : MonoBehaviour
{
    // Triggered as soon as the object is outside of the camera frustrum
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
