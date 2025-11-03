using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmunitionSliderBar : MonoBehaviour
{
    [SerializeField] private Dose[] ammunitionDoseSliders;
    private int currentAmmo;


    private void OnEnable()
    {
    }
    private void OnDisable()
    {
        GameManager.Instance.OnPlayerAmmoChanged -= HandlePlayerAmmoChanged;
    }


    private void Start()
    {
        currentAmmo = GameManager.Instance.playerCurrentAmmo;
        StartCoroutine(nameof(InitializeAmmoBarCoroutine));
        GameManager.Instance.OnPlayerAmmoChanged += HandlePlayerAmmoChanged;

    }
    private IEnumerator InitializeAmmoBarCoroutine()
    {
        for (int i = 0; i < currentAmmo; i++)
        {
            if (ammunitionDoseSliders[i].isFull == false)
            {
                ammunitionDoseSliders[i].AddLiquid(1f);
                yield return new WaitForSeconds(0.0001f);
            }
            else
            {
                break;
            }

        }
    }


    private void HandlePlayerAmmoChanged()
    {
        int newAmmo = GameManager.Instance.playerCurrentAmmo;
        if (newAmmo > currentAmmo)
        {
            int ammoToAdd = newAmmo - currentAmmo;
            AddLiquid(ammoToAdd);
        }
        else if (newAmmo < currentAmmo)
        {
            float ammoToLess = currentAmmo - newAmmo;
            LessLiquidCoroutine();
        }
        currentAmmo = newAmmo;

    }

    private void AddLiquid(int ammoToAdd)
    {
        int doseIndex = 0;
        int dosesToAdd = ammoToAdd;
        foreach (Dose dose in ammunitionDoseSliders)
        {
            if (dose.isFull == true)
            {
                doseIndex++;
            }
        }

        for (int i = doseIndex; i < ammunitionDoseSliders.Length; i++)
        {
            if(dosesToAdd > 0)
            {
                ammunitionDoseSliders[i].AddLiquid(1f);
                dosesToAdd--;
            }
            else
            {
                break;
            }
        }
    }



    private void LessLiquidCoroutine()
    {
        for(int i = ammunitionDoseSliders.Length - 1; i >= 0; i--)
        {
            if (ammunitionDoseSliders[i].isFull == true)
            {
                ammunitionDoseSliders[i].LessLiquid(0f);
                //yield return new WaitForSeconds(0.0005f);
                break;
            }
        }
    }

}
