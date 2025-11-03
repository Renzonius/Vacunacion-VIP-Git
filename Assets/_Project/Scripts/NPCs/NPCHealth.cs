using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NPCHealth : MonoBehaviour
{
    public bool isSick = false;
    public bool isVulnerable = false;
    private float maxHealth = 100; //100 es el maximo de vida.
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Heal(float healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, 100);
        if(maxHealth == 100)
        {
            isSick = false;
            isVulnerable = false;
        }
    }

    public void MakeVulnerable()
    {
        isVulnerable = true;
    }

}
