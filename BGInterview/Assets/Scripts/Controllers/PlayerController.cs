using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference to moviment: https://youtu.be/whzomFgjT50

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform interactionCollider;
    private Rigidbody2D _rigidbody2D { get { return Player.Instance._rigidbody2D; }}
    private Animator animator { get { return Player.Instance.animator; }}
    private Clothes equippedClothes { get { return Player.Instance.equippedClothes; }}
    private Vector2 movement;
    private bool running = false;
    private Directions lastDirection = Directions.South;

    public float walkSpeed = 2f;
    public float runSpeed = 3f;

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
        UpdateSprites();
        SetInteractionColliderDirection();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(
            _rigidbody2D.position + movement * (running? runSpeed : walkSpeed) * Time.fixedDeltaTime
        );
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

    private void UpdateSprites()
    {
        Sprite headSprite, bodySprite;
        switch (lastDirection)
        {
            case Directions.North:
                headSprite = equippedClothes.head.headBack;
                bodySprite = equippedClothes.body.bodyBack;
                break;
            case Directions.East:
                headSprite = equippedClothes.head.headRight;
                bodySprite = equippedClothes.body.bodyRight;
                break;
            case Directions.West:
                headSprite = equippedClothes.head.headLeft;
                bodySprite = equippedClothes.body.bodyLeft;
                break;
            default:
                headSprite = equippedClothes.head.headFront;
                bodySprite = equippedClothes.body.bodyFront;
                break;
        }

        Player.Instance.head.sprite = headSprite;
        Player.Instance.body.sprite = bodySprite;
    }

    private void SetInteractionColliderDirection()
    {
        interactionCollider.rotation = Quaternion.Euler(0, 0, lastDirection.ToAngle());
    }
}
