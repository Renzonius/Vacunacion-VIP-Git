using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionDoseBox : MonoBehaviour
{
    [SerializeField] private int ammoAmount;
    private void OnTriggerEnter2D(Collider2D tri)
    {
        if(tri.CompareTag("Player"))
        {
            GameManager.Instance.AddAmmo(ammoAmount);
            Destroy(gameObject);
        }
    }
}
