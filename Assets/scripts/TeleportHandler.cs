using System.Collections;
using System.Collections.Generic;
using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeleportHandler : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica que sea el jugador u otro objeto específico
        if (other.CompareTag("Player"))
        {
            vThirdPersonInput playerController = other.GetComponent<vThirdPersonInput>();
            playerController.horizontalInput = "";
            playerController.verticallInput = "";
            StartCoroutine(LoadSceneWithFade());
        }
    }

    private IEnumerator LoadSceneWithFade()
    {
        yield return StartCoroutine(Fade(0, 1));

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return StartCoroutine(Fade(1, 0));
    }



    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
        fadeImage.color = new Color(color.r, color.g, color.b, endAlpha);
    }


}
