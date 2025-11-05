using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private NPCHealth npcHealth;

    [Header("Sick Effect")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Color healthyColor = Color.white;
    private Color sickColor = Color.green;
    private Color rageColor = Color.red;

    private void Start()
    {
        //if(npcHealth.isSick)
        //{
        //    spriteRenderer.color = sickColor;
        //}
    }

    private void OnTriggerEnter2D(Collider2D tri)
    {
        if (tri?.GetComponent<Syringe>())
        {
            float projectileHealValue = tri.GetComponent<Syringe>().healAmount;
            AnalyzeHealth(projectileHealValue);
        }
    }

    public void AnalyzeHealth (float projectileHealValue)
    {
        float healAmount = projectileHealValue;
        if (npcHealth.isSick)
        {
            StartCoroutine(nameof(SickEffectCoroutine));
            npcHealth.Heal(healAmount);
        }
        else
        {
            GameManager.Instance.AddRage(27f);
            StartCoroutine(nameof(RageEffect));
        }
    }

    private IEnumerator RageEffect()
    {
        spriteRenderer.color = rageColor;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = healthyColor;
    }

    private IEnumerator SickEffectCoroutine()
    {
        spriteRenderer.color = healthyColor;
        yield return new WaitForSeconds(0.1f);
        if (npcHealth.isSick)
        spriteRenderer.color = sickColor;
        //Aca se debe restar el npc de la lista de NPCs enfermos en el GameManager
    }

    public void MakeSick()
    {
        npcHealth.isSick = true;
        npcHealth.currentHealth = 0f;
        spriteRenderer.color = sickColor;
        //Aca se debe agregar el npc a la lista de NPCs enfermos en el GameManager
    }

}
