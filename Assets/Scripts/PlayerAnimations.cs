using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator anim;
    PlayerController playerController;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }
    private void Update()
    {
        UpdateAnimationState();
    }
    void UpdateAnimationState()
    {
        anim.SetBool("IsRun",playerController.IsRun);
    }
}
