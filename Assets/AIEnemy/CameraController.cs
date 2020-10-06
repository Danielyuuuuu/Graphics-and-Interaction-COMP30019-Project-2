using UnityEngine;

public class CameraController : MonoBehaviour
{

  public float moveSpeed = 20f;
  public float mouseSensitivity = 4f;
  public float maxAccelerate = 50f;
  public float accelerateFactor = 5f;

  private float originalSpeed;

  private float yaw;
  private float pitch;

  private Vector3 terrainCenter;
  private Vector3 cameraStartPositiom;

  void Start()
  {
    cameraStartPositiom = new Vector3(0.0f, 20.0f, 0.0f);

    // Lock the cursor when the game starts
    Cursor.lockState = CursorLockMode.Locked;
    originalSpeed = moveSpeed;
  }


  // Update is called once per frame
  void Update()
  {
    keyboardInput();
    mouseInput();
  }

  /* 
   * The keyboard input 'w' or 's' will make the camera move forward or backward. 
   * The keyboard input 'a' or 'd' will make the camera move left or right. 
   */
  private void keyboardInput()
  {

    Vector3 currentPosition = this.transform.position;

    // Move in x and z direction
    /* Camera movement should be relative to where it is facing. */
    if (Input.GetKey("w") && Input.GetKey("left shift"))
    {
      currentPosition += this.transform.forward * moveSpeed * Time.deltaTime;
    }
    if (Input.GetKey("s") && Input.GetKey("left shift"))
    {
      currentPosition += this.transform.forward * -moveSpeed * Time.deltaTime;
    }
    if (Input.GetKey("a") && Input.GetKey("left shift"))
    {
      currentPosition += this.transform.right * -moveSpeed * Time.deltaTime;
    }
    if (Input.GetKey("d") && Input.GetKey("left shift"))
    {
      currentPosition += this.transform.right * moveSpeed * Time.deltaTime;
    }


    // Apply the new position
    this.transform.position = currentPosition;
  }

  /* 
  * Moving the mouse will adjust the yaw and pitch of the camera. 
  * Yaw: goes positive if camera is pointing to the East, negative if pointing to the West.
  * Pitch: goes positive if camera is pointing up, negative if pointing down.
  */
  private void mouseInput()
  {
    yaw = mouseSensitivity * Input.GetAxis("Mouse X");
    pitch = mouseSensitivity * Input.GetAxis("Mouse Y");
    float newYaw = this.transform.eulerAngles.y + yaw;
    float newPitch = this.transform.eulerAngles.x - pitch;

    // The camera can only pitch up or pitch down by 90 degrees from the x-z plane.
    if (newPitch <= 180.0f)
    {
      if (newPitch > 90.0f)
      {
        newPitch = 90.0f;
      }
    }
    else
    {
      if (newPitch < 270.0f)
      {
        newPitch = 270.0f;
      }
    }

    this.transform.eulerAngles = new Vector3(newPitch, newYaw, 0.0f);

  }
}
