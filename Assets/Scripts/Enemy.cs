using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Health health;
    Animator anim;
    private void Awake()
    {
        anim= GetComponent<Animator>();
    }
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
        anim.SetBool("IsDead", true);
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
}
