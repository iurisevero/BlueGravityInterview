using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference to moviment: https://youtu.be/whzomFgjT50

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform interactionCollider;
    private Rigidbody2D _rigidbody2D { get { return Player.Instance._rigidbody2D; }}
    private Animator animator { get { return Player.Instance.animator; }}
    private Vector2 movement;
    private bool running = false;
    private Directions lastDirection = Directions.South;

    public float walkSpeed = 2f;
    public float runSpeed = 3f;
    public Clothes clothes;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(BlinkTriggerCorountine());
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            running = !running;
            animator.SetBool("Running", running);
        }

        if(Input.GetKeyDown(KeyCode.E)){
            Player.Instance.Interact();
            animator.SetTrigger("Interaction");
        }

        Move();

        SetInteractionColliderDirection();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(
            _rigidbody2D.position + movement * (running? runSpeed : walkSpeed) * Time.fixedDeltaTime
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

    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        Directions currentDirection = movement.GetFaceDirection();
        lastDirection = currentDirection != Directions.None? currentDirection : lastDirection;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("LastDirection", lastDirection.ToFloat());
        animator.SetBool("Walking", movement.sqrMagnitude > 0);
    }

    private void SetInteractionColliderDirection()
    {
        interactionCollider.rotation = Quaternion.Euler(0, 0, lastDirection.ToAngle());
    }
}
