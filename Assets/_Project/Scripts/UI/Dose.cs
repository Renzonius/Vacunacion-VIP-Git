using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dose : MonoBehaviour
{
    public bool isFull;
    [SerializeField] private Image doseSlider;
    [SerializeField] private float fullDose = 1f;

    public void AddLiquid(float doseAmount)
    {
        StartCoroutine(nameof(AddLiquidCoroutine), doseAmount);
    }

    private IEnumerator AddLiquidCoroutine(float doseAmount)
    {
        float doseToAdd = doseAmount;
        while (doseSlider.fillAmount < doseToAdd)
        {
            doseSlider.fillAmount += 0.1f;
            yield return new WaitForSeconds(0.0001f);
        }
        doseSlider.fillAmount = doseToAdd;

        if(doseSlider.fillAmount >= fullDose)
        {
            isFull = true;
        }
    }

    public void LessLiquid(float doseAmount)
    {
        StartCoroutine(nameof(LessLiquidCoroutine), doseAmount);
    }

    private IEnumerator LessLiquidCoroutine(float doseAmount)
    {
        float doseToRemove = doseAmount;
        while (doseSlider.fillAmount > doseToRemove)
        {
            doseSlider.fillAmount -= 0.1f;
            yield return new WaitForSeconds(0.0005f);
        }
        doseSlider.fillAmount = doseToRemove;
        if (doseSlider.fillAmount < fullDose)
        {
            isFull = false;
        }
    }

}
