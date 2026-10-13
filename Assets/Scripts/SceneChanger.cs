using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    [SerializeField] private string _sceneName;

    public void ChangeScene()
    {
        if (string.IsNullOrWhiteSpace(_sceneName))
        {
            Debug.LogWarning(
                $"{name}: SceneChanger has no scene name set in the Inspector.",
                this);
            return;
        }

        if (!Application.CanStreamedLevelBeLoaded(_sceneName))
        {
            // Turns a confusing runtime exception into a clear instruction.
            Debug.LogError(
                $"{name}: the scene '{_sceneName}' cannot be loaded because it is not " +
                "in the build settings. Open File > Build Settings and add it.",
                this);
            return;
        }

        SceneManager.LoadScene(_sceneName);
    }
}
