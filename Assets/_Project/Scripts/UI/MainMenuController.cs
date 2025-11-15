using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject CreditsPanel;
    [SerializeField] private GameObject blockPanel;

    [Header("ANIMATORS")]
    [SerializeField] private Animator mainMenuAnimator;

    private void Start()
    {
        Invoke(nameof(ShowMainMenuPanel), 0.5f);
    }

    public void ShowMainMenuPanel()
    {
        mainMenuAnimator.SetBool("showMainMenu", true);
    }
    public void ShowCreditsMenu()
    {
        mainMenuAnimator.SetBool("showMainMenu", false);
        mainMenuAnimator.SetBool("showCreditsMenu", true);
    }
    public void HideCreditsMenu()
    {
        mainMenuAnimator.SetBool("showMainMenu", true);
        mainMenuAnimator.SetBool("showCreditsMenu", false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void ShowControlsMenu()
    {
        mainMenuAnimator.SetBool("showMainMenu", false);
        mainMenuAnimator.SetBool("showControlsMenu", true);
    }
    public void HideControlsMenu()
    {
        mainMenuAnimator.SetBool("showMainMenu", true);
        mainMenuAnimator.SetBool("showControlsMenu", false);
    }

    public void BackControlsButton()
    {
        HideControlsMenu();
    }

    public void StartButton(string nameLevel)
    {
        blockPanel.SetActive(true);
        SceneController.Instance.LoadScene(nameLevel);
        GameManager.Instance.ChangeState(GameState.Playing);
    }

    public void PlayButton()
    {
        ShowControlsMenu();
    }

    public void CreditsButton()
    {
        ShowCreditsMenu();
    }

    public void BackCreditsButton()
    {
        HideCreditsMenu();
    }
}
