using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerCombat : MonoBehaviour
{
	
	public Animator animator;
	
	public Transform attackPoint;
	public float attackRange = 0.5f;
	public LayerMask enemyLayers;
	public float cooldown;
	private float currentCooldown;
	public bool canAttack = false;
	
	public bool alive;
	
	public UnityEvent onDeath;
	
	
	void Start()
	{
		currentCooldown = cooldown;
		canAttack = false;
		alive = true;
	}
	
    void Update()
	{
		currentCooldown -= Time.deltaTime;
		
		if (currentCooldown <= 0 && canAttack == false)
		{
			currentCooldown = cooldown;
			canAttack = true;
		}
    	
		if(Input.GetKeyDown(KeyCode.Mouse0) && canAttack == true)
	    {
	    	Attack();
			canAttack = false;
	    }
	    
		if(alive == false)
		{
			PlayerDie();
		}
    }
    
    
	void Attack()
	{
		animator.SetTrigger("Attack");
		
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
		
		foreach(Collider2D enemy in hitEnemies)
		{
			enemy.GetComponent<Plant>().Die();
		}
	
	}
	
	void PlayerDie()
	{
		animator.SetBool("PlayerDeath", true);
		
		onDeath.Invoke();
		
		//GetComponent<playerController>().enabled = false;
		//this.enabled = false;
	}
	
	protected void OnDrawGizmos()

	{
		if(attackPoint == null)
			return;
		
		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}	
    
    
}
