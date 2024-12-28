using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionHandler : MonoBehaviour
{
    public GameObject objectToDisable; // The GameObject to disable in Scene 1
    private int returnKey = 1; // Using an integer key to track the return state

    private void Start()
    {
        // Check if in Scene 1 (index 0) and returning from Scene 2
        if (SceneManager.GetActiveScene().buildIndex == 0 && PlayerPrefs.GetInt(returnKey.ToString(), 0) == 1)
        {
            Debug.Log(returnKey);
            // Disable the specified GameObject
            if (objectToDisable != null)
            {
                objectToDisable.SetActive(false);
            }

            // Reset the PlayerPrefs key for future transitions
            PlayerPrefs.SetInt(returnKey.ToString(), 0);
            PlayerPrefs.Save();
        }
    }

    public void TransitionToScene2()
    {
        // Set PlayerPrefs to indicate transitioning to Scene 2
        PlayerPrefs.SetInt(returnKey.ToString(), 1);
        Debug.Log("Setted");
        PlayerPrefs.Save();

        // Load Scene 2 (index 1)
        //SceneManager.LoadScene(1);
    }
}
