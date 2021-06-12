using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]


public class PlayerDataSO : ScriptableObject
{

    public CoinStateSO coinState = null;
    public HealthStateSO healthState = null;

    public void ResetPlayer()
    {
        healthState.ResetHealth();
        coinState.ResetCoins();
    }

    public void OnLevelExit()
    {
        coinState.DeInitialiseCollectableForCurrentLevel();
    }

    public void OnCollectableKnown(Collectable[] collectables)
    {
        coinState.InitialiseCollectableForCurrentLevel(collectables);
    }

}
