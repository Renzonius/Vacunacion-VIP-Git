using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject gameOverPanel;

    [Header("WIN PANELS")]
    [SerializeField] private GameObject virusNeutralizedPanel;

    [Header("LOSE PANELS")]
    [SerializeField] private GameObject infectedPanel;
    [SerializeField] private GameObject ragingPanel;
    [SerializeField] private GameObject virusOutOfControlPanel;

    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    { 
        GameManager.Instance.OnPlayerLose += PlayerLose;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnPlayerLose -= PlayerLose;
    }

    public void ShowHUD()
    {
        hudPanel.SetActive(true);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void PlayerLose()
    {
        GameState reason = GameManager.Instance.CurrentState;

        switch(reason)
        {
            case GameState.PlayerInfected:
                infectedPanel.SetActive(true);
                break;
            case GameState.RagedPeople:
                ragingPanel.SetActive(true);
                break;
            case GameState.UncontrolledVirus:
                virusOutOfControlPanel.SetActive(true);
                break;
        }
    }
}
