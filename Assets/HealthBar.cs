using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public void Maxhealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        Debug.Log(health);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
 
}
