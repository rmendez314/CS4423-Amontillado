using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private PlayerHUD hud;

    private void Start()
	{
		GetReferences();
		InitVariables();
	}

	private void GetReferences()
	{
		hud = GetComponent<PlayerHUD>();
	}

	public override void CheckHealth()
	{
		base.CheckHealth();
		hud.UpdateHealth(health);
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.T)) //Testing method. Pressing T will damage you
		{
			TakeDamage(25);
		}
	}
}
