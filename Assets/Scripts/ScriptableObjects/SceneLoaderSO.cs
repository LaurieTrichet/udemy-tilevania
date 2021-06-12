using UnityEngine;
using UnityEngine.SceneManagement;

//[CreateAssetMenu(fileName = "SceneLoader", menuName = "ScriptableObjects/SceneLoader", order = 1)]
public class SceneLoaderSO : ScriptableObject
{

    [SerializeField] SceneDescriptionSO firstLevel = null;

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(firstLevel.sceneName);
    }

    public void LoadScene(SceneDescriptionSO sceneDescription)
    {
        SceneManager.LoadScene(sceneDescription.sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void ShowSceneOver(SceneDescriptionSO sceneDescription)
    {
        var overScene = SceneManager.GetSceneByName(sceneDescription.sceneName);
        if (!overScene.isLoaded)
        {
            SceneManager.LoadScene(sceneDescription.sceneName, LoadSceneMode.Additive);
        }
    }

    public void RemoveSceneOver(SceneDescriptionSO sceneDescription)
    {
        var overScene = SceneManager.GetSceneByName(sceneDescription.sceneName);
        if (overScene.isLoaded)
        {
            SceneManager.UnloadSceneAsync(sceneDescription.sceneName);
        }
    }

    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
        
    }

    private void OnEnable()
    {
        
        Debug.Log("OnEnable");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
        
    }
}

