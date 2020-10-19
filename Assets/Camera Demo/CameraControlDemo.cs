using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlDemo : MonoBehaviour
{
    public Transform target;
    public int YAxisAway;
    public int ZAxisAway;
    public int XAxisRotation;

    int screenWidth;
    int screenHeight;
    float speed = 2f;
    int nudgeDistance = 5;
    bool nudging = false;
    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        this.transform.Rotate(XAxisRotation, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = this.transform.position;
        Vector3 playerLocation = target.position;
        newPos = new Vector3(playerLocation.x, playerLocation.y+YAxisAway, playerLocation.z+ZAxisAway);
        // this.transform.LookAt(target);
        
        // if (Input.mousePosition.x > screenWidth || Input.mousePosition.x < 0 || Input.mousePosition.y > screenHeight || Input.mousePosition.y < 0)
        // {
        //     nudging = true;
        //     Vector3 targetPos = GetNudgeTargetPosition();
        //     Vector3 startPos = this.transform.position;
        //     targetPos.y = startPos.y;
        //     newPos = Vector3.Lerp(startPos, targetPos, speed*Time.deltaTime);
        //     // newPos.x = Mathf.Lerp(startPos.x, targetPos.x, speed*Time.deltaTime);
        //     // newPos.z = Mathf.Lerp(startPos.z, targetPos.z, speed*Time.deltaTime);

        // } else
        // {
        //     nudging = false;
        // }

        this.transform.position = newPos;

    }

    void Peeking(Vector3 mousePos)
    {
        Vector3 aimingDirection = new Vector3();

        // Mouse exceeds the right edge
        if (mousePos.x > screenWidth)
        {
            aimingDirection = Vector3.right;
        }
        // Mouse exceeds the left edge
        if (mousePos.x < 0)
        {
            aimingDirection = Vector3.left;
        }
        // Mouse exceeds the top edge
        if (mousePos.y > screenHeight)
        {
            aimingDirection = Vector3.forward;
        }
        // Mouse exceeds the bottom edge
        if (mousePos.y < 0)
        {
            aimingDirection = -Vector3.forward;
        }

        Vector3 cameraTarget = GetNudgeTargetPosition();
        Vector3 pos = target.position;
        pos.x = Mathf.Lerp(pos.x, cameraTarget.x, speed*Time.deltaTime);
        pos.z = Mathf.Lerp(pos.z, cameraTarget.z, speed*Time.deltaTime);
    }

    Vector3 GetNudgeDirection() {
        return target.forward;
        // Vector2 mouseScreenPos = Input.mousePosition;

        // float distanceFromCameraToXZPlane = this.transform.position.y;
        // Vector3 screenPosWithZDistance = (Vector3)mouseScreenPos + (Vector3.forward * distanceFromCameraToXZPlane);
        // Vector3 fireToWorldPos = Camera.main.ScreenToWorldPoint(screenPosWithZDistance);
        // return (fireToWorldPos - this.transform.position).normalized;
    }

    Vector3 GetNudgeTargetPosition() {
        return target.position + (GetNudgeDirection() * nudgeDistance);
    }
}
