using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    //Animator enemy
    GameObject hazua;
    Hazua_Health hazuaHealth;

    bool playerInRange;
    float timer;

    //enemy = GetComponent<Animator>()
    void Awake()
    {
        hazua = GameObject.FindGameObjectWithTag("Player");
        hazuaHealth = hazua.GetComponent<Hazua_Health>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == hazua)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == hazua)
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();
        }

        if (hazuaHealth.currentHealth <= 0)
        {
            //hazua.SetTrigger("PlayerDead")
        }
    }

    void Attack()
    {
        timer = 0f;

        if (hazuaHealth.currentHealth > 0)
        {
            hazuaHealth.TakeDamage(attackDamage);
        }
    }
}
