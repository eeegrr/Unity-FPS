using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int coins;

    private void Awake()
    {
        // Reset coins on start
        coins = 0;
    }

    public void AddCoin()
    {
        coins++; // Add one coin
        // coins = coins + 1;
        // coins += 1;
    }

    public int GetCoins()
    {
        // Return the number of coins
        return coins;
    }

}
