using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CoinState", menuName = "ScriptableObjects/CoinState")]
public class CoinStateSO : ScriptableObject
{
    public int nbOfCoins = 0;

    public bool[] collectableStates = null;
    public UnityAction<int> OnScoreUpdated;
    public void OnCoinCollected(int value, Collectable collectable)
    {
        nbOfCoins += value;
        UpdateCoinState(collectable);
        OnScoreUpdated?.Invoke(nbOfCoins);
    }

    private void UpdateCoinState(Collectable collectable)
    {
        if (collectableStates != null)
        {
            collectableStates[collectable.Index] = false;
        }
    }

    public void ResetCoins()
    {
        nbOfCoins = 0;
        OnScoreUpdated?.Invoke(nbOfCoins);
        DeInitialiseCollectableForCurrentLevel();
    }

    public void InitialiseCollectableForCurrentLevel(Collectable[] collectables)
    {
        var isFirstLevelLoad = collectableStates == null || collectableStates.Length == 0;
        if (isFirstLevelLoad)
        {
            InitialiseCollectablesCache(collectables);
        }
        else
        {
            UpdateCollectablesCache(collectables);
        }
    }
    private void InitialiseCollectablesCache(Collectable[] collectables)
    {
        collectableStates = new bool[collectables.Length];
        for (var i = 0; i < collectableStates.Length; ++i)
        {
            collectables[i].Index = i;
            collectableStates[i] = true;
        }
    }

    private void UpdateCollectablesCache(Collectable[] collectables)
    {
        for (var i = 0; i < collectables.Length; ++i)
        {
            collectables[i].Index = i;
            collectables[i].SetActive(collectableStates[i]);
        }
    }

    public void DeInitialiseCollectableForCurrentLevel()
    {
        collectableStates = null;
    }

}
