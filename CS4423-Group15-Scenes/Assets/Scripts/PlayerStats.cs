using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
	public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    private PlayerHUD hud;
	private UIManager ui;
	public LayerMask whatIsEnemy;
	//Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
	

    private void Start()
	{
		GetReferences();
		InitVariables();
		GameObject enemy = GameObject.Find("Enemies/");
	}

	private void GetReferences()
	{
		hud = GetComponent<PlayerHUD>();
		ui = GetComponent<UIManager>();
	}

	public override void CheckHealth()
	{
		base.CheckHealth();
		hud.UpdateHealth(health);
	}

	public override void Die()
	{
		base.Die();
		ui.SetActiveHud(false);
	}

	public bool IsDead()
	{
		return isDead;
	}
	private void Update()
	{
		//Check for sight and attack range
		playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsEnemy);
		playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);
		if (Input.GetKeyDown(KeyCode.T))
		{
			TakeDamage(25);
		}
			// check if player has been attacked
			if (!alreadyAttacked){
			playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsEnemy);
			playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);
			if (playerInAttackRange && playerInSightRange) {
				//Debug.LogWarning("Player has been attacked");
				TakeDamage(5);
				alreadyAttacked = true;
            	Invoke(nameof(ResetAttack), timeBetweenAttacks);
			}
		}
	}
	// resets the attack
	private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
