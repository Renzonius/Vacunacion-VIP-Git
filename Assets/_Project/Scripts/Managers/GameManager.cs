using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum GameState { MainMenu, Playing, PlayerInfected, RagedPeople, VirusNeutralized, UncontrolledVirus, Paused }

public class GameManager : MonoBehaviour
{
    public GameState CurrentState;
    public event Action<GameState> OnGameStateChanged;


    [Header("VIRUS / RAGE")]
    public float rageMaxValue;
    public float currentRageValue = 0f;
    public float virusMaxValue;
    public float currentVirusValue = 0f;

    public event Action OnRageValueChanged;
    public event Action OnVirusValueChanged;

    [Header("PLAYER SETTINGS")]
    public int playerMaxLife;
    public int playerCurrentLife;
    public int playerMaxAmmo;
    public int playerCurrentAmmo;
    //public int playerScore;

    public event Action OnPlayerAmmoChanged;
    public event Action OnPlayerLifeChanged;
    public event Action OnPlayerScoreChanged;

    public event Action OnPlayerLose;


    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ChangeState(GameState.MainMenu);
    }

    public void AddAmmo(int amount)
    {
        playerCurrentAmmo += amount;
        playerCurrentAmmo = Mathf.Clamp(playerCurrentAmmo, 0, playerMaxAmmo);
        OnPlayerAmmoChanged?.Invoke();

    }
    public void LessAmmo(int amount)
    {
        playerCurrentAmmo -= amount;
        playerCurrentAmmo = Mathf.Clamp(playerCurrentAmmo, 0, int.MaxValue);
        OnPlayerAmmoChanged?.Invoke();
    }

    //Este metodo se debe llamar desde otros scripts cuando el jugador gane puntos.
    //public void AddScore(int amount)
    //{
    //    playerScore += amount;
    //    //OnPlayerScoreChanged?.Invoke();
    //}

    //Este metodo se debe llamar desde otros scripts cuando el jugador pierda vida.
    public void LessLife(int amount)
    {
        playerCurrentLife -= amount;
        playerCurrentLife = Mathf.Max(playerCurrentLife, 0);
        OnPlayerLifeChanged?.Invoke();
        if (playerCurrentLife <= 0)
        {
            Debug.Log("Game Over");
            ChangeState(GameState.PlayerInfected);
        }
    }


    //Este metodo se debe llamar desde otros scripts cuando un NPC(Sano) detecta un proyectil.
    public void AddRage(float amount)
    {
        currentRageValue += amount;
        currentRageValue = Mathf.Clamp(currentRageValue, 0f, rageMaxValue);
        if(currentRageValue >= rageMaxValue)
        {
            Debug.Log("Game Over - Rage Maxed");
            ChangeState(GameState.RagedPeople);
        }
        OnRageValueChanged?.Invoke();
    }
    public void LessRage(float amount)
    {
        currentRageValue = Mathf.Clamp(amount, 0f, rageMaxValue);
    }

    //Este metodo se debe llamar desde otros scripts cuando un NPC cambia su estado (Sano->Infectado).
    public void AddVirus(float amount)
    {
        currentVirusValue += amount;
        currentVirusValue = Mathf.Clamp(currentVirusValue, 0f, virusMaxValue);
        OnVirusValueChanged?.Invoke();
        if(currentVirusValue >= virusMaxValue)
        {
            Debug.Log("Game Over - Virus Maxed");
            ChangeState(GameState.UncontrolledVirus);
        }
    }

    //Este metodo se debe llamar desde otros scripts cuando un NPC cambia su estado (Infectado->Sano).
    public void LessVirus(float amount)
    {
        currentVirusValue -= amount;
        currentVirusValue = Mathf.Clamp(currentVirusValue, 0f, virusMaxValue);
        OnVirusValueChanged?.Invoke();
    }

    #region CONTROLS
    public void AddMunitionControl(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AddAmmo(12);
        }
    }

    public void LessMunitionControl(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            LessAmmo(1);
        }
    }
    #endregion


    public void ChangeState(GameState newState)
    {
        if (CurrentState == newState) return;

        CurrentState = newState;
        OnGameStateChanged?.Invoke(newState);

        switch (newState)
        {
            case GameState.MainMenu:
                Time.timeScale = 1f;
                break;
            case GameState.Playing:
                Time.timeScale = 1f;
                break;
            case GameState.Paused:
                Time.timeScale = 0f;
                break;
            case GameState.RagedPeople:
                OnPlayerLose?.Invoke();
                Time.timeScale = 0f;
                break;
            case GameState.PlayerInfected:
                OnPlayerLose?.Invoke();
                Time.timeScale = 0f;
                break;
            case GameState.UncontrolledVirus:
                OnPlayerLose?.Invoke();
                Time.timeScale = 0f;
                break;
        }
    }


}