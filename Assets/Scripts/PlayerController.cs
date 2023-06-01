using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 10f;
    bool isRun;
    bool isDead;
    Health health;
    private void OnEnable()
    {
        if (health == null)
        {
            health = GetComponent<Health>();
            health.InitializeHealthValue(10);
        }
        health.OnDeath.AddListener(Death);
    }
    private void OnDisable()
    {
        health.OnDeath.RemoveListener(Death);
    }
    void Death()
    {
        isDead = true;
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
    public bool IsRun 
    {
        get { return isRun; }
        private set { isRun = value; }
    }
    public bool IsDead 
    { 
        get { return isDead; }
        private set { isDead = value; } 
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
