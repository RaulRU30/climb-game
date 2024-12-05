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
    private bool isPlayerInTrigger = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(LoadSceneWithFade());
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    public IEnumerator LoadSceneWithFade()
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
