using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BreathingOrb : MonoBehaviour
{
    public Button toggleButton; // Reference to the Button
    public Text buttonText;     // Reference to the Button's Text
    private bool isBreathing;  // State of the animation
    public GameObject spherePrefab; // Prefab for the sphere to instantiate
    public Transform spawnPosition; // Position to instantiate the sphere

    private GameObject currentSphere; // Reference to the instantiated sphere
    private Animator animator;

    void Start()
    {
        // Attach the method to the button's click event
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(ToggleBreathing);
        }
    }

    public void ToggleBreathing()
    {
        isBreathing = !isBreathing; // Toggle the breathing state

        if (isBreathing)
        {
            buttonText.text = "Inhale while enlarge and exhale while shrink"; // Update button text
            InstantiateSphere(); // Instantiate the sphere
            StartBreathingAnimation(); // Start the breathing animation
        }
        else
        {
            buttonText.text = "Start"; // Reset button text
            StopBreathingAnimation(); // Stop the breathing animation
        }
    }

    public void InstantiateSphere()
    {
        if (spherePrefab != null && spawnPosition != null)
        {
            // Instantiate the sphere and save a reference to it
            currentSphere = Instantiate(spherePrefab, spawnPosition.position, spawnPosition.rotation);

            // Get the Animator component from the instantiated sphere
            animator = currentSphere.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Sphere Prefab or Spawn Position is not assigned.");
        }
    }

    public void StartBreathingAnimation()
    {
        if (animator != null && animator.runtimeAnimatorController != null)
        {
            animator.SetBool("StartBreathing", true);
            StartCoroutine(StopBreathingAnimation());
        }
        else
        {
            Debug.LogError("Animator is not assigned or Animator Controller is missing.");
        }
    }

    IEnumerator StopBreathingAnimation()
    {
        yield return new WaitForSeconds(30f);
        if (animator != null)
        {
            animator.SetBool("StartBreathing", false); // Stop the animation
        }
    }
}
