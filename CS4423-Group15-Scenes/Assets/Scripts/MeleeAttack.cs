using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeAttack : MonoBehaviour
{
    public enemyAI agent;
    public PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.Find("PlayerModel").GetComponent<PlayerStats>();
        agent = GameObject.Find("Enemies/").GetComponent<enemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerStats.playerInAttackRange)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("Left Mouse Button Pressed");
                agent.TakeDamage(10);
            }
        }
    }
}
