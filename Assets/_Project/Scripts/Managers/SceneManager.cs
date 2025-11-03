using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// -RESPONSABILIDAD-
/// Este script gestiona las transiciones de escena con efectos de fundido (fade in y fade out).
/// -COMENTARIOS-
/// Trabaja en conjunto con otros GameObjects que ya estan instanciados en la escena.
/// El GameObject SceneController (objeto ya instaciado) se encarga de llamar a los métodos FadeIn y FadeOut 
/// en los momentos adecuados del flujo de la escena.
/// -POSIBLE UPGRADE-
/// Podemos extraer la lógica de FadeIn y FadeOut a una clase nueva, añadir esa clase al GameObject SceneManager
/// Crear metodos en la clase SceneManager que ocupen la logica que contenga FadeIn y FadeOut, y ocupar esos metodos en conjunto
/// con mi clase SceneController.
/// </summary>
public class SceneManager : MonoBehaviour
{
    [Header("FADE EFFECT")]
    [SerializeField] private GameObject fadeEffect;
    [SerializeField] private CanvasGroup canvasGroupFadeEffect;
    public float timeToFadeInDuration;
    public float timeToFadeOutDuration;
    public static SceneManager Instance { get; private set; }
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

    //FadeIn de NEGRA a VISIBLE
    public void FadeIn()
    {
        StartCoroutine(nameof(FadeInCoroutine));
    }
    private IEnumerator FadeInCoroutine()
    {
        fadeEffect.SetActive(true);
        float elapsedTime = 0f;
        while (elapsedTime < timeToFadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroupFadeEffect.alpha = 1f - Mathf.Clamp01(elapsedTime / timeToFadeInDuration);
            yield return null;
        }
        canvasGroupFadeEffect.alpha = 0f;
        fadeEffect.SetActive(false);
    }

    //FadeOut de VISIBLE a NEGRA
    public void FadeOut()
    {
        StartCoroutine(nameof(FadeOutCoroutine));
    }
    private IEnumerator FadeOutCoroutine()
    {
        fadeEffect.SetActive(true);
        float elapsedTime = 0f;
        while (elapsedTime < timeToFadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroupFadeEffect.alpha = Mathf.Clamp01(elapsedTime / timeToFadeOutDuration);
            yield return null;
        }
        canvasGroupFadeEffect.alpha = 1f;
    }

}
