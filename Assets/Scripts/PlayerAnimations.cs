using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator anim;
    PlayerController playerController;
    PlayerCombat playerCombat;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        playerCombat = GetComponent<PlayerCombat>();
    }
    private void Update()
    {
        UpdateAnimationState();
    }
    void UpdateAnimationState()
    {
        anim.SetBool("IsRun",playerController.IsRun);
        anim.SetBool("IsAttack", playerCombat.IsAttack);
    }
}
