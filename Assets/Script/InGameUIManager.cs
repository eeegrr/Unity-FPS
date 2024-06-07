using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreTextObject;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        // Fetch scorekeeper
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }

    private void Start()
    {
        UpdateScoreText(); // Check score on start-up
    }

    public void UpdateScoreText()
    {
        // Update coins text
        scoreTextObject.text = $"Coins: {scoreKeeper.GetCoins()}";

    }

}
