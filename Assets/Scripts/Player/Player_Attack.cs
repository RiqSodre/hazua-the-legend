using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour {

    private bool attacking = false;

    private float attackTimer = 0;
    private float attackCD = 0.2f;

    public Collider2D attackTrigger;

    private Animator hazua;

    private void Awake()
    {
        hazua = GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown("z") && !attacking)
        {
            attacking = true;
            attackTimer = attackCD;

            attackTrigger.enabled = true;
        }
        if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }

            hazua.SetBool("Attack", attacking);
        }
    }


}
