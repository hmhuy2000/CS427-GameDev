using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    Vector2 curMove;
    Rigidbody2D rigid;
    BoxCollider2D boxCollider2D;
    Animator anim;
    [SerializeField] private LayerMask groundLayerMask;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;

    public float jumpSpeed = 100f;
    public float runSpeed = 5f;
    public float walkSpeed = 2f;

    float curJumpSpeed = 0;
    float curWalkSpeed = 0;

    bool isWalking = false;
    bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        curMove = transform.position;
        rigid = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGround() && Input.GetKeyDown(jumpKey))
        {
            isJumping = true;
            curJumpSpeed = jumpSpeed;
            rigid.AddForce(new Vector2(0, jumpSpeed));
            anim.SetTrigger("jump");

        }
        else
        {
            curJumpSpeed = rigid.velocity.y;
            isJumping = false;
        }
        if (Input.GetKey(leftKey))
        {
            curWalkSpeed = -walkSpeed;
            GetComponent<SpriteRenderer>().flipX = true;
            isWalking = true;
        }
        else if (Input.GetKey(rightKey))
        {
            curWalkSpeed = walkSpeed;
            GetComponent<SpriteRenderer>().flipX = false;
            isWalking = true;
        }
        else
        {
            curWalkSpeed = 0;
            isWalking = false;
        }
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(curWalkSpeed, rigid.velocity.y);
        anim.SetBool("walk", isWalking);
        //if (isJumping)
        
    }

    bool isGround()
    {
        float extraHeightGroundCheck = 0.1f;
        RaycastHit2D groundRaycastHit = Physics2D.BoxCast(
            boxCollider2D.bounds.center,
            boxCollider2D.bounds.size,
            0f,
            Vector2.down,
            extraHeightGroundCheck,
            groundLayerMask
            );
        //if (groundRaycastHit.collider != null)
        //    return true;

        //RaycastHit2D catRaycastHit = Physics2D.BoxCast(
        //    boxCollider2D.bounds.center,
        //    boxCollider2D.bounds.size,
        //    0f,
        //    Vector2.down,
        //    extraHeightGroundCheck,
        //    catLayerMask
        //    );



        //Color rayColor;
        //if (raycastHit2D.collider != null)
        //{
        //    rayColor = Color.green;
        //}
        //else rayColor = Color.red;
        //Debug.DrawRay(
        //    boxCollider2D.bounds.center + new Vector3(boxCollider2D.bounds.extents.x, 0),
        //    Vector2.down * (boxCollider2D.bounds.extents.y + extraHeightGroundCheck),
        //    rayColor
        //    );
        //Debug.DrawRay(
        //    boxCollider2D.bounds.center - new Vector3(boxCollider2D.bounds.extents.x, 0),
        //    Vector2.down * (boxCollider2D.bounds.extents.y + extraHeightGroundCheck),
        //    rayColor
        //    );
        //Debug.DrawRay(
        //    boxCollider2D.bounds.center - new Vector3(boxCollider2D.bounds.extents.x, boxCollider2D.bounds.extents.y + extraHeightGroundCheck),
        //    Vector2.right * 2 * boxCollider2D.bounds.extents.x,
        //    rayColor
        //    );
        return groundRaycastHit.collider != null;
    }

    public void stopAction()
    {
        rigid.velocity = new Vector2(0, rigid.velocity.y);
        anim.SetBool("walk", false);
    }
}
