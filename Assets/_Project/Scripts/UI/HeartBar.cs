using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBar : MonoBehaviour, ILifeUI
{
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private int currentLife;
    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        GameManager.Instance.OnPlayerLifeChanged -= UpdateLife;
    }

    private void Start()
    {
        InitiateHeartBar();
        currentLife = hearts.Length;
        GameManager.Instance.OnPlayerLifeChanged += UpdateLife;
    }

    private void InitiateHeartBar()
    {
        int currentLife = GameManager.Instance.playerCurrentLife;
        for (int i = 0; i < currentLife; i++)
        {
            if (i < currentLife)
            {
                hearts[i].SetActive(true);
            }
        }
    }

    public void UpdateLife()
    {
        hearts[currentLife - 1].SetActive(false);
        currentLife--;
        Debug.Log("Updating Heart Bar");
    }
}
