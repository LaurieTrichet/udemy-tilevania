using UnityEngine;


public abstract class AbstractPositiveNegativeChoicePanelSO : ScriptableObject
{
    public SceneLoaderSO sceneLoader;

    public abstract void OnPositiveChoicePressed();

    public void OnQuitPressed()
    {
        sceneLoader.ExitGame();
    }
}
