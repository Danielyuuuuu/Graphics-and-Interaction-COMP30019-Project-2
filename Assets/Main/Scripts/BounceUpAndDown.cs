using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceUpAndDown : MonoBehaviour
{

  public AnimationCurve animationCurve;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    transform.position = new Vector3(transform.position.x, animationCurve.Evaluate((Time.time * 1.35f % animationCurve.length)) + 4.0f, transform.position.z);
    }
}
