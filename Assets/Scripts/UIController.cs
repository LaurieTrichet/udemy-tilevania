using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] HealthStateSO healthState;
    [SerializeField] CoinStateSO coinStateSO;
    [SerializeField] TMPro.TMP_Text scoreText;
    [SerializeField] TMPro.TMP_Text LivesText;

    private void Awake()
    {
        healthState.OnLivesUpdated += UpdateLivesText;
        coinStateSO.OnScoreUpdated += UpdateScoreText;
    }

    private void Start()
    {
        scoreText.text = coinStateSO.nbOfCoins.ToString();
        LivesText.text = healthState.Lives.ToString();
    }

    private void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    private void UpdateLivesText(int lives)
    {
        LivesText.text = lives.ToString();
    }

    private void OnDestroy()
    {
        healthState.OnLivesUpdated -= UpdateLivesText;
        coinStateSO.OnScoreUpdated -= UpdateScoreText;
    }
}
