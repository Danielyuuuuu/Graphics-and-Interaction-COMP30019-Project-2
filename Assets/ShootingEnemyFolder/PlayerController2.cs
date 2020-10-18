using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
  Vector3 movement;
  Rigidbody playerRigidbody;
  public float moveSpeed = 10f;
  public float projectileSpeed = 10.0f;

  public Rigidbody projectilePrefab;

  public GameObject createOnDestroy;

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
    Shooting();
  }

  void Move(float h, float v)
  {
    movement.Set(h, 0f, v);
    movement = movement.normalized * moveSpeed * Time.deltaTime;
    playerRigidbody.MovePosition(transform.position + movement);
  }

  void Turning()
  {
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    if (Physics.Raycast(ray, out hit, 100))
    {
      // transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
      Vector3 playerToMouse = hit.point - transform.position;
      playerToMouse.y = 0f;

      Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
      playerRigidbody.MoveRotation(newRotation);
    }
  }

  void Shooting()
  {
    if (Input.GetMouseButton(0))
    //if (Input.GetMouseButtonDown(0))
    {
      var p = Instantiate(projectilePrefab);
      p.transform.position = new Vector3(transform.position.x, 1.3f, transform.position.z);
      p.transform.rotation = transform.rotation;
      p.velocity = transform.forward * projectileSpeed;

      // explosion effect of the bullet
      GameObject obj = Instantiate(this.createOnDestroy);
      obj.transform.position = this.transform.position;
    }
  }
  
  public void EquipStoreItem(string itemName)
  {
    Debug.Log("The store item '" + itemName + "' is equipped to the player");
  }



    // Update is called once per frame
    // void Update()
    // {
    //     Vector3 currentPosition = this.transform.position;

    //     // Move in x and z direction
    //     /* Camera movement should be relative to where it is facing. */
    //     if (Input.GetKey("w") && !Input.GetKey("left shift"))
    //     {
    //         currentPosition += this.transform.forward * moveSpeed * Time.deltaTime;
    //     }
    //     if (Input.GetKey("s") && !Input.GetKey("left shift"))
    //     {
    //         currentPosition += this.transform.forward * -moveSpeed * Time.deltaTime;
    //     }
    //     if (Input.GetKey("a") && !Input.GetKey("left shift"))
    //     {
    //         currentPosition += this.transform.right * -moveSpeed * Time.deltaTime;
    //     }
    //     if (Input.GetKey("d") && !Input.GetKey("left shift"))
    //     {
    //         currentPosition += this.transform.right * moveSpeed * Time.deltaTime;
    //     }

    //     // Apply the new position
    //     this.transform.position = currentPosition;


    //     // rotate the character as the mouse's position move
    //     RaycastHit hit;
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //     if (Physics.Raycast(ray, out hit, 100))
    //     {
    //         transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
    //     }
     


    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         Vector2 mouseScreenPos = Input.mousePosition;

    //         float distanceFromCameraToXZPlane = Camera.main.transform.position.y;

    //         Vector3 screenPosWithZDistance = (Vector3)mouseScreenPos + (Vector3.forward * distanceFromCameraToXZPlane);
    //         Vector3 fireToWorldPos = Camera.main.ScreenToWorldPoint(screenPosWithZDistance);

    //         ProjectileController p = Instantiate<ProjectileController>(projectilePrefab);
    //         p.transform.position = new Vector3(this.transform.position.x, 1.3f, this.transform.position.z);
    //         //p.transform.position = this.transform.position;

    //         //p.transform.LookAt(this.transform.forward);

    //         //p.velocity = (fireToWorldPos - this.transform.position).normalized * 10.0f;
    //         p.velocity = (fireToWorldPos - this.transform.position).normalized * projectileSpeed;
    //         p.velocity.y = 0f;

    //         // explosion effect of the bullet
    //         GameObject obj = Instantiate(this.createOnDestroy);
    //         obj.transform.position = this.transform.position;
    //     }
    // }
}
