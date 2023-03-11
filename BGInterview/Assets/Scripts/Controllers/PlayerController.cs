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
    public Clothes[] clothes;
    public Clothes equippedClothes;
    int usingClothes = 0;

    // Start is called before the first frame update
    private void Start()
    {
        equippedClothes = new Clothes();
        equippedClothes.head = new Head();
        equippedClothes.body = new Body();
        equippedClothes.legs = new Legs();
        equippedClothes.head.headFront = clothes[0].head.headFront;
        equippedClothes.head.headBack = clothes[0].head.headBack;
        equippedClothes.head.headLeft = clothes[0].head.headLeft;
        equippedClothes.head.headRight = clothes[0].head.headRight;
        equippedClothes.body.bodyFront = clothes[0].body.bodyFront;
        equippedClothes.body.bodyBack = clothes[0].body.bodyBack;
        equippedClothes.body.bodyLeft = clothes[0].body.bodyLeft;
        equippedClothes.body.bodyRight = clothes[0].body.bodyRight;
        equippedClothes.body.lArm = clothes[0].body.lArm;
        equippedClothes.body.rArm = clothes[0].body.rArm;
        equippedClothes.legs.lLeg = clothes[0].legs.lLeg;
        equippedClothes.legs.rLeg = clothes[0].legs.rLeg;
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

        if(Input.GetKeyDown(KeyCode.C)){
            SwitchClotes();
        }

        Move();
        UpdateSprites();
        SetInteractionColliderDirection();
    }

    public void SwitchClotes()
    {
        usingClothes = (usingClothes + 1) % clothes.Length;
        // equippedClothes.head.headFront = clothes[usingClothes].head.headFront;
        equippedClothes.body.bodyFront = clothes[usingClothes].body.bodyFront;
        equippedClothes.body.bodyBack = clothes[usingClothes].body.bodyBack;
        equippedClothes.body.bodyLeft = clothes[usingClothes].body.bodyLeft;
        equippedClothes.body.bodyRight = clothes[usingClothes].body.bodyRight;
        equippedClothes.body.lArm = clothes[usingClothes].body.lArm;
        equippedClothes.body.rArm = clothes[usingClothes].body.rArm;
        // equippedClothes.legs.lLeg = clothes[usingClothes].legs.lLeg;
        // equippedClothes.legs.rLeg = clothes[usingClothes].legs.rLeg;

        Player.Instance.head.sprite = equippedClothes.head.headFront;
        Player.Instance.body.sprite = equippedClothes.body.bodyFront;
        Player.Instance.lArm.sprite = equippedClothes.body.lArm;
        Player.Instance.rArm.sprite = equippedClothes.body.rArm;
        Player.Instance.lLeg.sprite = equippedClothes.legs.lLeg;
        Player.Instance.rLeg.sprite = equippedClothes.legs.rLeg;
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
