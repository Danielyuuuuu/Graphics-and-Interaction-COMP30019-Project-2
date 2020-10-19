using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    public float h;
    public float v;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        animator.SetFloat("Speed", v);
        animator.SetFloat("Direction", h);

        Vector3 direction = new Vector3(h, 0, v);   

        if (Input.GetButtonDown("Fire1")) {
            animator.SetTrigger("Fire");
        }
    }
}
