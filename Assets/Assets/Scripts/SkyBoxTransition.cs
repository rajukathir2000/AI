using UnityEngine;

public class SkyboxTransition : MonoBehaviour
{
    [Header("Skybox Transition Settings")]
    public Color startColor = Color.black; // Starting skybox color
    public Color endColor = Color.blue;   // Target skybox color
    public float transitionDuration = 30f; // Duration of the transition

    private Material skyboxMaterial; // Reference to the skybox material
    private bool isTransitioning = false;

    private void Start()
    {
        // Ensure the skybox material is set in RenderSettings
        if (RenderSettings.skybox != null)
        {
            skyboxMaterial = RenderSettings.skybox;
            skyboxMaterial.SetColor("_Tint", startColor);
        }
        else
        {
            Debug.LogError("No Skybox Material assigned in RenderSettings.");
        }
    }

    public void StartSkyboxTransition()
    {
        if (!isTransitioning && skyboxMaterial != null)
        {
            StartCoroutine(TransitionSkybox());
        }
    }

    private System.Collections.IEnumerator TransitionSkybox()
    {
        isTransitioning = true;

        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / transitionDuration);

            Color currentColor = Color.Lerp(startColor, endColor, t);
            skyboxMaterial.SetColor("_Tint", currentColor);

            yield return null;
        }

        isTransitioning = false;
    }
}
