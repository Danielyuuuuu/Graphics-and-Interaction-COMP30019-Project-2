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

    public GameObject createOnDestroy;

   

    // Update is called once per frame
    void Update()
    {
        
        // rotate the character as the mouse's position move
        /*
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, rotationZ, 0f);
        */

       
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


        // rotate the character as the mouse's position move
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
     


        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseScreenPos = Input.mousePosition;

            float distanceFromCameraToXZPlane = Camera.main.transform.position.y;

            Vector3 screenPosWithZDistance = (Vector3)mouseScreenPos + (Vector3.forward * distanceFromCameraToXZPlane);
            Vector3 fireToWorldPos = Camera.main.ScreenToWorldPoint(screenPosWithZDistance);

            ProjectileController p = Instantiate<ProjectileController>(projectilePrefab);
            p.transform.position = new Vector3(this.transform.position.x, 1.3f, this.transform.position.z);
            //p.transform.position = this.transform.position;
            
            //p.velocity = (fireToWorldPos - this.transform.position).normalized * 10.0f;
            p.velocity = (fireToWorldPos - this.transform.position).normalized * projectileSpeed;
            p.velocity.y = 0f;

            // explosion effect of the bullet
            GameObject obj = Instantiate(this.createOnDestroy);
            obj.transform.position = this.transform.position;

            //GameObject projectile = Instantiate<GameObject>(projectilePrefab);
            //projectile.transform.position = this.gameObject.transform.position;


        }
    }
}
