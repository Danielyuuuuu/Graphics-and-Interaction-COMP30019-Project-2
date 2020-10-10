using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownCamera : MonoBehaviour
{
    // the higher boundary, the more easy to move the camera on edge
    public int maxViewDistance;
    public int speed;
    public int gap;
    public GameObject target;
    private int screenWidth;
    private int screenHeight;
    private float boundary;
    private Vector3 center;
    private float nudgeDistance = 5f;


    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        center = this.transform.position;
        // this.transform.localPosition = target.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 newPos = this.transform.position;

        // if (Input.mousePosition.x > screenWidth + gap)
        // {
        //     newPos.x += speed * Time.deltaTime;
        // }
        
        // if (Input.mousePosition.x < 0 - gap)
        // {
        //     newPos.x -= speed * Time.deltaTime;
        // }
        
        // if (Input.mousePosition.y > screenHeight + gap)
        // {
        //     newPos.z += speed * Time.deltaTime;
        // }
        
        // if (Input.mousePosition.y < 0 - gap)
        // {
        //     newPos.z -= speed * Time.deltaTime;
        // }

        // // if (Input.mousePosition.x < screenWidth && Input.mousePosition.x > 0 && Input.mousePosition.y < screenHeight && Input.mousePosition.y > 0)
        // // {
        // //     newPos.x = target.transform.localPosition.x;
        // //     newPos.y = target.transform.localPosition.y;
        // // }


        // newPos.x = Mathf.Clamp(newPos.x, -(center.x+maxViewDistance), center.x+maxViewDistance);
        // newPos.y = Mathf.Clamp(newPos.y, -(center.y+maxViewDistance), center.y+maxViewDistance);

        // this.transform.position = newPos;

        if (Input.mousePosition.x > screenWidth || Input.mousePosition.x < 0 || Input.mousePosition.y > screenHeight || Input.mousePosition.y < 0)
        {
            Vector3 cameraTarget = GetNudgeTargetPosition();
            Vector3 pos = this.transform.position;
            pos.x = Mathf.Lerp(pos.x, cameraTarget.x, speed*Time.deltaTime);
            pos.z = Mathf.Lerp(pos.z, cameraTarget.z, speed*Time.deltaTime);

            this.transform.position = pos;
        }

    }

    Vector3 GetNudgeDirection() {
        // return target.transform.forward;

        // //Get the position of the mouse
        // Vector3 mousePos = Input.mousePosition;
        // mousePos.z = -Camera.main.transform.position.z;
        // Vector2 inputPos = Camera.main.ScreenToWorldPoint(mousePos);
        // //returns direction from the player to the mouse pos.
        // return (inputPos - (Vector2)target.transform.position).normalized;
        
        Vector2 mouseScreenPos = Input.mousePosition;

        float distanceFromCameraToXZPlane = this.transform.position.y;
        Vector3 screenPosWithZDistance = (Vector3)mouseScreenPos + (Vector3.forward * distanceFromCameraToXZPlane);
        Vector3 fireToWorldPos = Camera.main.ScreenToWorldPoint(screenPosWithZDistance);
        return (fireToWorldPos - this.transform.position).normalized;
    }

    Vector3 GetNudgeTargetPosition() {
        return target.transform.position + GetNudgeDirection() * nudgeDistance;
    }
}
