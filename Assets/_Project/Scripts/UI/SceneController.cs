using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// -RESPONSABILIDAD-
/// Esta clase gestiona el flujo de escenas, incluyendo la carga de nuevas escenas y la aplicación de efectos de transición.
/// -COMENTARIOS-
/// Utiliza la clase SceneManager (Singleton).
/// Esta clase debe estar añadida a un GameObject llamado "SceneController" que ya esté instanciado en la escena.
/// </summary>
public class SceneController : MonoBehaviour
{
    //Con esto obtengo el nombre de la escena actual

    private void Start()
    {
        SceneManager.Instance.FadeIn();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    public void RestartLevel()
    {
        LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        GameManager.Instance.ChangeState(GameState.Playing);
    }


    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        SceneManager.Instance.FadeOut();
        yield return new WaitForSeconds(SceneManager.Instance.timeToFadeOutDuration); // Espera a que termine el fade out.
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        //SceneManager.Instance.FadeIn();
    }


}
