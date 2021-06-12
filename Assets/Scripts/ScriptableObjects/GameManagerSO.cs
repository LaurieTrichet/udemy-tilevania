using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "ScriptableObjects/GameManager")]
public class GameManagerSO : ScriptableObject
{
    [SerializeField] SceneDescriptionSO gameOverSO = null;
    [SerializeField] SceneLoaderSO sceneLoader = null;
    [SerializeField] EnemyReferenceSO enemyReferenceSO = null;
    [SerializeField] PlayerDataSO playerData = null;

    public void OnPlayerDied()
    {
        enemyReferenceSO.DesactivateEnemies();
        sceneLoader.RestartLevel();
    }

    public void OnGameOver()
    {
        playerData.ResetPlayer();
        enemyReferenceSO.DesactivateEnemies();
        sceneLoader.ShowSceneOver(gameOverSO);
    }
}
