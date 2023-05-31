using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
	Transform attackPoint;
	[SerializeField]
	int damageValue;
    [SerializeField]
	float attackRange;
	[SerializeField]
	LayerMask enemyLayer;
	private bool isAttack;

	public bool IsAttack
	{
		get { return isAttack; }
		set { isAttack = value; }
	}

    private void Update()
    {
		if (Input.GetMouseButtonDown(0) && !isAttack)
		{
			StartCoroutine(AttackAfterDelay());
		}
    }
	void Attack()
	{
		isAttack = true;
		List<Collider2D> hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer).ToList();
		foreach  (Collider2D enemy in hitEnemies)
		{
			IHitable hitable = enemy.GetComponentInParent<Health>();
			if(hitable != null)
			{
				hitable.GetHit(damageValue, gameObject);
			}
		}
	}
	IEnumerator AttackAfterDelay()
	{
		Attack();
		yield return new WaitForSeconds(1f);
		isAttack = false;
	}
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
