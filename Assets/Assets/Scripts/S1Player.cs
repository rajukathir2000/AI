using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S1Player : MonoBehaviour
{
    public Image blackPanel;
    public float fadeDuration = 3f;
    private SceneTransitionHandler handle;

    private void Start()
    {
        Application.targetFrameRate = -1;
        QualitySettings.vSyncCount = 0;
        StartCoroutine(FadeOut());
    }

    public void SecondScene()
    {
        StartCoroutine(FadeIn());
        StartCoroutine(LoadSceneAfterDelay(1));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            InsideCar();
            handle.TransitionToScene2();
            Debug.Log("Called prefs");
        }
    }

    public void InsideCar()
    {
        gameObject.transform.Translate(new Vector3(2f, -0.5f, 1f));
        SecondScene();
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
