using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    private float moveSpeed = 10f;
    public float projectileSpeed = 10.0f;

    //public float speed = 1.0f; // Default speed sensitivity
    //public GameObject projectilePrefab;
    public ProjectileController projectilePrefab;


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


        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseScreenPos = Input.mousePosition;

            float distanceFromCameraToXZPlane = Camera.main.transform.position.y;

            Vector3 screenPosWithZDistance = (Vector3)mouseScreenPos + (Vector3.forward * distanceFromCameraToXZPlane);
            Vector3 fireToWorldPos = Camera.main.ScreenToWorldPoint(screenPosWithZDistance);

            ProjectileController p = Instantiate<ProjectileController>(projectilePrefab);
            p.transform.position = this.transform.position;
            //p.velocity = (fireToWorldPos - this.transform.position).normalized * 10.0f;
            p.velocity = (fireToWorldPos - this.transform.position).normalized * projectileSpeed;

            //GameObject projectile = Instantiate<GameObject>(projectilePrefab);
            //projectile.transform.position = this.gameObject.transform.position;


        }
    }
}
