using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image Fill;
    
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        Fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        Fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void Damage()
    {
        slider.value = slider.value - 1;
        Fill.color = gradient.Evaluate(slider.normalizedValue);
        if (slider.value == 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
   
}
