using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 10f;
    bool isRun;
    public bool IsRun 
    {
        get { return isRun; }
        private set { isRun = value; }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            isRun = true;
            transform.localScale = new Vector3(horizontal, transform.localScale.y, transform.localScale.z);
            rb.velocity = new Vector2(horizontal * speed * 60 * Time.fixedDeltaTime, rb.velocity.y);
        }
        else
        {
            isRun = false;
            rb.velocity = Vector2.zero;
        }
    }
}
