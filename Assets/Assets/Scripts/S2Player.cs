using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S2Player : MonoBehaviour
{
    public Image blackPanel;
    public float fadeDuration = 3f;

    private void Start()
    {
        Application.targetFrameRate = -1;
        QualitySettings.vSyncCount = 0;
        StartCoroutine(FadeOut());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Home"))
        {
            FirstScene();
        }
    }

    public void FirstScene()
    {
        StartCoroutine(FadeIn());
        StartCoroutine(LoadSceneAfterDelay(0));
    }

    private IEnumerator FadeIn()
    {
        float duration = 2f;
        float currentTime = 0f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, currentTime / duration);
            blackPanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        blackPanel.color = new Color(0, 0, 0, 1);
    }

    private IEnumerator FadeOut()
    {
        float duration = 2f;
        float currentTime = 0f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, currentTime / duration);
            blackPanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        blackPanel.color = new Color(0, 0, 0, 0);
    }

    private IEnumerator LoadSceneAfterDelay(int sceneIndex)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}
