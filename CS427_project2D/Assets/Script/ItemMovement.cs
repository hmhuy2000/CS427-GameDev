using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    Vector2 curMove;
    Rigidbody2D rigid;
    BoxCollider2D boxCollider2D;
    private Vector2 screenBounds;
    [SerializeField] float flySpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        curMove = transform.position;
        rigid = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(0, flySpeed);
        if(transform.position.y > 60f){
            Destroy(this.gameObject);
        }
    }
}
