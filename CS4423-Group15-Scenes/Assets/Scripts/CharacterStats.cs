using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;

    [SerializeField] protected bool isDead;

    private void Start()
	{
        InitVariables();
	}

    public virtual void CheckHealth()
	{
        if(health <= 0)
		{
            health = 0;
            Die();
		}
        else if(health >= maxHealth)
		{
            health = maxHealth;
		}
	}

    public void Die()
    {
        isDead = true;
    }

    public void SetHealthTo(int newHP)
	{
        health = newHP;
        CheckHealth();
	}

    public void TakeDamage(int damage)
	{
        SetHealthTo(health - damage);
	}

    public void Heal(int heal)
	{
        SetHealthTo(health + heal);
    }

    public void InitVariables()
	{
        maxHealth = 100;
        SetHealthTo(maxHealth);
        isDead = false;
	}
}
