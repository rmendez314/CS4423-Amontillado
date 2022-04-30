using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
	[SerializeField] private Text CurrentHealthText;

    public void UpdateHealth(int currentHealth)
	{
		CurrentHealthText.text = currentHealth.ToString();
	}

}
