using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusSlider : MonoBehaviour
{
    [SerializeField] private Slider virusSlider;

    private void Start()
    {
        InitializedSliderValue();
        GameManager.Instance.OnVirusValueChanged += UpdateVirusSlider;
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnVirusValueChanged -= UpdateVirusSlider;
    }
    private void InitializedSliderValue()
    {
        virusSlider.maxValue = GameManager.Instance.virusMaxValue;
        virusSlider.value = GameManager.Instance.currentVirusValue;
    }

    private void UpdateVirusSlider()
    {
        virusSlider.value = GameManager.Instance.currentVirusValue;
    }


}
