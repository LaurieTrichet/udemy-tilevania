using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] HealthStateSO health = null;
    [SerializeField] SceneLoaderSO sceneLoader = null;

    [SerializeField] PlayerDataSO playerData = null;

   
    // Start is called before the first frame update
    void Start()
    {
        OnLevelEntered();
    }

    public void OnLevelExit(SceneDescriptionSO nextScene)
    {
        playerData.OnLevelExit();
        sceneLoader.LoadScene(nextScene);
    }

    public void OnLevelEntered()
    {
        health.IsAlive = true;

        var collectables = FindObjectsOfType<Collectable>();
        playerData.OnCollectableKnown(collectables);
    }

}
