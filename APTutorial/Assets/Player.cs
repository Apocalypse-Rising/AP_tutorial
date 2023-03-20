using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public Healthbar Healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Healthbar.SetMaxHealth(maxHealth);
    }

    void takeDamage(int Damage)
    {
        currentHealth -= Damage;

        Healthbar.SetHealth(currentHealth);
   
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            takeDamage(1);
        }
    }
}
