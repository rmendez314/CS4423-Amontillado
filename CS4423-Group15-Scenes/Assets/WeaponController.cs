using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bone_Axe;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
	public GameObject Enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                AxeAttack();
				
            }
        }

    }

    public void AxeAttack()
    {

        CanAttack = false;
        Animator anim = bone_Axe.GetComponent<Animator>();
        anim.SetTrigger("Attack");
		StartCoroutine(ResetAttackCooldown());
		

    }

    IEnumerator ResetAttackCooldown()
    {

        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }


}
