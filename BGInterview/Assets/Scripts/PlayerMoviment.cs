using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ref: https://youtu.be/whzomFgjT50

public class PlayerMoviment : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private bool running = false;

    public float walkSpeed = 2f;
    public float runSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetBool("Walking", movement.sqrMagnitude > 0);

        if(Input.GetKeyDown(KeyCode.LeftShift))
            running = !running;
    }

    void FixedUpdate()
    {
        rb.MovePosition(
            rb.position + movement * (running? runSpeed : walkSpeed) * Time.fixedDeltaTime
        );
    }
}
