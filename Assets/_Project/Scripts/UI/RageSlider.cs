using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageSlider : MonoBehaviour
{
    [SerializeField] private bool isDownRage;
    [SerializeField] private Slider rageSlider;
    private Coroutine downRageValue;

    private void Start()
    {
        InitializedSliderValue();
        GameManager.Instance.OnRageValueChanged += UpdateRageSlider;
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnRageValueChanged -= UpdateRageSlider;
    }

    private void InitializedSliderValue()
    {
        rageSlider.maxValue = GameManager.Instance.rageMaxValue;
        rageSlider.value = GameManager.Instance.currentRageValue;
    }
    private void UpdateRageSlider()
    {
        rageSlider.value = GameManager.Instance.currentRageValue;

        if(downRageValue != null)
        {
            StopCoroutine(downRageValue);
        }
        downRageValue = StartCoroutine(DownRageValue());
    }

    private IEnumerator DownRageValue()
    {
        float rageValue = rageSlider.value;
        while (rageValue >= 0)
        {
            rageValue -= 0.5f;
            GameManager.Instance.LessRage(rageValue);
            rageSlider.value = GameManager.Instance.currentRageValue;
            yield return new WaitForSeconds(0.1f);
        }
        rageSlider.value = 0;
        GameManager.Instance.currentRageValue = 0;
    }

}
