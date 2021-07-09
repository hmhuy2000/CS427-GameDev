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
    public GameObject opponent;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;

    public float jumpSpeed = 100f;
    public float runSpeed = 5f;
    public float walkSpeed = 2f;
    public bool is_boosting = false;
    public float boost_time = 0f;
    public float boost_limit = 5f;

    public bool is_freezing = false;
    public float freezing_time = 0f;
    public float freezing_limit = 5f;

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
    public void freeze(){
        freezing_time = 0f;
        is_freezing = true;
        walkSpeed /= 2f;
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("item_hook")){
            Destroy(other.gameObject);
            opponent.transform.position = new Vector2(transform.position.x, transform.position.y);

        }

        if (other.gameObject.CompareTag("item_freeze")){
            Destroy(other.gameObject);
            opponent.GetComponent<CatMovement>().freeze();

        }

        if (other.gameObject.CompareTag("item_boost_speed")){
            Destroy(other.gameObject);
            boost_time = 0f;
            is_boosting = true;
            walkSpeed *= 2f;

        }

        
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

        if (is_boosting){
            boost_time += Time.deltaTime;
            if (boost_time>=boost_limit){
                boost_time = 0f;
                is_boosting = false;
                walkSpeed /= 2f;
            }
        }

        if (is_freezing){
            freezing_time += Time.deltaTime;
            if (freezing_time>=freezing_limit){
                freezing_time = 0f;
                is_freezing = false;
                walkSpeed *= 2f;
            }
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
