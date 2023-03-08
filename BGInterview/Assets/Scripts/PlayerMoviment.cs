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
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        StartCoroutine(BlinkTriggerCorountine());
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
            running = !running;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("LastDirection", LastDirectionValue(movement));
        animator.SetBool("Walking", movement.sqrMagnitude > 0);
        animator.SetBool("Running", running);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(
            rb.position + movement * (running? runSpeed : walkSpeed) * Time.fixedDeltaTime
        );
    }

    private IEnumerator BlinkTriggerCorountine()
    {
        float blinkAnimationDuration = 1f;
        float minWaitTimeForBlink = 1f, maxWaitTimeForBlink = 3.5f;
        while(true){
            yield return new WaitForSeconds(
                Random.Range(minWaitTimeForBlink, maxWaitTimeForBlink)
            );
            animator.SetTrigger("Blink");
            yield return new WaitForSeconds(blinkAnimationDuration);
        }
    }

    private float LastDirectionValue(Vector2 movement)
    {
        float lastDirectionValue = animator.GetFloat("LastDirection");
        if(movement.y > 0)
            lastDirectionValue = 0;
        else if(movement.y < 0)
            lastDirectionValue = 0.4f;
        else if(movement.x > 0)
            lastDirectionValue = 0.8f;
        else if(movement.x < 0)
            lastDirectionValue = 1f;
        return lastDirectionValue;
    }
}
