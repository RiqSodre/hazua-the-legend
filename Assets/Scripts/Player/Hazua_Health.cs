using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hazua_Health : MonoBehaviour
{

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    bool isDead;
    bool damaged;

    Hazua_Controller script;
    //Animator hazua;
    //AudioSource playerAudio;

    //hazua = GetComponent<Animator>();
    //playerAudio = GetComponent<AudioSource>();
    void Awake()
    {
        script = GetComponent<Hazua_Controller>();
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        //hazua.SetTrigger("Die");
        //playerAudio.clip = deathClip;
        //playerAudio.Play();

        script.enabled = false;
    }
}
