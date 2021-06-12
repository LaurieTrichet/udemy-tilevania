using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "HealthState", menuName = "ScriptableObjects/HealthStateSO")]
public class HealthStateSO : ScriptableObject
{
    public int nbOfLives = 3;
    public UnityAction<int> OnLivesUpdated;
    public int Lives { get => lives; set => lives = value; }

    [SerializeField] bool isAlive = true;
    [SerializeField] UnityEvent OnDeath;
    [SerializeField] UnityEvent OnGameOver;

    private int lives = 0;

    public bool IsAlive { 
        get => isAlive; 
        set { 
            if (isAlive == value) { return; }
            isAlive = value; 
            if (!isAlive )
            {
                LoseLife();
                if (HaveLives())
                {
                    OnDeath?.Invoke();
                }
                else 
                {
                    OnGameOver?.Invoke();
                }
            }
        } 
    }
    public bool IsDead { get => !isAlive; }

    private void Awake()
    {
        IsAlive = true;
    }

    public void ResetLives()
    {
        lives = nbOfLives;
        OnLivesUpdated?.Invoke(lives);
    }

    public bool HaveLives()
    {
        return lives > 0;
    }

    public void LoseLife()
    {
        lives--;
        OnLivesUpdated?.Invoke(lives);
    }

    public void ResetHealth()
    {
        isAlive = true;
        ResetLives();
    }
}
