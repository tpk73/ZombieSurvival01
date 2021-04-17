using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float currHealth;
    public float maxHealth = 100f;
    public float damage;
    public Camera uavCam;

    public static Player player;
    public HealthBar healthBar;
    public GameObject deathScreen;
    public GameObject HUD;

    bool isAlive;

    void Start()
    {
        uavCam.enabled = false;

        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void FixedUpdate()
    {
         damage = UnityEngine.Random.Range(15f, 25f);
    }

    void Update()
    {
        GameOver();
    }

    void GameOver()
    {
        if(currHealth <= 0)
        {
            isAlive = false;
            HUD.SetActive(false);
            deathScreen.SetActive(true);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            TakeDamage(damage);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "MedKit")
        {
            if (currHealth < maxHealth)
            {
                UpdateHealth(25);

                if (currHealth > maxHealth)
                {
                    UpdateHealth(0);
                }
            }
            Debug.Log(currHealth);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "UAV")
        {
            uavCam.enabled = true;
            Destroy(collision.gameObject);
        }
    }
    private void UAV()
    {
        uavCam.enabled = true;
    }

    private void UpdateHealth(float health)
    {
        if (currHealth < maxHealth)
        {
            currHealth += 25;

            if (currHealth > maxHealth)
            {
                currHealth = maxHealth;
            }
        }

        healthBar.SetHealth(currHealth);
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
        healthBar.SetHealth(currHealth);
    }
}
   


