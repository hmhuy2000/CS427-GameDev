using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public bool is_boosting_speed = false;
    public float boost_time_speed = 0f;
    public float boost_limit_speed = 5f;
    public bool is_boosting_jump = false;
    public float boost_time_jump = 0f;
    public float boost_limit_jump = 5f;

    public bool is_freezing = false;
    public float freezing_time = 0f;
    public float freezing_limit = 5f;

    float curJumpSpeed = 0;
    float curWalkSpeed = 0;

    bool isWalking = false;
    bool isJumping = false;

    [SerializeField] int id;
    [SerializeField] Text timer;

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
            boost_time_speed = 0f;
            is_boosting_speed = true;
            walkSpeed *= 2f;

        }

        if (other.gameObject.CompareTag("item_boost_jump")){
            Destroy(other.gameObject);
            boost_time_jump = 0f;
            is_boosting_jump = true;
            jumpSpeed *= 1.5f;

        }

        if (other.gameObject.CompareTag("destination"))
        {
            finishLevel();
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

        if (is_boosting_speed){
            boost_time_speed += Time.deltaTime;
            if (boost_time_speed>=boost_limit_speed){
                boost_time_speed = 0f;
                is_boosting_speed = false;
                walkSpeed /= 2f;
            }
        }

        if (is_boosting_jump){
            boost_time_jump += Time.deltaTime;
            if (boost_time_jump>=boost_limit_jump){
                boost_time_jump = 0f;
                is_boosting_jump = false;
                jumpSpeed /= 1.5f;
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
        
        return groundRaycastHit.collider != null;
    }

    void finishLevel()
    {
        string prefMode = "mode";
        string prefLevel = "level";
        string prefMaxUnlockedLevel = "maxUnlockedLevel";
        string prefMaxLevel = "maxLevel";


        int mode = PlayerPrefs.GetInt(prefMode, 1);
        if (mode == 1)
        {
            int level = PlayerPrefs.GetInt(prefLevel, 1)+1;
            int maxUnlockedLevel = PlayerPrefs.GetInt(prefMaxUnlockedLevel, 1);
            if(level > maxUnlockedLevel) // unlock new level
            {
                int maxLevel = PlayerPrefs.GetInt(prefMaxLevel, 2);
                if(level <= maxLevel) // not max level -> update max unlock level
                {
                    PlayerPrefs.SetInt(prefMaxUnlockedLevel, level);
                }
            }
            
            PlayerPrefs.SetInt("timeLeft", int.Parse(timer.text));
            SceneManager.LoadScene("VictorySingle");

        }
        else if (mode == 2)
        {
            PlayerPrefs.SetInt("winner", id);
            SceneManager.LoadScene("VictoryMulti");
        }
    }
}
